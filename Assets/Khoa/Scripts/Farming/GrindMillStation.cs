using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

namespace Khoa.Farming
{
    /// <summary>
    /// Trạng thái hoạt động của cối xay lúa.
    /// </summary>
    public enum GrindMillState
    {
        Empty,          // Cối rỗng, chưa đổ thóc vào phễu
        ReadyToGrind,   // Đã đổ thóc vào, sẵn sàng xay
        Grinding,       // Đang quay cần xay lúa
        Completed       // Đã xay xong 100%, gạo trắng đã ra khay
    }

    /// <summary>
    /// Hệ thống Cối Xay Gạo truyền thống miền Tây (Grind Mill Station).
    /// Hỗ trợ:
    /// - Nhận thóc từ giỏ RiceBasketController hoặc vật lý.
    /// - Nắm cần xoay bằng XRGrabInteractable / chuyển động tay VR / phím giả lập.
    /// - Hiệu ứng văng trấu/cám gạo, âm thanh kẽo kẹt theo tốc độ quay, rung Haptic.
    /// - Sinh ra vật phẩm Gạo Trắng (WhiteRiceItem) khi xay xong 100%.
    /// </summary>
    [DisallowMultipleComponent]
    public class GrindMillStation : MonoBehaviour
    {
        [Header("State")]
        public GrindMillState currentState = GrindMillState.Empty;

        [Header("Milling Progression")]
        [Tooltip("Tiến độ xay hiện tại (0 - 100%)")]
        [Range(0f, 100f)]
        public float progress = 0f;

        [Tooltip("Tốc độ xay tăng theo mỗi vòng/đơn vị quay")]
        public float millingSpeedMultiplier = 25f;

        [Header("Output Settings")]
        [Tooltip("Prefab Gạo Trắng (WhiteRiceItem) sinh ra khi xay xong")]
        public GameObject whiteRicePrefab;

        [Tooltip("Vị trí máng/khay hứng gạo trắng dưới cối")]
        public Transform riceOutputPoint;

        [Header("Visual Elements")]
        [Tooltip("Đống thóc vàng trong phễu cối xay (tụt dần khi xay)")]
        public Transform hopperPaddyMesh;
        public Vector3 hopperFullLocalPos = new Vector3(0f, 0.4f, 0f);
        public Vector3 hopperEmptyLocalPos = new Vector3(0f, 0.1f, 0f);

        [Tooltip("Đống gạo trắng xuất hiện ở máng hứng")]
        public GameObject milledRiceVisual;

        [Tooltip("Cần/đòn quay cối xay")]
        public Transform handlebarTransform;

        [Tooltip("Hiệu ứng bụi trấu & cám văng ra khi quay cối")]
        public ParticleSystem chaffParticles;

        [Header("Audio & Haptics")]
        [Tooltip("Nguồn phát âm thanh tiếng cối nghiền trấu")]
        public AudioSource grindingAudioSource;
        [Range(0f, 1f)]
        public float maxAudioVolume = 0.8f;

        [Tooltip("Âm thanh báo hiệu xay xong mẻ lúa")]
        public AudioClip completionSound;

        [Header("XR Interaction")]
        [Tooltip("Handle grab trên cần quay cối")]
        public XRGrabInteractable handleGrabInteractable;

        [Tooltip("Trigger nhận thóc đổ vào phễu")]
        public Collider hopperTrigger;

        // Events cho Game / Quest / UI
        public event Action<GrindMillState> OnStateChanged;
        public event Action<float> OnProgressChanged;
        public event Action<WhiteRiceItem> OnMillingCompleted;

        private IXRSelectInteractor grabbingInteractor;
        private Vector3 previousHandLocalPos;
        private float currentHandleAngle = 0f;
        private float angularSpeed = 0f;
        private float hapticTimer = 0f;
        private WhiteRiceItem spawnedRiceInstance;

        private void Awake()
        {
            if (handleGrabInteractable == null)
            {
                handleGrabInteractable = GetComponentInChildren<XRGrabInteractable>(true);
            }

            ConfigureHandleGrab();
            UpdateVisuals();
        }

        private void OnEnable()
        {
            if (handleGrabInteractable != null)
            {
                handleGrabInteractable.selectEntered.AddListener(OnHandleGrabbed);
                handleGrabInteractable.selectExited.AddListener(OnHandleReleased);
            }
        }

        private void OnDisable()
        {
            if (handleGrabInteractable != null)
            {
                handleGrabInteractable.selectEntered.RemoveListener(OnHandleGrabbed);
                handleGrabInteractable.selectExited.RemoveListener(OnHandleReleased);
            }
            grabbingInteractor = null;
        }

        private void Update()
        {
            float rotationDelta = 0f;

            // 1. Tính toán chuyển động xoay từ tay cầm VR đang nắm cần
            if (grabbingInteractor != null && handlebarTransform != null)
            {
                Transform attachTransform = grabbingInteractor.GetAttachTransform(handleGrabInteractable);
                if (attachTransform != null)
                {
                    Vector3 handLocalPos = transform.InverseTransformPoint(attachTransform.position);
                    Vector2 currentDir = new Vector2(handLocalPos.x, handLocalPos.z);
                    Vector2 prevDir = new Vector2(previousHandLocalPos.x, previousHandLocalPos.z);

                    if (currentDir.sqrMagnitude > 0.01f && prevDir.sqrMagnitude > 0.01f)
                    {
                        float angleDelta = Vector2.SignedAngle(prevDir, currentDir);
                        rotationDelta += Mathf.Abs(angleDelta);
                        currentHandleAngle += angleDelta;
                        handlebarTransform.localRotation = Quaternion.Euler(0f, currentHandleAngle, 0f);
                    }
                    previousHandLocalPos = handLocalPos;
                }
            }

            // 2. Hỗ trợ phím bàn phím / Simulator testing
            if (Keyboard.current != null)
            {
                float keyInput = 0f;
                if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed) keyInput -= 1f;
                if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed) keyInput += 1f;
                if (Keyboard.current.zKey.isPressed || Keyboard.current.upArrowKey.isPressed) keyInput += 1f;

                if (Mathf.Abs(keyInput) > 0.01f)
                {
                    float angleDelta = keyInput * 90f * Time.deltaTime;
                    rotationDelta += Mathf.Abs(angleDelta);
                    currentHandleAngle += angleDelta;
                    if (handlebarTransform != null)
                    {
                        handlebarTransform.localRotation = Quaternion.Euler(0f, currentHandleAngle, 0f);
                    }
                }
            }

            // 3. Xử lý tiến độ xay khi đang có lúa
            angularSpeed = rotationDelta / Mathf.Max(0.001f, Time.deltaTime);

            if (currentState == GrindMillState.ReadyToGrind || currentState == GrindMillState.Grinding)
            {
                if (rotationDelta > 0.01f)
                {
                    if (currentState != GrindMillState.Grinding)
                    {
                        currentState = GrindMillState.Grinding;
                        OnStateChanged?.Invoke(currentState);
                    }

                    progress = Mathf.Clamp(progress + (rotationDelta / 360f) * millingSpeedMultiplier, 0f, 100f);
                    OnProgressChanged?.Invoke(progress);

                    // Hiệu ứng hạt bụi cám văng ra
                    if (chaffParticles != null && !chaffParticles.isPlaying)
                    {
                        chaffParticles.Play();
                    }

                    // Rung Haptic khi xoay
                    TriggerHapticFeedback(angularSpeed);

                    if (progress >= 100f)
                    {
                        CompleteMilling();
                    }
                }
                else
                {
                    if (chaffParticles != null && chaffParticles.isPlaying)
                    {
                        chaffParticles.Stop();
                    }
                }
            }
            else
            {
                if (chaffParticles != null && chaffParticles.isPlaying)
                {
                    chaffParticles.Stop();
                }
            }

            // 4. Cập nhật âm thanh và visual
            UpdateAudio();
            UpdateVisuals();
        }

        /// <summary>
        /// Đổ thóc vào cối xay (gọi từ giỏ thóc hoặc trigger vật lý).
        /// </summary>
        public bool PourPaddyIntoMill()
        {
            if (currentState == GrindMillState.ReadyToGrind || currentState == GrindMillState.Grinding)
            {
                Debug.LogWarning("[GrindMillStation] Cối xay đang chứa lúa, hãy xay hết mẻ này trước!");
                return false;
            }

            currentState = GrindMillState.ReadyToGrind;
            progress = 0f;
            if (milledRiceVisual != null) milledRiceVisual.SetActive(false);
            UpdateVisuals();
            OnStateChanged?.Invoke(currentState);
            OnProgressChanged?.Invoke(progress);
            Debug.Log("<color=yellow>[GrindMillStation] Đã đổ thóc đầy phễu cối! Hãy cầm cần quay cối để xay gạo.</color>");
            return true;
        }

        /// <summary>
        /// Hoàn thành xay 100%: Sinh ra thúng gạo trắng sạch.
        /// </summary>
        public void CompleteMilling()
        {
            currentState = GrindMillState.Completed;
            progress = 100f;

            if (chaffParticles != null) chaffParticles.Stop();
            if (milledRiceVisual != null) milledRiceVisual.SetActive(true);

            if (completionSound != null)
            {
                AudioSource.PlayClipAtPoint(completionSound, transform.position);
            }

            // Sinh vật phẩm Gạo Trắng vật lý để người chơi cầm sang bếp
            SpawnWhiteRiceItem();

            OnStateChanged?.Invoke(currentState);
            OnProgressChanged?.Invoke(progress);
            Debug.Log("<color=green>[GrindMillStation] 🎉 Xay gạo thành công! Gạo trắng đã sẵn sàng để đem đi vo và nấu cơm!</color>");
        }

        private void SpawnWhiteRiceItem()
        {
            Vector3 spawnPos = riceOutputPoint != null
                ? riceOutputPoint.position
                : transform.position + transform.forward * 0.6f + Vector3.up * 0.3f;

            if (whiteRicePrefab != null)
            {
                GameObject riceGO = Instantiate(whiteRicePrefab, spawnPos, Quaternion.identity);
                spawnedRiceInstance = riceGO.GetComponent<WhiteRiceItem>();
            }
            else
            {
                // Fallback tạo primitive item nếu chưa gán prefab
                GameObject fallbackGO = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                fallbackGO.name = "White_Rice_Basket_Item";
                fallbackGO.transform.position = spawnPos;
                fallbackGO.transform.localScale = new Vector3(0.35f, 0.15f, 0.35f);

                Renderer ren = fallbackGO.GetComponent<Renderer>();
                if (ren != null)
                {
                    if (Application.isPlaying)
                        ren.material.color = Color.white;
                    else if (ren.sharedMaterial != null)
                        ren.sharedMaterial.color = Color.white;
                }

                fallbackGO.AddComponent<Rigidbody>();
                fallbackGO.AddComponent<XRGrabInteractable>();
                spawnedRiceInstance = fallbackGO.AddComponent<WhiteRiceItem>();
            }

            if (spawnedRiceInstance != null)
            {
                OnMillingCompleted?.Invoke(spawnedRiceInstance);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other == null) return;

            // Nhận diện giỏ thóc mang tag RiceBasket hoặc RiceBasketController
            if (other.CompareTag("RiceBasket") || other.name.Contains("Basket"))
            {
                PourPaddyIntoMill();
            }
        }

        private void OnHandleGrabbed(SelectEnterEventArgs args)
        {
            grabbingInteractor = args.interactorObject;
            Transform attachTransform = grabbingInteractor.GetAttachTransform(handleGrabInteractable);
            if (attachTransform != null)
            {
                previousHandLocalPos = transform.InverseTransformPoint(attachTransform.position);
            }
        }

        private void OnHandleReleased(SelectExitEventArgs args)
        {
            if (grabbingInteractor == args.interactorObject)
            {
                grabbingInteractor = null;
            }
        }

        private void ConfigureHandleGrab()
        {
            if (handleGrabInteractable == null) return;

            handleGrabInteractable.trackPosition = false;
            handleGrabInteractable.trackRotation = false;
            handleGrabInteractable.trackScale = false;
            handleGrabInteractable.throwOnDetach = false;

            Rigidbody body = handleGrabInteractable.GetComponent<Rigidbody>();
            if (body != null)
            {
                body.isKinematic = true;
                body.useGravity = false;
                body.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            }
        }

        private void UpdateAudio()
        {
            if (grindingAudioSource == null) return;

            if (angularSpeed > 5f && (currentState == GrindMillState.Grinding || currentState == GrindMillState.ReadyToGrind))
            {
                float targetVol = Mathf.Clamp01(angularSpeed / 180f) * maxAudioVolume;
                grindingAudioSource.volume = Mathf.Lerp(grindingAudioSource.volume, targetVol, Time.deltaTime * 5f);
                grindingAudioSource.pitch = Mathf.Clamp(0.8f + (angularSpeed / 360f) * 0.4f, 0.8f, 1.5f);

                if (!grindingAudioSource.isPlaying)
                {
                    grindingAudioSource.Play();
                }
            }
            else
            {
                grindingAudioSource.volume = Mathf.Lerp(grindingAudioSource.volume, 0f, Time.deltaTime * 8f);
                if (grindingAudioSource.volume < 0.01f && grindingAudioSource.isPlaying)
                {
                    grindingAudioSource.Stop();
                }
            }
        }

        private void UpdateVisuals()
        {
            if (hopperPaddyMesh != null)
            {
                if (currentState == GrindMillState.Empty)
                {
                    hopperPaddyMesh.gameObject.SetActive(false);
                }
                else
                {
                    hopperPaddyMesh.gameObject.SetActive(true);
                    float ratio = 1f - (progress / 100f);
                    hopperPaddyMesh.localPosition = Vector3.Lerp(hopperEmptyLocalPos, hopperFullLocalPos, ratio);
                }
            }
        }

        private void TriggerHapticFeedback(float speed)
        {
            hapticTimer += Time.deltaTime;
            if (hapticTimer >= 0.1f && grabbingInteractor is XRBaseControllerInteractor controllerInteractor)
            {
                hapticTimer = 0f;
                float amplitude = Mathf.Clamp01(speed / 360f) * 0.5f;
                controllerInteractor.xrController?.SendHapticImpulse(amplitude, 0.08f);
            }
        }
    }
}

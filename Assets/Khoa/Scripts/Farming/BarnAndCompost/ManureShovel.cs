using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.InputSystem;

namespace Khoa.Farming
{
    /// <summary>
    /// Xẻng xúc phân tươi từ chuồng gia súc và trút vào đống ủ phân Compost.
    /// Cầm bằng Grip (XRGrabInteractable), bấm Trigger/Activate (hoặc phím E trong Editor) để xúc/đổ.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(XRGrabInteractable))]
    [RequireComponent(typeof(Rigidbody))]
    public class ManureShovel : MonoBehaviour
    {
        [Header("Trạng thái xẻng")]
        [SerializeField] private bool isFull = false;
        public bool IsFull => isFull;

        [Header("Bộ phận lưỡi xẻng")]
        public Collider bladeTriggerCollider;
        public GameObject manureVisualOnBlade;

        [Header("Phản hồi & Âm thanh")]
        public AudioSource shovelAudioSource;
        public AudioClip scoopAudioClip;
        public AudioClip depositAudioClip;
        public float hapticDuration = 0.15f;
        public float hapticIntensity = 0.5f;

        [Header("Mục tiêu đang chạm")]
        [SerializeField] private ManureItem currentHoveredManure;
        [SerializeField] private CompostPile currentHoveredCompost;

        public event Action<bool> OnFullStateChanged;

        private XRGrabInteractable grabInteractable;
        private IXRSelectInteractor currentInteractor;

        private void Awake()
        {
            grabInteractable = GetComponent<XRGrabInteractable>();
            if (grabInteractable != null)
            {
                grabInteractable.selectEntered.AddListener(OnSelectEntered);
                grabInteractable.selectExited.AddListener(OnSelectExited);
                grabInteractable.activated.AddListener(OnActivated);
            }

            UpdateVisuals();
        }

        private void OnDestroy()
        {
            if (grabInteractable != null)
            {
                grabInteractable.selectEntered.RemoveListener(OnSelectEntered);
                grabInteractable.selectExited.RemoveListener(OnSelectExited);
                grabInteractable.activated.RemoveListener(OnActivated);
            }
        }

        private void Update()
        {
            // Dev simulator phím E
            if (Application.isEditor && Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
            {
                PerformShovelAction();
            }
        }

        private void OnSelectEntered(SelectEnterEventArgs args)
        {
            currentInteractor = args.interactorObject;
        }

        private void OnSelectExited(SelectExitEventArgs args)
        {
            currentInteractor = null;
        }

        private void OnActivated(ActivateEventArgs args)
        {
            PerformShovelAction();
        }

        /// <summary>
        /// Thực hiện hành động Xúc hoặc Đổ tùy theo đối tượng đang tiếp xúc với lưỡi xẻng.
        /// </summary>
        public bool PerformShovelAction()
        {
            if (!isFull)
            {
                // Thử xúc phân nếu đang chạm đống phân tươi
                if (currentHoveredManure != null && !currentHoveredManure.IsScooped)
                {
                    return ScoopFrom(currentHoveredManure);
                }
                else
                {
                    Debug.Log("[ManureShovel] Xẻng đang rỗng và chưa chạm vào đống phân tươi nào!");
                    return false;
                }
            }
            else
            {
                // Thử đổ phân nếu đang chạm đống ủ
                if (currentHoveredCompost != null)
                {
                    return DepositTo(currentHoveredCompost);
                }
                else
                {
                    Debug.Log("[ManureShovel] Xẻng đang đầy phân, hãy đưa lưỡi xẻng vào đống ủ để trút!");
                    return false;
                }
            }
        }

        /// <summary>
        /// Xúc phân từ một đống phân tươi cụ thể (API atomic).
        /// </summary>
        public bool ScoopFrom(ManureItem manure)
        {
            if (isFull || manure == null || manure.IsScooped) return false;

            if (manure.TryScoop(out float amount))
            {
                isFull = true;
                currentHoveredManure = null;
                UpdateVisuals();

                PlayAudio(scoopAudioClip);
                TriggerHaptic();

                OnFullStateChanged?.Invoke(true);
                Debug.Log("<b>[ManureShovel]</b> Đã xúc thành công 1 phần phân tươi!");
                return true;
            }

            return false;
        }

        /// <summary>
        /// Trút phân vào đống ủ cụ thể (API atomic).
        /// </summary>
        public bool DepositTo(CompostPile compost)
        {
            if (!isFull || compost == null) return false;

            if (compost.TryDepositManure(this))
            {
                isFull = false;
                UpdateVisuals();

                PlayAudio(depositAudioClip);
                TriggerHaptic();

                OnFullStateChanged?.Invoke(false);
                Debug.Log("<b>[ManureShovel]</b> Đã trút phân vào đống ủ!");
                return true;
            }

            return false;
        }

        public void SetFull(bool full)
        {
            isFull = full;
            UpdateVisuals();
            OnFullStateChanged?.Invoke(isFull);
        }

        private void UpdateVisuals()
        {
            if (manureVisualOnBlade != null)
            {
                manureVisualOnBlade.SetActive(isFull);
            }
        }

        private void PlayAudio(AudioClip clip)
        {
            if (clip == null) return;

            if (shovelAudioSource != null)
            {
                shovelAudioSource.PlayOneShot(clip);
            }
            else
            {
                AudioSource.PlayClipAtPoint(clip, transform.position, 0.8f);
            }
        }

        private void TriggerHaptic()
        {
            if (currentInteractor is XRBaseInputInteractor inputInteractor)
            {
                inputInteractor.SendHapticImpulse(hapticIntensity, hapticDuration);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other == null) return;

            ManureItem manure = other.GetComponent<ManureItem>() ?? other.GetComponentInParent<ManureItem>();
            if (manure != null && !manure.IsScooped)
            {
                currentHoveredManure = manure;
            }

            CompostPile compost = other.GetComponent<CompostPile>() ?? other.GetComponentInParent<CompostPile>();
            if (compost != null)
            {
                currentHoveredCompost = compost;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other == null) return;

            ManureItem manure = other.GetComponent<ManureItem>() ?? other.GetComponentInParent<ManureItem>();
            if (manure != null && currentHoveredManure == manure)
            {
                currentHoveredManure = null;
            }

            CompostPile compost = other.GetComponent<CompostPile>() ?? other.GetComponentInParent<CompostPile>();
            if (compost != null && currentHoveredCompost == compost)
            {
                currentHoveredCompost = null;
            }
        }
    }
}

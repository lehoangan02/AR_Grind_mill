using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Movement;
using Unity.XR.CoreUtils;

namespace Khoa.Farming.Boating
{
    /// <summary>
    /// Ghế ngồi và vị trí neo giữ người chơi trên Xuồng Ba Lá VR.
    /// Tắt ContinuousMoveProvider khi lên xuồng để tránh xung đột chuyển động và chống say sóng;
    /// phục hồi locomotion và raycast điểm tiếp đất an toàn lên bờ khi xuống xuồng.
    /// </summary>
    [DisallowMultipleComponent]
    public class SampanSeat : MonoBehaviour
    {
        [Header("Điểm neo giữ & tiếp bờ")]
        public Transform seatAnchor;
        public Transform dismountPoint;
        public float dismountRaycastDistance = 3.5f;

        [Header("Tương tác lên / xuống xuồng")]
        public XRSimpleInteractable mountInteractable;
        public XRSimpleInteractable dismountInteractable;

        [Header("Trạng thái (Read-Only)")]
        [SerializeField] private bool isSeated = false;
        [SerializeField] private GameObject playerRig;

        public bool IsSeated => isSeated;

        public event Action<bool> OnSeatedStateChanged;

        private Transform originalPlayerParent;
        private ContinuousMoveProvider cachedMoveProvider;

        private void Awake()
        {
            if (seatAnchor == null) seatAnchor = transform;

            if (mountInteractable != null)
            {
                mountInteractable.activated.AddListener(OnMountActivated);
            }

            if (dismountInteractable != null)
            {
                dismountInteractable.activated.AddListener(OnDismountActivated);
            }
        }

        private void OnDestroy()
        {
            if (mountInteractable != null)
            {
                mountInteractable.activated.RemoveListener(OnMountActivated);
            }

            if (dismountInteractable != null)
            {
                dismountInteractable.activated.RemoveListener(OnDismountActivated);
            }
        }

        private void OnMountActivated(ActivateEventArgs args)
        {
            if (!isSeated)
            {
                Mount(ResolvePlayerRig(args.interactorObject));
            }
        }

        private void OnDismountActivated(ActivateEventArgs args)
        {
            if (isSeated)
            {
                Dismount();
            }
        }

        /// <summary>
        /// Cho người chơi lên xuồng và neo giữ vào ghế.
        /// </summary>
        public bool Mount(GameObject player)
        {
            if (isSeated) return false;

            if (player == null)
            {
                player = FindPlayerRigInScene();
            }

            if (player == null)
            {
                Debug.LogWarning("[SampanSeat] Không tìm thấy XROrigin hoặc Player Rig để lên xuồng!");
                return false;
            }

            playerRig = player;
            originalPlayerParent = playerRig.transform.parent;

            // 1. Tắt ContinuousMoveProvider của người chơi
            cachedMoveProvider = playerRig.GetComponentInChildren<ContinuousMoveProvider>();
            if (cachedMoveProvider != null)
            {
                cachedMoveProvider.enabled = false;
                Debug.Log("[SampanSeat] Đã khóa ContinuousMoveProvider khi ngồi trên xuồng.");
            }

            // 2. Neo người chơi vào seatAnchor
            playerRig.transform.SetParent(seatAnchor);
            playerRig.transform.localPosition = Vector3.zero;
            playerRig.transform.localRotation = Quaternion.identity;

            isSeated = true;
            OnSeatedStateChanged?.Invoke(true);
            Debug.Log("<b>[SampanSeat]</b> Người chơi đã lên ngồi trên xuồng ba lá an toàn.");
            return true;
        }

        /// <summary>
        /// Cho người chơi rời xuồng, đưa lên bờ an toàn và phục hồi di chuyển.
        /// </summary>
        public bool Dismount()
        {
            if (!isSeated || playerRig == null) return false;

            // 1. Gỡ parent khỏi xuồng
            playerRig.transform.SetParent(originalPlayerParent);

            // 2. Tìm điểm tiếp đất an toàn trên bờ
            Vector3 safeLandingPos = CalculateSafeDismountPosition();
            playerRig.transform.position = safeLandingPos;

            // 3. Phục hồi di chuyển
            if (cachedMoveProvider != null)
            {
                cachedMoveProvider.enabled = true;
                Debug.Log("[SampanSeat] Đã phục hồi ContinuousMoveProvider sau khi rời xuồng.");
            }

            isSeated = false;
            playerRig = null;
            OnSeatedStateChanged?.Invoke(false);
            Debug.Log("<b>[SampanSeat]</b> Người chơi đã rời xuồng ba lá lên bờ.");
            return true;
        }

        private Vector3 CalculateSafeDismountPosition()
        {
            if (dismountPoint != null)
            {
                return dismountPoint.position;
            }

            // Raycast sang 2 bên mạn thuyền tìm bờ hoặc sàn cầu gỗ
            Vector3[] checkDirs = new Vector3[] { transform.right, -transform.right, -transform.forward };

            foreach (Vector3 dir in checkDirs)
            {
                Vector3 rayOrigin = transform.position + Vector3.up * 1.5f + dir * 1.5f;
                if (Physics.Raycast(rayOrigin, Vector3.down, out RaycastHit hit, dismountRaycastDistance))
                {
                    // Tránh tiếp đất xuống nước
                    if (hit.point.y > 99.2f)
                    {
                        return hit.point + Vector3.up * 0.1f;
                    }
                }
            }

            // Fallback: bước lên bờ bên phải xuồng
            return transform.position + transform.right * 1.8f + Vector3.up * 0.5f;
        }

        private GameObject ResolvePlayerRig(IXRActivateInteractor interactor)
        {
            if (interactor != null && interactor.transform != null)
            {
                XROrigin origin = interactor.transform.GetComponentInParent<XROrigin>();
                if (origin != null) return origin.gameObject;
            }

            return FindPlayerRigInScene();
        }

        private GameObject FindPlayerRigInScene()
        {
            XROrigin origin = UnityEngine.Object.FindFirstObjectByType<XROrigin>();
            if (origin != null) return origin.gameObject;

            Camera mainCam = Camera.main;
            if (mainCam != null && mainCam.transform.parent != null)
            {
                return mainCam.transform.parent.gameObject;
            }

            return null;
        }
    }
}

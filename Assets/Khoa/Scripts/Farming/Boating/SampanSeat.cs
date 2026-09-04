using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Movement;
using Unity.XR.CoreUtils;
using Khoa.Farming.Mounting;

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
        [Min(0.5f)] public float maxMountDistance = 2.5f;
        public LayerMask dismountSurfaceMask = ~0;

        [Header("Tương tác lên / xuống xuồng")]
        public XRSimpleInteractable mountInteractable;
        public XRSimpleInteractable dismountInteractable;

        [Header("Tự động gắn hai tay vào mái chèo")]
        public XRGrabInteractable leftOar;
        public XRGrabInteractable rightOar;

        [Header("Trạng thái (Read-Only)")]
        [SerializeField] private bool isSeated = false;
        [SerializeField] private GameObject playerRig;

        public bool IsSeated => isSeated;

        public event Action<bool> OnSeatedStateChanged;

        private XRPlayerMountState mountState;
        private XRBaseInteractor attachedLeftHand;
        private XRBaseInteractor attachedRightHand;

        private void Awake()
        {
            if (seatAnchor == null) seatAnchor = transform;

            if (mountInteractable != null)
            {
                mountInteractable.activated.AddListener(OnMountActivated);
                mountInteractable.selectEntered.AddListener(OnMountSelected);
            }

            if (dismountInteractable != null)
            {
                dismountInteractable.activated.AddListener(OnDismountActivated);
                dismountInteractable.selectEntered.AddListener(OnDismountSelected);
            }
        }

        private void OnDestroy()
        {
            if (mountInteractable != null)
            {
                mountInteractable.activated.RemoveListener(OnMountActivated);
                mountInteractable.selectEntered.RemoveListener(OnMountSelected);
            }

            if (dismountInteractable != null)
            {
                dismountInteractable.activated.RemoveListener(OnDismountActivated);
                dismountInteractable.selectEntered.RemoveListener(OnDismountSelected);
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

        private void OnMountSelected(SelectEnterEventArgs args)
        {
            if (!isSeated) Mount(XRMountCoordinator.ResolveRig(args.interactorObject != null ? args.interactorObject.transform : null));
        }

        private void OnDismountSelected(SelectEnterEventArgs args)
        {
            if (isSeated) Dismount();
        }

        /// <summary>
        /// Cho người chơi lên xuồng và neo giữ vào ghế.
        /// </summary>
        public bool Mount(GameObject player)
        {
            if (isSeated) return false;

            if (player == null)
            {
                player = XRMountCoordinator.ResolveRig();
            }

            if (player == null)
            {
                Debug.LogWarning("[SampanSeat] Không tìm thấy XROrigin hoặc Player Rig để lên xuồng!");
                return false;
            }

            Camera head = player.GetComponentInChildren<Camera>(true);
            Vector3 playerPosition = head != null ? head.transform.position : player.transform.position;
            if (Vector3.Distance(playerPosition, seatAnchor.position) > maxMountDistance)
            {
                Debug.LogWarning("[SampanSeat] Người chơi đang ở quá xa xuồng để lên.");
                return false;
            }
            if (!XRMountCoordinator.TryAcquire(player, this))
            {
                Debug.LogWarning("[SampanSeat] Người chơi đang điều khiển phương tiện khác.");
                return false;
            }

            playerRig = player;
            mountState = new XRPlayerMountState(playerRig);
            mountState.Attach(seatAnchor);

            isSeated = true;
            StartCoroutine(AttachHandsAtEndOfFrame());
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

            Vector3 safeLandingPos = CalculateSafeDismountPosition();
            ReleaseAttachedOars();
            mountState?.Detach(safeLandingPos, transform.rotation);
            XRMountCoordinator.Release(playerRig, this);

            isSeated = false;
            playerRig = null;
            mountState = null;
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
                if (Physics.Raycast(rayOrigin, Vector3.down, out RaycastHit hit, dismountRaycastDistance, dismountSurfaceMask, QueryTriggerInteraction.Ignore))
                {
                    if (waterVolume == null || !waterVolume.IsPointSubmerged(hit.point + Vector3.up * 0.15f, out _))
                        return hit.point + Vector3.up * 0.1f;
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
            return XRMountCoordinator.ResolveRig();
        }

        private IEnumerator AttachHandsAtEndOfFrame()
        {
            yield return null;
            if (!isSeated || playerRig == null) yield break;

            if (leftOar == null || rightOar == null)
            {
                SampanPhysics boat = GetComponentInParent<SampanPhysics>();
                if (boat == null) yield break;
                foreach (SampanOar oar in boat.GetComponentsInChildren<SampanOar>(true))
                {
                    XRGrabInteractable grab = oar.GetComponent<XRGrabInteractable>();
                    if (oar.side == OarSide.Left) leftOar = grab;
                    else rightOar = grab;
                }
            }

            XRBaseInteractor leftHand = FindPreferredHand(InteractorHandedness.Left);
            XRBaseInteractor rightHand = FindPreferredHand(InteractorHandedness.Right);
            attachedLeftHand = TryAttachHand(leftHand, leftOar) ? leftHand : null;
            attachedRightHand = TryAttachHand(rightHand, rightOar) ? rightHand : null;
        }

        private XRBaseInteractor FindPreferredHand(InteractorHandedness handedness)
        {
            XRBaseInteractor fallback = null;
            foreach (XRBaseInteractor interactor in playerRig.GetComponentsInChildren<XRBaseInteractor>(true))
            {
                if (!interactor.isActiveAndEnabled || interactor.handedness != handedness) continue;
                if (interactor is XRDirectInteractor) return interactor;
                if (fallback == null) fallback = interactor;
            }
            return fallback;
        }

        private bool TryAttachHand(XRBaseInteractor hand, XRGrabInteractable oar)
        {
            if (hand == null || oar == null || hand.interactionManager == null) return false;
            // Only release this seat's own selection; never discard an unrelated held tool.
            for (int i = hand.interactablesSelected.Count - 1; i >= 0; i--)
            {
                IXRSelectInteractable selected = hand.interactablesSelected[i];
                if (selected == (IXRSelectInteractable)mountInteractable)
                    hand.interactionManager.SelectExit((IXRSelectInteractor)hand, selected);
                else
                    return false;
            }
            hand.interactionManager.SelectEnterUnconditionally((IXRSelectInteractor)hand, (IXRSelectInteractable)oar);
            return oar.isSelected;
        }

        private void ReleaseAttachedOars()
        {
            ReleaseOar(attachedLeftHand, leftOar);
            ReleaseOar(attachedRightHand, rightOar);
            attachedLeftHand = null;
            attachedRightHand = null;
        }

        private static void ReleaseOar(XRBaseInteractor hand, XRGrabInteractable oar)
        {
            if (hand == null || oar == null || hand.interactionManager == null) return;
            foreach (IXRSelectInteractor selector in oar.interactorsSelecting)
            {
                if (selector == (IXRSelectInteractor)hand)
                {
                    hand.interactionManager.SelectExit((IXRSelectInteractor)hand, (IXRSelectInteractable)oar);
                    break;
                }
            }
        }

        private WaterSurfaceVolume waterVolume => GetComponentInParent<SampanPhysics>()?.waterVolume;

        private void OnDisable()
        {
            if (isSeated) Dismount();
        }
    }
}

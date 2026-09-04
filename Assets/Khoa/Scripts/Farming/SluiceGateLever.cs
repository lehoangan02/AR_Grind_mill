using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

namespace Khoa.Farming
{
    /// <summary>
    /// Converts the VR hand position around a fixed pivot into a constrained sluice-gate opening.
    /// The grabbed handle never follows the interactor directly, so it cannot detach from the gate.
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class SluiceGateLever : MonoBehaviour
    {
        [Tooltip("Gate controlled by this lever.")]
        public SluiceGate sluiceGate;

        [Tooltip("Grab interactable placed on the visible handle below this pivot.")]
        public XRGrabInteractable grabInteractable;

        [Range(0f, 0.25f)]
        [Tooltip("Release this close to either endpoint to snap fully open or closed.")]
        public float endpointSnapThreshold = 0.08f;

        private IXRSelectInteractor selectingInteractor;

        private void Awake()
        {
            ResolveReferences();
            ConfigureConstrainedGrab();
        }

        private void OnEnable()
        {
            ResolveReferences();
            if (grabInteractable == null)
            {
                return;
            }

            grabInteractable.selectEntered.AddListener(OnSelectEntered);
            grabInteractable.selectExited.AddListener(OnSelectExited);
        }

        private void OnDisable()
        {
            if (grabInteractable != null)
            {
                grabInteractable.selectEntered.RemoveListener(OnSelectEntered);
                grabInteractable.selectExited.RemoveListener(OnSelectExited);
            }

            selectingInteractor = null;
        }

        private void Update()
        {
            if (selectingInteractor == null || grabInteractable == null)
            {
                return;
            }

            Transform attachTransform = selectingInteractor.GetAttachTransform(grabInteractable);
            if (attachTransform != null)
            {
                ApplyInteractorWorldPosition(attachTransform.position);
            }
        }

        /// <summary>
        /// Projects a world-space hand position onto the configured X-axis lever arc.
        /// This method is also useful for non-XR input adapters.
        /// </summary>
        public void ApplyInteractorWorldPosition(Vector3 worldPosition)
        {
            if (sluiceGate == null)
            {
                return;
            }

            Transform pivotParent = transform.parent;
            Vector3 parentSpacePosition = pivotParent != null
                ? pivotParent.InverseTransformPoint(worldPosition)
                : worldPosition;
            Vector3 directionFromPivot = parentSpacePosition - transform.localPosition;
            if (directionFromPivot.y * directionFromPivot.y + directionFromPivot.z * directionFromPivot.z < 0.0001f)
            {
                return;
            }

            float handAngle = Mathf.Atan2(directionFromPivot.z, directionFromPivot.y) * Mathf.Rad2Deg;
            float openAmount = CalculateOpenAmount(
                handAngle,
                sluiceGate.leverClosedRotation.x,
                sluiceGate.leverOpenRotation.x);
            sluiceGate.SetOpenAmount(openAmount);
        }

        /// <summary>
        /// Maps an angle to the shortest configured closed-to-open arc and clamps it to that arc.
        /// </summary>
        public static float CalculateOpenAmount(float angle, float closedAngle, float openAngle)
        {
            float arc = Mathf.DeltaAngle(closedAngle, openAngle);
            if (Mathf.Abs(arc) < 0.001f)
            {
                return 0f;
            }

            return Mathf.Clamp01(Mathf.DeltaAngle(closedAngle, angle) / arc);
        }

        private void OnSelectEntered(SelectEnterEventArgs args)
        {
            selectingInteractor = args.interactorObject;
            Transform attachTransform = selectingInteractor.GetAttachTransform(grabInteractable);
            if (attachTransform != null)
            {
                ApplyInteractorWorldPosition(attachTransform.position);
            }
        }

        private void OnSelectExited(SelectExitEventArgs args)
        {
            if (selectingInteractor == args.interactorObject)
            {
                selectingInteractor = null;
            }

            SnapToEndpointWhenClose();
        }

        private void SnapToEndpointWhenClose()
        {
            if (sluiceGate == null)
            {
                return;
            }

            float threshold = Mathf.Clamp(endpointSnapThreshold, 0f, 0.25f);
            if (sluiceGate.OpenAmount <= threshold)
            {
                sluiceGate.SetOpenAmount(0f);
            }
            else if (sluiceGate.OpenAmount >= 1f - threshold)
            {
                sluiceGate.SetOpenAmount(1f);
            }
        }

        private void ResolveReferences()
        {
            if (sluiceGate == null)
            {
                sluiceGate = GetComponentInParent<SluiceGate>();
            }

            if (grabInteractable == null)
            {
                grabInteractable = GetComponentInChildren<XRGrabInteractable>(true);
            }
        }

        private void ConfigureConstrainedGrab()
        {
            if (grabInteractable == null)
            {
                return;
            }

            grabInteractable.trackPosition = false;
            grabInteractable.trackRotation = false;
            grabInteractable.trackScale = false;
            grabInteractable.throwOnDetach = false;

            Rigidbody body = grabInteractable.GetComponent<Rigidbody>();
            if (body != null)
            {
                body.isKinematic = true;
                body.useGravity = false;
                body.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            }
        }
    }
}

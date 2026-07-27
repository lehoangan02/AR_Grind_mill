using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace ithappy.Animals_FREE
{
    [RequireComponent(typeof(CreatureMover))]
    public class MovePlayerInput : MonoBehaviour
    {
        [Header("Character")]
        [SerializeField]
        private string m_HorizontalAxis = "Horizontal";
        [SerializeField]
        private string m_VerticalAxis = "Vertical";
        [SerializeField]
        private string m_JumpButton = "Jump";
        [SerializeField]
        private KeyCode m_RunKey = KeyCode.LeftShift;

        [Header("Camera")]
        [SerializeField]
        private PlayerCamera m_Camera;
        [SerializeField]
        private string m_MouseX = "Mouse X";
        [SerializeField]
        private string m_MouseY = "Mouse Y";
        [SerializeField]
        private string m_MouseScroll = "Mouse ScrollWheel";

        private CreatureMover m_Mover;

        private Vector2 m_Axis;
        private bool m_IsRun;
        private bool m_IsJump;

        private Vector3 m_Target;
        private Vector2 m_MouseDelta;
        private float m_Scroll;

        private void Awake()
        {
            m_Mover = GetComponent<CreatureMover>();
        }

        private void Update()
        {
            GatherInput();
            SetInput();
        }

        public void GatherInput()
        {
#if ENABLE_INPUT_SYSTEM
            float h = 0f;
            float v = 0f;
            bool run = false;
            bool jump = false;
            Vector2 mouseDelta = Vector2.zero;
            float scroll = 0f;

            if (Keyboard.current != null)
            {
                if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) h -= 1f;
                if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) h += 1f;
                if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) v -= 1f;
                if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) v += 1f;
                
                run = Keyboard.current.leftShiftKey.isPressed || Keyboard.current.rightShiftKey.isPressed;
                jump = Keyboard.current.spaceKey.isPressed;
            }

            if (Mouse.current != null)
            {
                // New Input System mouse delta can be quite large compared to legacy, scaling it down.
                mouseDelta = Mouse.current.delta.ReadValue() * 0.05f; 
                scroll = Mouse.current.scroll.ReadValue().y * 0.001f;
            }

            m_Axis = new Vector2(h, v);
            m_IsRun = run;
            m_IsJump = jump;
            m_Target = (m_Camera == null) ? Vector3.zero : m_Camera.Target;
            m_MouseDelta = mouseDelta;
            m_Scroll = scroll;
#else
            m_Axis = new Vector2(Input.GetAxis(m_HorizontalAxis), Input.GetAxis(m_VerticalAxis));
            m_IsRun = Input.GetKey(m_RunKey);
            m_IsJump = Input.GetButton(m_JumpButton);

            m_Target = (m_Camera == null) ? Vector3.zero : m_Camera.Target;
            m_MouseDelta = new Vector2(Input.GetAxis(m_MouseX), Input.GetAxis(m_MouseY));
            m_Scroll = Input.GetAxis(m_MouseScroll);
#endif
        }

        public void BindMover(CreatureMover mover)
        {
            m_Mover = mover;
        }

        public void SetInput()
        {
            if (m_Mover != null)
            {
                m_Mover.SetInput(in m_Axis, in m_Target, in m_IsRun, m_IsJump);
            }

            if (m_Camera != null)
            {
                m_Camera.SetInput(in m_MouseDelta, m_Scroll);
            }
        }
    }
}
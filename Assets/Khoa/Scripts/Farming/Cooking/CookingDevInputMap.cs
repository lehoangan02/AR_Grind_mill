using UnityEngine.InputSystem;

namespace Khoa.Farming
{
    /// <summary>
    /// Single source of truth for direct keyboard shortcuts used during desktop development.
    /// Physical VR interactions still use the XRI Select (Grip) and Activate (Trigger) actions.
    /// </summary>
    public static class CookingDevInputMap
    {
        public const Key MillCounterClockwisePrimary = Key.A;
        public const Key MillCounterClockwiseAlternate = Key.LeftArrow;
        public const Key MillClockwisePrimary = Key.D;
        public const Key MillClockwiseAlternate = Key.RightArrow;
        public const Key MillClockwiseLegacy = Key.Z;
        public const Key MillClockwiseAccessibility = Key.UpArrow;
        public const Key ExtractWashedRice = Key.Q;
        public const Key ServeCookedRice = Key.E;

        public static float ReadMillDirection(Keyboard keyboard)
        {
            if (keyboard == null) return 0f;

            float direction = 0f;
            if (IsPressed(keyboard, MillCounterClockwisePrimary) ||
                IsPressed(keyboard, MillCounterClockwiseAlternate))
            {
                direction -= 1f;
            }

            if (IsPressed(keyboard, MillClockwisePrimary) ||
                IsPressed(keyboard, MillClockwiseAlternate) ||
                IsPressed(keyboard, MillClockwiseLegacy) ||
                IsPressed(keyboard, MillClockwiseAccessibility))
            {
                direction += 1f;
            }

            return direction;
        }

        public static bool WasExtractWashedRicePressed(Keyboard keyboard)
        {
            return WasPressedThisFrame(keyboard, ExtractWashedRice);
        }

        public static bool WasServeCookedRicePressed(Keyboard keyboard)
        {
            return WasPressedThisFrame(keyboard, ServeCookedRice);
        }

        private static bool IsPressed(Keyboard keyboard, Key key)
        {
            return keyboard[key].isPressed;
        }

        private static bool WasPressedThisFrame(Keyboard keyboard, Key key)
        {
            return keyboard != null && keyboard[key].wasPressedThisFrame;
        }
    }
}

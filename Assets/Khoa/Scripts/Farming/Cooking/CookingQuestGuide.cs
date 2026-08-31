using System;
using TMPro;
using UnityEngine;

namespace Khoa.Farming
{
    /// <summary>
    /// Các bước hướng dẫn tuần tự trong chu trình Xay gạo & Nấu cơm.
    /// </summary>
    public enum CookingQuestStep
    {
        Step1_PourPaddy,        // Bước 1: Đổ thóc vào cối xay
        Step2_GrindMill,        // Bước 2: Quay cần cối xay thành gạo trắng
        Step3_TakeWhiteRice,    // Bước 3: Nhặt thúng gạo trắng mang sang thau vo gạo
        Step4_ScoopWater,       // Bước 4: Múc nước từ chum đổ vào thau gạo
        Step5_WashAndDrain,     // Bước 5: Dùng tay vo gạo và nghiêng thau chắt nước
        Step6_IgniteStove,      // Bước 6: Xếp củi vào bếp và châm lửa
        Step7_CookPot,          // Bước 7: Cho gạo vo + nước vào nồi gang, đậy nắp đặt lên bếp
        Step8_ServeCookedRice,  // Bước 8: Cơm chín thơm dẻo! Mở nắp xới cơm ra bát
        Completed               // Đã hoàn thành toàn bộ chuỗi ẩm thực
    }

    /// <summary>
    /// Bảng hướng dẫn nhiệm vụ 3D nổi trên không (World-space UI Guide) khu vực Bếp & Cối xay gạo.
    /// Tự động lắng nghe các sự kiện từ GrindMillStation, RiceWashingPot, WoodStove, CookingPot để cập nhật thời gian thực.
    /// </summary>
    public class CookingQuestGuide : MonoBehaviour
    {
        [Header("References")]
        public GrindMillStation grindMill;
        public RiceWashingPot washingPot;
        public WoodStove woodStove;
        public CookingPot cookingPot;

        [Header("UI Display")]
        [Tooltip("Text 3D hiển thị nội dung bước hướng dẫn")]
        public TextMeshPro stepText;

        [Tooltip("Text hiển thị tiến độ %")]
        public TextMeshPro progressText;

        [Header("Current Progress")]
        public CookingQuestStep currentStep = CookingQuestStep.Step1_PourPaddy;

        // Events
        public event Action<CookingQuestStep> OnStepChanged;

        private void Start()
        {
            SubscribeEvents();
            UpdateGuideUI();
        }

        private void OnDestroy()
        {
            UnsubscribeEvents();
        }

        private void SubscribeEvents()
        {
            if (grindMill != null)
            {
                grindMill.OnStateChanged += HandleMillStateChanged;
                grindMill.OnProgressChanged += HandleMillProgressChanged;
                grindMill.OnMillingCompleted += HandleMillingCompleted;
            }

            if (washingPot != null)
            {
                washingPot.OnStateChanged += HandleWashingStateChanged;
                washingPot.OnWashProgressChanged += HandleWashProgressChanged;
                washingPot.OnRiceWashedCompleted += HandleRiceWashedCompleted;
            }

            if (woodStove != null)
            {
                woodStove.OnFireStateChanged += HandleStoveFireChanged;
            }

            if (cookingPot != null)
            {
                cookingPot.OnCookingStateChanged += HandleCookingStateChanged;
                cookingPot.OnCookingProgressChanged += HandleCookingProgressChanged;
                cookingPot.OnRiceServed += HandleRiceServed;
            }
        }

        private void UnsubscribeEvents()
        {
            if (grindMill != null)
            {
                grindMill.OnStateChanged -= HandleMillStateChanged;
                grindMill.OnProgressChanged -= HandleMillProgressChanged;
                grindMill.OnMillingCompleted -= HandleMillingCompleted;
            }

            if (washingPot != null)
            {
                washingPot.OnStateChanged -= HandleWashingStateChanged;
                washingPot.OnWashProgressChanged -= HandleWashProgressChanged;
                washingPot.OnRiceWashedCompleted -= HandleRiceWashedCompleted;
            }

            if (woodStove != null)
            {
                woodStove.OnFireStateChanged -= HandleStoveFireChanged;
            }

            if (cookingPot != null)
            {
                cookingPot.OnCookingStateChanged -= HandleCookingStateChanged;
                cookingPot.OnCookingProgressChanged -= HandleCookingProgressChanged;
                cookingPot.OnRiceServed -= HandleRiceServed;
            }
        }

        public void SetStep(CookingQuestStep newStep)
        {
            currentStep = newStep;
            UpdateGuideUI();
            OnStepChanged?.Invoke(currentStep);
        }

        private void HandleMillStateChanged(GrindMillState state)
        {
            if (state == GrindMillState.ReadyToGrind && currentStep == CookingQuestStep.Step1_PourPaddy)
            {
                SetStep(CookingQuestStep.Step2_GrindMill);
            }
        }

        private void HandleMillProgressChanged(float progress)
        {
            if (currentStep == CookingQuestStep.Step2_GrindMill && progressText != null)
            {
                progressText.text = $"Tiến độ xay: {progress:F0}%";
            }
        }

        private void HandleMillingCompleted(WhiteRiceItem rice)
        {
            SetStep(CookingQuestStep.Step3_TakeWhiteRice);
        }

        private void HandleWashingStateChanged(RiceWashingState state)
        {
            if (state == RiceWashingState.HasRice && currentStep == CookingQuestStep.Step3_TakeWhiteRice)
            {
                SetStep(CookingQuestStep.Step4_ScoopWater);
            }
            else if (state == RiceWashingState.HasRiceAndWater && currentStep == CookingQuestStep.Step4_ScoopWater)
            {
                SetStep(CookingQuestStep.Step5_WashAndDrain);
            }
            else if (state == RiceWashingState.WashedRiceReady && currentStep == CookingQuestStep.Step5_WashAndDrain)
            {
                SetStep(CookingQuestStep.Step6_IgniteStove);
            }
        }

        private void HandleWashProgressChanged(float progress)
        {
            if (currentStep == CookingQuestStep.Step5_WashAndDrain && progressText != null)
            {
                progressText.text = $"Độ sạch của gạo: {progress:F0}% (Khuấy rồi nghiêng thau chắt nước)";
            }
        }

        private void HandleRiceWashedCompleted(WhiteRiceItem washedRice)
        {
            if (currentStep < CookingQuestStep.Step6_IgniteStove)
            {
                SetStep(CookingQuestStep.Step6_IgniteStove);
            }
        }

        private void HandleStoveFireChanged(bool isBurning)
        {
            if (isBurning && (currentStep == CookingQuestStep.Step6_IgniteStove || currentStep < CookingQuestStep.Step7_CookPot))
            {
                SetStep(CookingQuestStep.Step7_CookPot);
            }
        }

        private void HandleCookingStateChanged(CookingState state)
        {
            if (state == CookingState.Cooked)
            {
                SetStep(CookingQuestStep.Step8_ServeCookedRice);
            }
        }

        private void HandleCookingProgressChanged(float progressRatio)
        {
            if (currentStep == CookingQuestStep.Step7_CookPot && progressText != null)
            {
                progressText.text = $"Cơm đang sôi đun: {(progressRatio * 100f):F0}%";
            }
        }

        private void HandleRiceServed(CookedRiceBowl bowl)
        {
            SetStep(CookingQuestStep.Completed);
        }

        public void UpdateGuideUI()
        {
            if (stepText == null) return;

            switch (currentStep)
            {
                case CookingQuestStep.Step1_PourPaddy:
                    stepText.text = "🌾 <b>Bước 1:</b> Đổ giỏ thóc vàng vào phễu cối xay gạo.";
                    if (progressText != null) progressText.text = "Chờ đổ thóc...";
                    break;
                case CookingQuestStep.Step2_GrindMill:
                    stepText.text = "⚙️ <b>Bước 2:</b> Nắm cần quay cối xay lúa thành gạo trắng.";
                    break;
                case CookingQuestStep.Step3_TakeWhiteRice:
                    stepText.text = "🧺 <b>Bước 3:</b> Nhặt thúng gạo trắng sạch mang sang thau vo gạo.";
                    if (progressText != null) progressText.text = "Xay hoàn tất 100%!";
                    break;
                case CookingQuestStep.Step4_ScoopWater:
                    stepText.text = "🥥 <b>Bước 4:</b> Cầm gáo múc nước từ chum đổ vào thau gạo.";
                    if (progressText != null) progressText.text = "Cần thêm nước để vo gạo";
                    break;
                case CookingQuestStep.Step5_WashAndDrain:
                    stepText.text = "✋ <b>Bước 5:</b> Dùng tay khuấy vo gạo cho sạch rồi nghiêng thau chắt nước.";
                    break;
                case CookingQuestStep.Step6_IgniteStove:
                    stepText.text = "🪵 <b>Bước 6:</b> Xếp củi vào bếp củi và quẹt que diêm nhóm lửa.";
                    if (progressText != null) progressText.text = "Bếp củi chưa bén lửa";
                    break;
                case CookingQuestStep.Step7_CookPot:
                    stepText.text = "🍲 <b>Bước 7:</b> Cho gạo vo + nước vào nồi gang, đậy nắp đặt lên kiềng bếp.";
                    break;
                case CookingQuestStep.Step8_ServeCookedRice:
                    stepText.text = "🍚 <b>Bước 8:</b> Cơm gang đã chín tới! Mở nắp vung xới cơm ra bát.";
                    if (progressText != null) progressText.text = "✨ Cơm dẻo thơm lừng!";
                    break;
                case CookingQuestStep.Completed:
                    stepText.text = "🎉 <b>HOÀN THÀNH:</b> Bát cơm trắng thơm dẻo miền Tây đã sẵn sàng!";
                    if (progressText != null) progressText.text = "Thưởng thức thành quả nông nghiệp & ẩm thực!";
                    break;
            }
        }
    }
}

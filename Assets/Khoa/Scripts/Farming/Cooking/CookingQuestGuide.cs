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
        Step6_TakeWashedRice,   // Bước 6: Lấy gạo đã vo thật ra khỏi thau
        Step7_IgniteStove,      // Bước 7: Xếp củi vào bếp và châm lửa
        Step8_CookPot,          // Bước 8: Cho gạo vo + nước vào nồi gang, đậy nắp đặt lên bếp
        Step9_ServeCookedRice,  // Bước 9: Mở nắp và dùng muôi xới cơm
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
        [Tooltip("Billboard yaw follows the active XR camera without tilting toward the player's head.")]
        public bool faceActiveCamera = true;

        // Events
        public event Action<CookingQuestStep> OnStepChanged;

        private bool isSubscribed;

        private void OnEnable()
        {
            SubscribeEvents();
            UpdateGuideUI();
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void LateUpdate()
        {
            if (!faceActiveCamera || Camera.main == null) return;
            Vector3 direction = transform.position - Camera.main.transform.position;
            direction.y = 0f;
            if (direction.sqrMagnitude > 0.001f)
            {
                transform.rotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
            }
        }

        private void SubscribeEvents()
        {
            if (isSubscribed) return;
            isSubscribed = true;
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
            if (!isSubscribed) return;
            isSubscribed = false;
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
                SetStep(CookingQuestStep.Step6_TakeWashedRice);
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
            if (washedRice != null && washedRice.isWashed && currentStep == CookingQuestStep.Step6_TakeWashedRice)
            {
                SetStep(CookingQuestStep.Step7_IgniteStove);
            }
        }

        private void HandleStoveFireChanged(bool isBurning)
        {
            if (isBurning && currentStep == CookingQuestStep.Step7_IgniteStove)
            {
                SetStep(CookingQuestStep.Step8_CookPot);
            }
        }

        private void HandleCookingStateChanged(CookingState state)
        {
            if (state == CookingState.Cooked)
            {
                SetStep(CookingQuestStep.Step9_ServeCookedRice);
            }
        }

        private void HandleCookingProgressChanged(float progressRatio)
        {
            if (currentStep == CookingQuestStep.Step8_CookPot && progressText != null)
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
                    stepText.text = "<b>Bước 1:</b> Đổ giỏ thóc đầy vào phễu cối xay.";
                    if (progressText != null) progressText.text = "Chờ đổ thóc...";
                    break;
                case CookingQuestStep.Step2_GrindMill:
                    stepText.text = "<b>Bước 2:</b> Grip để nắm cần, quay đều quanh trục cối.";
                    break;
                case CookingQuestStep.Step3_TakeWhiteRice:
                    stepText.text = "<b>Bước 3:</b> Grip nhặt gạo trắng và đổ vào thau vo.";
                    if (progressText != null) progressText.text = "Xay hoàn tất 100%!";
                    break;
                case CookingQuestStep.Step4_ScoopWater:
                    stepText.text = "<b>Bước 4:</b> Nhúng gáo vào chum, nghiêng miệng gáo về thau.";
                    if (progressText != null) progressText.text = "Cần thêm nước để vo gạo";
                    break;
                case CookingQuestStep.Step5_WashAndDrain:
                    stepText.text = "<b>Bước 5:</b> Cầm que vo, khuấy vòng tròn đến 100%, rồi nghiêng thau chắt nước.";
                    break;
                case CookingQuestStep.Step6_TakeWashedRice:
                    stepText.text = "<b>Bước 6:</b> Grip cầm muôi chuyển gạo, Trigger để lấy gạo đã ráo.";
                    if (progressText != null) progressText.text = "Dev simulator: chạm thau và nhấn Q";
                    break;
                case CookingQuestStep.Step7_IgniteStove:
                    stepText.text = "<b>Bước 7:</b> Cho củi vào bếp, quẹt diêm đủ nhanh trên miếng striker.";
                    if (progressText != null) progressText.text = "Bếp củi chưa bén lửa";
                    break;
                case CookingQuestStep.Step8_CookPot:
                    stepText.text = "<b>Bước 8:</b> Cho gạo vo + đủ nước vào nồi, đậy nắp và đặt lên bếp.";
                    break;
                case CookingQuestStep.Step9_ServeCookedRice:
                    stepText.text = "<b>Bước 9:</b> Mở nắp, Grip cầm muôi và Trigger để xới cơm.";
                    if (progressText != null) progressText.text = "Dev simulator: đưa muôi vào nồi và nhấn E";
                    break;
                case CookingQuestStep.Completed:
                    stepText.text = "<b>HOÀN THÀNH:</b> Bát cơm đã được xới ra thật.";
                    if (progressText != null) progressText.text = "Thưởng thức thành quả nông nghiệp & ẩm thực!";
                    break;
            }
        }
    }
}

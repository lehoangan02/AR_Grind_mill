using UnityEngine;
using TMPro;

namespace Khoa.Farming
{
    /// <summary>
    /// Bảng hướng dẫn nhiệm vụ Chuồng trại & Ủ phân bón sinh học trong không gian 3D.
    /// Cập nhật thời gian thực giúp người chơi đeo kính VR nắm bắt từng bước.
    /// </summary>
    [DisallowMultipleComponent]
    public class BarnCompostQuestGuide : MonoBehaviour
    {
        [Header("Tham chiếu trạm liên quan")]
        public BarnManureSource[] manureSources;
        public ManureShovel shovel;
        public CompostPile compostPile;

        [Header("UI TextMeshPro")]
        public TextMeshPro questTitleText;
        public TextMeshPro stepDetailText;

        private void Update()
        {
            UpdateGuideBillboard();
        }

        private void UpdateGuideBillboard()
        {
            if (stepDetailText == null) return;

            if (compostPile != null && compostPile.CurrentState == CompostState.Ready)
            {
                stepDetailText.text = "<color=green><b>BƯỚC 4: BÓN LÓT RUỘNG LÚA</b></color>\n" +
                                      "- Cầm phân hoai mục thành phẩm trên mặt đất.\n" +
                                      "- Đem bón vào ô ruộng đã cày (Tilled).\n" +
                                      "- Cây lúa cấy tiếp theo sẽ tăng trưởng 1.5x!";
                return;
            }

            if (compostPile != null && compostPile.CurrentState == CompostState.Composting)
            {
                int remain = Mathf.CeilToInt(compostPile.CompostTimer);
                stepDetailText.text = "<color=#FFA500><b>BƯỚC 3: CHỜ PHÂN Ủ HOAI MỤC</b></color>\n" +
                                      $"- Đống ủ đang lên men vi sinh ({remain}s còn lại).\n" +
                                      "- Nhiệt lượng đang phân hủy chất hữu cơ.\n" +
                                      "- Không thể lấy phân khi chưa chín!";
                return;
            }

            if (shovel != null && shovel.IsFull)
            {
                stepDetailText.text = "<color=yellow><b>BƯỚC 2: TRÚT PHÂN VÀO ĐỐNG Ủ</b></color>\n" +
                                      "- Xẻng đang chứa phân tươi.\n" +
                                      "- Đưa lưỡi xẻng vào đống ủ phân (Compost Pile).\n" +
                                      "- Bấm Trigger (hoặc phím E) để trút phân vào đống ủ.";
                return;
            }

            if (compostPile != null && compostPile.CurrentPortions > 0)
            {
                int needed = compostPile.requiredPortions - compostPile.CurrentPortions;
                stepDetailText.text = $"<color=yellow><b>BƯỚC 1: TIẾP TỤC THU GOM PHÂN ({compostPile.CurrentPortions}/3)</b></color>\n" +
                                      $"- Cần thêm {needed} phần phân tươi nữa.\n" +
                                      "- Đến chuồng trâu, chuồng bò hoặc chuồng heo.\n" +
                                      "- Đưa xẻng vào đống phân và bấm Trigger (hoặc E) để xúc.";
                return;
            }

            stepDetailText.text = "<color=white><b>BƯỚC 1: THU GOM PHÂN TƯƠI</b></color>\n" +
                                  "- Cầm xẻng xúc phân (Grip / XRI Select).\n" +
                                  "- Tìm đống phân tươi tại chuồng trâu, bò, heo.\n" +
                                  "- Đưa lưỡi xẻng vào và bấm Trigger (hoặc phím E) để xúc.";
        }
    }
}

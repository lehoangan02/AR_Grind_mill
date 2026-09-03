using UnityEngine;
using TMPro;

namespace Khoa.Farming.Boating
{
    /// <summary>
    /// Bảng hướng dẫn chèo xuồng ba lá VR trực quan gắn tại bến xuồng.
    /// Giúp người chơi nắm bắt thao tác cầm mái chèo và điều khiển xuồng đi sông ngòi.
    /// </summary>
    [DisallowMultipleComponent]
    public class SampanQuestGuide : MonoBehaviour
    {
        public SampanSeat seat;
        public SampanPhysics sampan;
        public TextMeshPro guideText;

        private void Update()
        {
            if (guideText == null) return;

            if (seat != null && seat.IsSeated)
            {
                guideText.text = "<color=green><b>ĐANG ĐIỀU KHIỂN XUỒNG BA LÁ</b></color>\n" +
                                 "- Dùng <b>Grip</b> để cầm 2 mái chèo ở 2 bên mạn.\n" +
                                 "- Nhúng lưỡi chèo xuống nước và quét về phía sau để đẩy xuồng tiến tới.\n" +
                                 "- Chèo bên phải để rẽ trái, chèo bên trái để rẽ phải.\n" +
                                 "- Bấm <b>Trigger</b> vào tay vịn mạn thuyền để lên bờ.\n" +
                                 "<i>(Dev Editor: Phím W/S tiến lùi, A/D bẻ lái, F xuống xuồng)</i>";
            }
            else
            {
                guideText.text = "<color=yellow><b>HƯỚNG DẪN CHÈO XUỒNG BA LÁ VR</b></color>\n" +
                                 "- Đến gần lòng xuồng ba lá.\n" +
                                 "- Hướng tia chỉ vào ghế và bấm <b>Trigger</b> (hoặc phím F) để lên xuồng.\n" +
                                 "- Khám phá tuyến sông ngòi tới Chợ Nổi và Khu Câu Cá!";
            }
        }
    }
}

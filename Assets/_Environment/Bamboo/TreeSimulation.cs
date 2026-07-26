using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSimulation : MonoBehaviour
{
    [Header("Cài đặt tăng trưởng (Growth Settings)")]
    [Tooltip("Lượng scale tăng lên sau mỗi khoảng thời gian tick (Vd: 0.01)")]
    public float growSpeed = 0.01f; 
    [Tooltip("Thời gian chờ giữa các lần tăng trưởng (giây). Vd: 0.5 là nửa giây nhích 1 lần")]
    public float growTickRate = 0.5f;
    [Tooltip("Giới hạn chiều cao tối đa trục Y để cây không mọc vô tận")]
    public float maxYScale = 5f; 

    [Header("Cài đặt lay động lá (Leaf Sway Settings)")]
    [Tooltip("Tốc độ đung đưa của gió")]
    public float swaySpeed = 2f;
    [Tooltip("Biên độ đung đưa (Góc xoay tối đa)")]
    public float swayAmount = 5f;
    [Tooltip("Từ khóa trong tên object con để nhận diện là lá")]
    public string leafNameKeyword = "leaf";

    // Danh sách lưu trữ các lá và góc xoay ban đầu của chúng
    private List<Transform> leaves = new List<Transform>();
    private List<Quaternion> initialRotations = new List<Quaternion>();

    void Start()
    {
        // Quét toàn bộ các object con (bao gồm cả con của con)
        Transform[] allChildren = GetComponentsInChildren<Transform>();

        foreach (Transform child in allChildren)
        {
            // Bỏ qua chính object cha
            if (child == this.transform) continue;

            // Kiểm tra xem tên object con có chứa từ khoá không (không phân biệt hoa/thường)
            if (child.name.ToLower().Contains(leafNameKeyword.ToLower()))
            {
                leaves.Add(child);
                initialRotations.Add(child.localRotation); // Lưu lại góc xoay gốc để không bị lệch
            }
        }

        Debug.Log($"Đã tìm thấy {leaves.Count} object lá trên cây {gameObject.name}");

        // Bắt đầu quá trình lớn lên từ từ bằng Coroutine
        StartCoroutine(GrowRoutine());
    }

    void Update()
    {
        // Update chỉ chạy hàm lay động lá để chuyển động của lá luôn mượt mà trên từng frame
        SwayLeaves();
    }

    // Coroutine giúp cây lớn lên sau mỗi khoảng thời gian nhất định (nhẹ máy hơn)
    private IEnumerator GrowRoutine()
    {
        // Vòng lặp chạy liên tục cho đến khi cây đạt chiều cao tối đa
        while (transform.localScale.y < maxYScale)
        {
            Vector3 currentScale = transform.localScale;
            currentScale.y += growSpeed;

            // Đảm bảo scale không bị vượt quá mức tối đa
            if (currentScale.y > maxYScale)
            {
                currentScale.y = maxYScale;
            }

            transform.localScale = currentScale;

            // Tạm dừng Coroutine trong 'growTickRate' giây rồi mới chạy tiếp vòng lặp
            yield return new WaitForSeconds(growTickRate);
        }

        Debug.Log($"Cây {gameObject.name} đã đạt chiều cao tối đa!");
    }

    private void SwayLeaves()
    {
        for (int i = 0; i < leaves.Count; i++)
        {
            if (leaves[i] != null)
            {
                // Dùng vị trí của từng lá cộng vào thời gian để tạo độ trễ (offset). 
                // Điều này giúp các lá không lay động đều tăm tắp như robot.
                float timeFactor = (Time.time * swaySpeed) + (leaves[i].position.x + leaves[i].position.y);
                
                // Tính toán góc xoay lay động
                float angle = Mathf.Sin(timeFactor) * swayAmount;

                // Áp dụng góc xoay mới vào trục Z (Đổi sang trục X hoặc Y tùy hướng model lá của bạn)
                leaves[i].localRotation = initialRotations[i] * Quaternion.Euler(0, 0, angle);
            }
        }
    }
}
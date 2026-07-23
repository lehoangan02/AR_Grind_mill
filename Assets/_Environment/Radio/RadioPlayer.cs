using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VRRadioPlayer : MonoBehaviour
{
    [Header("Danh sách bài hát")]
    [Tooltip("Kéo thả các file nhạc vào đây")]
    public AudioClip[] playlist;

    [Header("Giao diện UI")]
    [Tooltip("Kéo thả GameObject chứa Canvas UI hướng dẫn vào đây")]
    public GameObject instructionUI;

    private AudioSource audioSource;
    private int currentTrackIndex = 0;
    private bool isOff = false; 

    // Mảng để lưu vị trí thời gian (giây) của từng bài hát
    private float[] trackTimes;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;

        if (instructionUI != null)
        {
            instructionUI.SetActive(true);
        }

        if (playlist.Length > 0)
        {
            // Khởi tạo mảng có kích thước bằng số lượng bài hát trong playlist
            // Mặc định các giá trị bên trong sẽ là 0
            trackTimes = new float[playlist.Length];

            isOff = false;
            PlayTrack(currentTrackIndex);
        }
        else
        {
            Debug.LogWarning("VR Radio: Chưa có bài nhạc nào trong Playlist!");
        }
    }

    public void InteractToNextTrack()
    {
        if (playlist.Length == 0) return; 

        if (isOff)
        {
            // Bật đài lại
            isOff = false;
            currentTrackIndex = 0;
            PlayTrack(currentTrackIndex);
            return;
        }

        // --- ĐÀI ĐANG BẬT ---
        // 1. Ghi nhớ thời gian của bài hát hiện tại trước khi chuyển đổi
        trackTimes[currentTrackIndex] = audioSource.time;

        if (currentTrackIndex == playlist.Length - 1)
        {
            // Đang ở bài cuối -> Tắt đài
            isOff = true;
            audioSource.Stop(); 
        }
        else
        {
            // Chuyển sang bài tiếp theo
            currentTrackIndex++;
            PlayTrack(currentTrackIndex);
        }
    }

    private void PlayTrack(int index)
    {
        audioSource.clip = playlist[index];
        
        // 2. Phục hồi lại thời gian đã lưu trước đó (nếu mới phát lần đầu, giá trị này là 0)
        audioSource.time = trackTimes[index];
        
        audioSource.Play();
    }
}
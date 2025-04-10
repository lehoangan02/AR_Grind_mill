using UnityEngine;

public class GrindMillAudioManager : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private AudioClip GrindingSound;
    private AudioSource Source;
    [Range(0, 1)]
    public float VolumeRatio;
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        Source = GetComponent<AudioSource>();
        Source.clip = GrindingSound;
        VolumeRatio = 0.15f;
        Source.loop = true;
        Source.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        const float MaxAngularVelocityToVolume = 5;
        Vector3 AngularVelocity = rb.angularVelocity;
        float AngularVelocityY = AngularVelocity.y;
        AngularVelocityY = Mathf.Abs(AngularVelocityY);
        if (AngularVelocityY > 0)
        {
            // Debug.Log("AngularVelocityY: " + AngularVelocityY);
            float Volume = AngularVelocityY / MaxAngularVelocityToVolume;
            Source.volume = Volume * VolumeRatio;
            if (!Source.isPlaying)
            {
                // Debug.Log("Playing sound");
                Source.Play();
            }
        }
        else
        {
            Source.Stop();
        }
    }
}

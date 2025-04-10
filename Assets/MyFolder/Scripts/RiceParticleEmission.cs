using UnityEngine;

public class RiceParticleEmission : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem riceParticleSystem;
    private ParticleSystem.EmissionModule riceEmissionModule;
    private Rigidbody rb;
    public const float maxEmissionRate = 30f; // Maximum emission rate for the rice particles
    public bool isEnabled = false;
    void Start()
    {
        riceEmissionModule = riceParticleSystem.emission;
        rb = GetComponent<Rigidbody>();
        isEnabled = false;
    }

    void Update()
    {
        if (!isEnabled)
        {
            return;
        }
        const float maxAngularVelocity = 7f; // Maximum angular velocity for full emission
        float angularVelocityY = rb.angularVelocity.y;
        angularVelocityY = Mathf.Abs(angularVelocityY);
        angularVelocityY = Mathf.Min(angularVelocityY, maxAngularVelocity);
        float emissionRate = maxEmissionRate * (angularVelocityY / maxAngularVelocity);
        riceEmissionModule.rateOverTime = emissionRate;
    }
    public void SetEmissionRate(float rate)
    {
        if (rate < 0)
        {
            rate = 0;
        }
        riceEmissionModule.rateOverTime = rate;
    }
    public void DisableEmission()
    {
        isEnabled = false;
        riceEmissionModule.rateOverTime = 0; // Stop the emission
        Debug.Log("Emission disabled");
    }
    public void EnableEmission()
    {
        isEnabled = true;
    }
}

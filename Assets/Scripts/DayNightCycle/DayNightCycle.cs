/*
 * DayNightCycle.cs
 *
 * WHAT IT DOES
 *   Drives a day/night cycle for Unity 6 + URP 17 scenes. It rotates the scene's
 *   main Directional Light, modulates its color/intensity, drives the ambient
 *   lighting (Trilight), fog, and the Skybox/Procedural material so the world
 *   transitions smoothly from midnight -> dawn -> noon -> dusk -> midnight.
 *
 * HOW TO USE
 *   Drop the DayNightCycle prefab (or this component) into any scene. On enable
 *   it auto-binds to the scene's first active Directional Light and to the
 *   Skybox/Procedural material (creating a runtime instance if needed). It is a
 *   singleton with DontDestroyOnLoad, so it persists across scene loads and
 *   re-binds to the new scene's light automatically via SceneManager.sceneLoaded.
 *
 * VR PERFORMANCE NOTE
 *   The per-frame hot path (Update -> ApplyState) performs ZERO heap allocations:
 *   only struct math (Vector3/Quaternion/Color) and RenderSettings writes are used.
 *   Expensive Global Illumination / skybox material updates are throttled to ~2 Hz
 *   (every 0.5s) via DynamicGI.UpdateEnvironment() to keep VR frame budgets safe.
 *
 * INDEPENDENCE
 *   The day/night cycle runs independently of FarmingWeatherSystem. Weather
 *   effects and time-of-day lighting do not depend on one another.
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField]
    [Header("Sun")]
    [Tooltip("The main Directional Light that represents the sun. Auto-bound on enable if left null.")]
    private Light sunLight;

    [SerializeField]
    [Header("Cycle")]
    [Tooltip("Length of a full 24h day/night loop in real seconds.")]
    [Min(1f)]
    private float cycleDurationSeconds = 120f;

    [SerializeField]
    [Tooltip("Hour of day (0-24) the cycle starts at. 12 = noon.")]
    [Range(0f, 24f)]
    private float startHour = 12f;

    [SerializeField]
    [Header("Intensity")]
    [Tooltip("Sun light intensity at solar noon.")]
    [Min(0f)]
    private float dayIntensity = 1.0f;

    [SerializeField]
    [Tooltip("Sun light intensity at night (below horizon).")]
    [Min(0f)]
    private float nightIntensity = 0.05f;

    [SerializeField]
    [Tooltip("Yaw rotation offset applied to the sun rotation around world Y axis (degrees). 30 matches MainMenu's existing Directional Light.")]
    private float sunYawDegrees = 30f;

    [SerializeField]
    [Header("Fog")]
    [Tooltip("Enable exponential-squared fog driven by the fog color ramp.")]
    private bool enableFog = true;

    [SerializeField]
    [Tooltip("Exponential-squared fog density.")]
    [Min(0f)]
    private float fogDensity = 0.005f;

    [SerializeField]
    [Header("Behavior")]
    [Tooltip("If true, the cycle advances automatically with time. If false, it holds at currentTimeNormalized.")]
    private bool autoCycle = true;

    [SerializeField]
    [Header("Color Ramps (time 0 = midnight)")]
    [Tooltip("Sun light color over the day. time 0 = midnight, 0.25 = 06:00, 0.5 = noon, 0.75 = 18:00.")]
    private Gradient sunColorGradient = new Gradient();

    [SerializeField]
    [Tooltip("Ambient (sky/equator/ground) color over the day.")]
    private Gradient ambientColorGradient = new Gradient();

    [SerializeField]
    [Tooltip("Fog color over the day.")]
    private Gradient fogColorGradient = new Gradient();

    [SerializeField]
    [Tooltip("Skybox tint color over the day (lighter than sun color).")]
    private Gradient skyTintGradient = new Gradient();

    // ---- Singleton + persistence ----
    private static DayNightCycle Instance;

    // ---- Internal state ----
    private float currentTimeNormalized;
    private float lastSkyboxUpdate = -1f;
    private Material runtimeSkyboxMaterial;

    private static readonly Color s_NightGroundColor = new Color(0.10f, 0.07f, 0.034f, 1f);
    private static readonly Color s_DayGroundColor = new Color(0.40f, 0.40f, 0.40f, 1f);

    void Awake()
    {
        currentTimeNormalized = startHour / 24f;
    }

    void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
            RebindToScene();
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void OnDisable()
    {
        if (Instance == this)
        {
            Instance = null;
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        RebindToScene();
    }

    void Start()
    {
        RebindToScene();
    }

    void RebindToScene()
    {
        // Bind to the first active Directional Light in the scene (Unity 6 API).
        if (sunLight == null)
        {
            sunLight = FindFirstObjectByType<Light>(FindObjectsInactive.Exclude);
        }

        // Ensure a Skybox/Procedural material exists at runtime.
        if (RenderSettings.skybox == null || RenderSettings.skybox.shader == null || RenderSettings.skybox.shader.name != "Skybox/Procedural")
        {
            Shader shader = Shader.Find("Skybox/Procedural");
            if (shader != null)
            {
                runtimeSkyboxMaterial = new Material(shader);
                RenderSettings.skybox = runtimeSkyboxMaterial;
            }
            else
            {
                if (runtimeSkyboxMaterial == null)
                {
                    Debug.LogWarning("[DayNightCycle] Skybox/Procedural shader not found; skybox tinting disabled.");
                }
                runtimeSkyboxMaterial = null;
            }
        }

        if (enableFog)
        {
            RenderSettings.fog = true;
            RenderSettings.fogMode = FogMode.ExponentialSquared;
            RenderSettings.fogColor = fogColorGradient.Evaluate(startHour / 24f);
            RenderSettings.fogDensity = fogDensity;
        }
        else
        {
            RenderSettings.fog = false;
        }
    }

    void Update()
    {
        if (autoCycle)
        {
            currentTimeNormalized = Mathf.Repeat(currentTimeNormalized + Time.deltaTime / cycleDurationSeconds, 1f);
        }
        ApplyState(currentTimeNormalized);
    }

    void ApplyState(float t)
    {
        // Sun position: t=0.25 (06:00) -> east horizon, t=0.5 (12:00) -> overhead, t=0.75 (18:00) -> west horizon, t=0/1 (midnight) -> below.
        float sunAngleDeg = (t - 0.25f) * 360f;
        // Sun altitude on [-1, 1]; above 0 = day, below 0 = night.
        float sunAltitude = -Mathf.Cos(t * 2f * Mathf.PI);

        if (sunLight != null)
        {
            sunLight.transform.localRotation = Quaternion.Euler(sunAngleDeg, sunYawDegrees, 0f);
            sunLight.intensity = EvaluateIntensity(sunAltitude);
            sunLight.color = sunColorGradient.Evaluate(t);
        }

        Color ambientSky = ambientColorGradient.Evaluate(t);
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Trilight;
        RenderSettings.ambientSkyColor = ambientSky;
        RenderSettings.ambientEquatorColor = ambientSky * 0.8f;
        RenderSettings.ambientGroundColor = ambientSky * 0.4f;

        if (enableFog)
        {
            RenderSettings.fog = true;
            RenderSettings.fogMode = FogMode.ExponentialSquared;
            RenderSettings.fogColor = fogColorGradient.Evaluate(t);
            RenderSettings.fogDensity = fogDensity;
        }
        else
        {
            RenderSettings.fog = false;
        }

        // Throttle GI / skybox material updates to ~2 Hz.
        if (Time.unscaledTime - lastSkyboxUpdate > 0.5f)
        {
            lastSkyboxUpdate = Time.unscaledTime;
            ApplySkybox(t, sunAltitude);
            UnityEngine.DynamicGI.UpdateEnvironment();
        }
    }

    float EvaluateIntensity(float sunAltitude)
    {
        if (sunAltitude <= 0f) return nightIntensity;
        float k = sunAltitude * sunAltitude * (3f - 2f * sunAltitude); // smoothstep
        return Mathf.Lerp(nightIntensity, dayIntensity, k);
    }

    void ApplySkybox(float t, float sunAltitude)
    {
        if (runtimeSkyboxMaterial == null) return;
        float dayFactor = Mathf.Clamp01(sunAltitude * 2f); // 0 at horizon, 1 at zenith
        runtimeSkyboxMaterial.SetFloat("_SunSize", 0.04f);
        runtimeSkyboxMaterial.SetInt("_SunDisk", 1); // 0=None, 1=Simple, 2=HighQuality
        runtimeSkyboxMaterial.SetFloat("_AtmosphereThickness", Mathf.Lerp(0.5f, 1.5f, dayFactor));
        runtimeSkyboxMaterial.SetColor("_SkyTint", skyTintGradient.Evaluate(t));
        runtimeSkyboxMaterial.SetColor("_GroundColor", Color.Lerp(s_NightGroundColor, s_DayGroundColor, dayFactor));
        runtimeSkyboxMaterial.SetFloat("_Exposure", Mathf.Lerp(0.2f, 1.3f, dayFactor));
    }

    void Reset()
    {
        PopulateDefaultGradients();
    }

    void OnValidate()
    {
        if (sunColorGradient == null || sunColorGradient.colorKeys == null || sunColorGradient.colorKeys.Length == 0)
        {
            PopulateDefaultGradients();
        }
    }

    void PopulateDefaultGradients()
    {
        GradientColorKey[] sunColorKeys = new GradientColorKey[]
        {
            new GradientColorKey(new Color(0.05f, 0.08f, 0.20f, 1.0f), 0.0f),
            new GradientColorKey(new Color(1.00f, 0.55f, 0.20f, 1.0f), 0.20f),
            new GradientColorKey(new Color(1.00f, 0.95f, 0.85f, 1.0f), 0.25f),
            new GradientColorKey(new Color(1.00f, 0.95f, 0.85f, 1.0f), 0.75f),
            new GradientColorKey(new Color(1.00f, 0.55f, 0.20f, 1.0f), 0.80f),
            new GradientColorKey(new Color(0.05f, 0.08f, 0.20f, 1.0f), 1.0f),
        };
        GradientColorKey[] ambientColorKeys = new GradientColorKey[]
        {
            new GradientColorKey(new Color(0.04f, 0.06f, 0.15f, 1.0f), 0.0f),
            new GradientColorKey(new Color(0.50f, 0.30f, 0.15f, 1.0f), 0.20f),
            new GradientColorKey(new Color(0.55f, 0.58f, 0.65f, 1.0f), 0.25f),
            new GradientColorKey(new Color(0.55f, 0.58f, 0.65f, 1.0f), 0.75f),
            new GradientColorKey(new Color(0.50f, 0.30f, 0.15f, 1.0f), 0.80f),
            new GradientColorKey(new Color(0.04f, 0.06f, 0.15f, 1.0f), 1.0f),
        };
        GradientColorKey[] fogColorKeys = new GradientColorKey[]
        {
            new GradientColorKey(new Color(0.02f, 0.03f, 0.08f, 1.0f), 0.0f),
            new GradientColorKey(new Color(0.80f, 0.40f, 0.20f, 1.0f), 0.20f),
            new GradientColorKey(new Color(0.75f, 0.80f, 0.90f, 1.0f), 0.25f),
            new GradientColorKey(new Color(0.75f, 0.80f, 0.90f, 1.0f), 0.75f),
            new GradientColorKey(new Color(0.80f, 0.40f, 0.20f, 1.0f), 0.80f),
            new GradientColorKey(new Color(0.02f, 0.03f, 0.08f, 1.0f), 1.0f),
        };
        GradientColorKey[] skyTintColorKeys = new GradientColorKey[]
        {
            new GradientColorKey(new Color(0.20f, 0.20f, 0.30f, 1.0f), 0.0f),
            new GradientColorKey(new Color(1.00f, 0.50f, 0.30f, 1.0f), 0.20f),
            new GradientColorKey(new Color(0.50f, 0.60f, 1.00f, 1.0f), 0.25f),
            new GradientColorKey(new Color(0.50f, 0.60f, 1.00f, 1.0f), 0.75f),
            new GradientColorKey(new Color(1.00f, 0.50f, 0.30f, 1.0f), 0.80f),
            new GradientColorKey(new Color(0.20f, 0.20f, 0.30f, 1.0f), 1.0f),
        };

        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[]
        {
            new GradientAlphaKey(1f, 0f),
            new GradientAlphaKey(1f, 1f),
        };

        sunColorGradient.SetKeys(sunColorKeys, alphaKeys);
        ambientColorGradient.SetKeys(ambientColorKeys, alphaKeys);
        fogColorGradient.SetKeys(fogColorKeys, alphaKeys);
        skyTintGradient.SetKeys(skyTintColorKeys, alphaKeys);
    }
}

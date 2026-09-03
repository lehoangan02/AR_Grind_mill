using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MoonLightSceneIntegrator
{
    [MenuItem("Scene/Apply Moon Light To MainMenu")]
    public static void ApplyMoonLightToMainMenuMenu()
    {
        ApplyMoonLightToMainMenu();
    }

    // CLI: -executeMethod MoonLightSceneIntegrator.ApplyMoonLightToMainMenu -quit
    public static void ApplyMoonLightToMainMenu()
    {
        const string scenePath = "Assets/Scenes/MainMenu.unity";
        EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);

        var summary = new System.Text.StringBuilder();
        summary.AppendLine("=== MOON LIGHT SCENE INTEGRATOR ===");

        // 1. Rename Sun: Directional Light -> Sunlight (idempotent)
        GameObject sunlight = GameObject.Find("Sunlight");
        if (sunlight == null)
        {
            GameObject dirLight = GameObject.Find("Directional Light");
            if (dirLight != null)
            {
                Undo.RecordObject(dirLight, "Rename Directional Light");
                dirLight.name = "Sunlight";
                summary.AppendLine("- Renamed 'Directional Light' -> 'Sunlight'.");
            }
            else
            {
                Debug.LogWarning("[MoonLightSceneIntegrator] Neither 'Directional Light' nor 'Sunlight' found; scene may already be in the renamed state.");
            }
        }
        else
        {
            // Already renamed; skip silently.
            summary.AppendLine("- 'Sunlight' already exists; rename skipped.");
        }

        // 2. Verify URP additional lights (READ-ONLY — do NOT modify the URP asset)
        bool urpVerified = false;
        var urp = GraphicsSettings.currentRenderPipeline as UniversalRenderPipelineAsset;
        if (urp == null)
        {
            Debug.LogWarning("[MoonLightSceneIntegrator] GraphicsSettings.currentRenderPipeline is not a UniversalRenderPipelineAsset; moon light may not render at runtime until the URP asset is configured.");
        }
        else
        {
            if (urp.additionalLightsRenderingMode == LightRenderingMode.Disabled)
            {
                Debug.LogWarning("[MoonLightSceneIntegrator] URP additionalLightsRenderingMode is Disabled; the moon light won't render at runtime until the URP asset is reconfigured (out of plan scope).");
            }
            else
            {
                urpVerified = true;
                summary.AppendLine("- URP additional lights verified (enabled).");
            }
        }

        // 3. Create MoonLight (idempotent — only if absent)
        if (GameObject.Find("MoonLight") == null)
        {
            var moonGo = new GameObject("MoonLight");
            // Assert scene-root + active (matches DayNightCycle RebindToScene contract).
            if (moonGo.transform.parent != null)
            {
                moonGo.transform.parent = null;
            }
            moonGo.SetActive(true);

            Light moonLight = moonGo.AddComponent<Light>();
            moonLight.type = LightType.Directional;
            moonLight.intensity = 0f;
            moonLight.shadows = LightShadows.None;
            moonLight.color = Color.white;
            moonLight.cullingMask = -1;
            moonLight.renderingLayerMask = 1;
            moonLight.lightmapBakeType = LightmapBakeType.Realtime;
            moonLight.lightUnit = LightUnit.Lux;

            var moonUalData = moonGo.AddComponent<UnityEngine.Rendering.Universal.UniversalAdditionalLightData>();

            // Mirror the sun's UALData fields field-by-field; fall back to defaults if unavailable.
            var sunUalData = GameObject.Find("Sunlight")?.GetComponent<UnityEngine.Rendering.Universal.UniversalAdditionalLightData>();
            if (sunUalData != null)
            {
                moonUalData.usePipelineSettings = sunUalData.usePipelineSettings;
                moonUalData.renderingLayers = sunUalData.renderingLayers;
                moonUalData.shadowRenderingLayers = sunUalData.shadowRenderingLayers;
                moonUalData.renderingLayers = sunUalData.renderingLayers;
                moonUalData.shadowRenderingLayers = sunUalData.shadowRenderingLayers;
            }
            else
            {
                moonUalData.usePipelineSettings = true;
                moonUalData.renderingLayers = 1u;
                moonUalData.shadowRenderingLayers = 1u;
                moonUalData.renderingLayers = 1u;
                moonUalData.shadowRenderingLayers = 1u;
            }

            summary.AppendLine("- Created 'MoonLight' GameObject (Directional, intensity 0, no shadows) with UniversalAdditionalLightData.");
        }
        else
        {
            summary.AppendLine("- 'MoonLight' already exists; creation skipped.");
        }

        // 4. Mark dirty + save
        EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
        if (!EditorSceneManager.SaveScene(SceneManager.GetActiveScene()))
        {
            Debug.LogError("[MoonLightSceneIntegrator] Failed to save the scene.");
        }
        AssetDatabase.SaveAssets();

        summary.AppendLine($"- URP verified: {urpVerified}.");
        Debug.Log(summary.ToString());
    }
}

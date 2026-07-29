using System.IO;
using UnityEngine;

[System.Serializable]
public class UISettingsData
{
    public float masterVolume = 1f;
    public float sfxVolume = 1f;
    public float musicVolume = 1f;
    public float brightness = 1f;
    public int qualityLevel = 2;
    public bool vsync = true;
    public float lookSensitivity = 1f;
    public bool smoothTurn = true;
    public float turnSpeed = 45f;
    public bool subtitles = false;
    public float textSize = 1f;
    public int schemaVersion = 1;

    public static void Save(UISettingsData data)
    {
        string filePath = Path.Combine(Application.persistentDataPath, "settings.json");
        string directoryPath = Path.GetDirectoryName(filePath);

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
    }

    public static UISettingsData Load()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "settings.json");

        if (!File.Exists(filePath))
        {
            Debug.Log("Settings file not found, returning defaults.");
            return new UISettingsData();
        }

        try
        {
            string json = File.ReadAllText(filePath);
            UISettingsData data = JsonUtility.FromJson<UISettingsData>(json);

            if (data == null)
            {
                Debug.LogWarning("Failed to parse settings file, returning defaults.");
                return new UISettingsData();
            }

            return data;
        }
        catch (System.Exception e)
        {
            Debug.LogWarning($"Failed to load settings: {e.Message}. Returning defaults.");
            return new UISettingsData();
        }
    }
}

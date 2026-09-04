using Khoa.Farming.Editor;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Compatibility entry point retained for existing menu and CLI users.
/// The implementation lives in Khoa's safe, previewable vegetation v2 tool.
/// </summary>
public static class VietnameseCountrysideVegetator
{
    [MenuItem("Tools/Generate Vietnamese Countryside Landscape")]
    public static void GenerateCountrysideLandscape()
    {
        if (Application.isBatchMode)
        {
            VietnameseCountrysideVegetatorV2.ApplyBatch();
            return;
        }

        VietnameseCountrysideVegetatorV2.ApplyInteractive();
    }

    [MenuItem("Tools/Preview Vietnamese Countryside Landscape")]
    public static void PreviewCountrysideLandscape()
    {
        VietnameseCountrysideVegetatorV2.PreviewInteractive();
    }
}

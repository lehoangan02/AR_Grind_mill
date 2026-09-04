using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using NUnit.Framework;
using UnityEngine;

namespace Khoa.Farming.Tests
{
    public class VietnameseVegetationEditorToolTests
    {
        [Test]
        public void MainScenePreview_BuildsAValidDecorationOnlyPlanWithoutApplyingIt()
        {
            Type toolType = Type.GetType(
                "Khoa.Farming.Editor.VietnameseCountrysideVegetatorV2, Khoa.Farming.Editor",
                throwOnError: false);
            MethodInfo previewMethod = toolType?.GetMethod(
                "CreatePreviewReportForMainScene",
                BindingFlags.Public | BindingFlags.Static);

            Assert.That(previewMethod, Is.Not.Null,
                "The safe vegetation preview tool has not been implemented.");

            string report = (string)previewMethod.Invoke(null, null);
            TestContext.WriteLine(report);
            string persistentReportPath = Path.GetFullPath(Path.Combine(
                Application.dataPath,
                "..",
                "Library/KhoaReports/VietnameseVegetationPreview.txt"));
            Assert.That(File.Exists(persistentReportPath), Is.True,
                "Unity CLI previews need a persistent ignored report outside the transient Temp folder.");
            Assert.That(report, Does.Contain("Vietnamese Countryside Vegetation Preview"));
            Assert.That(report, Does.Contain("Rice/Vegetable terrain instances: 0"));
            Assert.That(report, Does.Contain("Prototype palette:"));

            Match totalMatch = Regex.Match(report, @"Total placements:\s*(\d+)");
            Assert.That(totalMatch.Success, Is.True, report);
            int total = int.Parse(totalMatch.Groups[1].Value);
            Assert.That(total, Is.InRange(10000, 50000),
                "The preview should be lush without restoring the previous 65k-instance blanket.");

            int banana = ParseCount(report, "Banana");
            int lemon = ParseCount(report, "Lemon");
            int bamboo = ParseCount(report, "Bamboo");
            int coconut = ParseCount(report, "Coconut");
            int melaleuca = ParseCount(report, "Melaleuca");
            int areca = ParseCount(report, "ArecaPalm");
            int palmClusters = ParseCount(report, "PalmCluster");
            int dominantCount = Math.Max(
                Math.Max(Math.Max(banana, lemon), Math.Max(bamboo, coconut)),
                Math.Max(melaleuca, Math.Max(areca, palmClusters)));

            Assert.That((float)dominantCount / total, Is.LessThan(0.35f),
                "No single plant family should blanket the Vietnamese countryside.");
            Assert.That(coconut, Is.GreaterThan(1000));
            Assert.That(areca, Is.GreaterThan(500));
            Assert.That(palmClusters, Is.GreaterThan(200));
        }

        private static int ParseCount(string report, string label)
        {
            Match match = Regex.Match(report, $@"^\s*{Regex.Escape(label)}:\s*(\d+)\s*$", RegexOptions.Multiline);
            Assert.That(match.Success, Is.True, report);
            return int.Parse(match.Groups[1].Value);
        }
    }
}

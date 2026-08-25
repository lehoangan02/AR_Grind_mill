using System;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;

namespace Khoa.Farming.Tests
{
    public class VietnameseVegetationPlannerTests
    {
        [Test]
        public void PlannerType_IsAvailableToTheVegetationTool()
        {
            Type plannerType = Type.GetType(
                "Khoa.Vegetation.VegetationSpatialPlanner, Khoa.Farming",
                throwOnError: false);

            Assert.That(plannerType, Is.Not.Null,
                "The deterministic vegetation planner has not been implemented yet.");
        }

        [Test]
        public void GeneratePoissonPoints_IsDeterministicAndRespectsMinimumDistance()
        {
            Type plannerType = Type.GetType(
                "Khoa.Vegetation.VegetationSpatialPlanner, Khoa.Farming",
                throwOnError: false);
            MethodInfo generateMethod = plannerType?.GetMethod(
                "GeneratePoissonPoints",
                BindingFlags.Public | BindingFlags.Static,
                binder: null,
                types: new[] { typeof(Rect), typeof(float), typeof(int), typeof(int) },
                modifiers: null);

            Assert.That(generateMethod, Is.Not.Null,
                "The planner does not expose the required Poisson-disc sampler.");

            var area = new Rect(-50f, 20f, 100f, 80f);
            const float minimumDistance = 6f;
            object[] arguments = { area, minimumDistance, 2181993, 20 };
            var first = (IReadOnlyList<Vector2>)generateMethod.Invoke(null, arguments);
            var second = (IReadOnlyList<Vector2>)generateMethod.Invoke(null, arguments);

            Assert.That(first.Count, Is.GreaterThan(10));
            Assert.That(second.Count, Is.EqualTo(first.Count));

            for (int i = 0; i < first.Count; i++)
            {
                Assert.That(area.Contains(first[i]), Is.True);
                Assert.That(second[i], Is.EqualTo(first[i]));

                for (int j = i + 1; j < first.Count; j++)
                {
                    Assert.That(Vector2.Distance(first[i], first[j]),
                        Is.GreaterThanOrEqualTo(minimumDistance - 0.0001f));
                }
            }
        }

        [Test]
        public void ClassifyZone_PrioritizesGardenThenWaterThenFieldEdge()
        {
            Type plannerType = GetPlannerType();
            MethodInfo classifyMethod = plannerType.GetMethod(
                "ClassifyZone",
                BindingFlags.Public | BindingFlags.Static,
                binder: null,
                types: new[] { typeof(Vector2), typeof(Rect[]), typeof(Rect[]), typeof(Rect[]) },
                modifiers: null);

            Assert.That(classifyMethod, Is.Not.Null,
                "The semantic vegetation-zone classifier has not been implemented.");

            var gardens = new[] { new Rect(-5f, -5f, 10f, 10f) };
            var waters = new[] { new Rect(80f, -10f, 10f, 20f) };
            var fields = new[] { new Rect(160f, -10f, 20f, 20f) };

            Assert.That(classifyMethod.Invoke(null, new object[] { Vector2.zero, gardens, waters, fields }).ToString(),
                Is.EqualTo("VillageGarden"));
            Assert.That(classifyMethod.Invoke(null, new object[] { new Vector2(85f, 0f), gardens, waters, fields }).ToString(),
                Is.EqualTo("Waterside"));
            Assert.That(classifyMethod.Invoke(null, new object[] { new Vector2(170f, 0f), gardens, waters, fields }).ToString(),
                Is.EqualTo("FieldEdge"));
            Assert.That(classifyMethod.Invoke(null, new object[] { new Vector2(300f, 300f), gardens, waters, fields }).ToString(),
                Is.EqualTo("OpenCountryside"));
        }

        [Test]
        public void SelectSpecies_UsesDifferentVietnamesePlantingProfilesPerZone()
        {
            Type plannerType = GetPlannerType();
            Type zoneType = Type.GetType("Khoa.Vegetation.VegetationZone, Khoa.Farming", false);
            MethodInfo selectMethod = zoneType == null
                ? null
                : plannerType.GetMethod(
                    "SelectSpecies",
                    BindingFlags.Public | BindingFlags.Static,
                    binder: null,
                    types: new[] { zoneType, typeof(float) },
                    modifiers: null);

            Assert.That(selectMethod, Is.Not.Null,
                "Zone-specific Vietnamese species profiles have not been implemented.");

            object village = Enum.Parse(zoneType, "VillageGarden");
            object waterside = Enum.Parse(zoneType, "Waterside");
            object fieldEdge = Enum.Parse(zoneType, "FieldEdge");
            object open = Enum.Parse(zoneType, "OpenCountryside");

            Assert.That(selectMethod.Invoke(null, new[] { village, (object)0.10f }).ToString(), Is.EqualTo("Banana"));
            Assert.That(selectMethod.Invoke(null, new[] { village, (object)0.45f }).ToString(), Is.EqualTo("Lemon"));
            Assert.That(selectMethod.Invoke(null, new[] { waterside, (object)0.10f }).ToString(), Is.EqualTo("Coconut"));
            Assert.That(selectMethod.Invoke(null, new[] { fieldEdge, (object)0.10f }).ToString(), Is.EqualTo("Bamboo"));
            Assert.That(selectMethod.Invoke(null, new[] { open, (object)0.10f }).ToString(), Is.EqualTo("Melaleuca"));
        }

        [Test]
        public void SpacingIndex_RejectsOverlappingCanopies()
        {
            Type indexType = Type.GetType(
                "Khoa.Vegetation.VegetationSpacingIndex, Khoa.Farming",
                throwOnError: false);
            Assert.That(indexType, Is.Not.Null,
                "The variable-radius vegetation spacing index has not been implemented.");

            object index = Activator.CreateInstance(indexType, 12f);
            MethodInfo tryAddMethod = indexType.GetMethod(
                "TryAdd",
                BindingFlags.Public | BindingFlags.Instance,
                binder: null,
                types: new[] { typeof(Vector2), typeof(float) },
                modifiers: null);

            Assert.That(tryAddMethod, Is.Not.Null);
            Assert.That((bool)tryAddMethod.Invoke(index, new object[] { Vector2.zero, 5f }), Is.True);
            Assert.That((bool)tryAddMethod.Invoke(index, new object[] { new Vector2(4.9f, 0f), 3f }), Is.False);
            Assert.That((bool)tryAddMethod.Invoke(index, new object[] { new Vector2(5.1f, 0f), 3f }), Is.True);
            Assert.That((bool)tryAddMethod.Invoke(index, new object[] { new Vector2(14f, 0f), 10f }), Is.False,
                "A new large canopy must also respect its own larger spacing radius.");
        }

        [Test]
        public void RetentionProbability_MakesSettledAndWatersideZonesLusherThanOpenLand()
        {
            Type plannerType = GetPlannerType();
            Type zoneType = Type.GetType("Khoa.Vegetation.VegetationZone, Khoa.Farming", false);
            MethodInfo probabilityMethod = zoneType == null
                ? null
                : plannerType.GetMethod(
                    "GetRetentionProbability",
                    BindingFlags.Public | BindingFlags.Static,
                    binder: null,
                    types: new[] { zoneType, typeof(float) },
                    modifiers: null);

            Assert.That(probabilityMethod, Is.Not.Null,
                "Zone-aware vegetation density has not been implemented.");

            object village = Enum.Parse(zoneType, "VillageGarden");
            object waterside = Enum.Parse(zoneType, "Waterside");
            object open = Enum.Parse(zoneType, "OpenCountryside");
            float villageProbability = (float)probabilityMethod.Invoke(null, new[] { village, (object)0.5f });
            float watersideProbability = (float)probabilityMethod.Invoke(null, new[] { waterside, (object)0.5f });
            float openProbability = (float)probabilityMethod.Invoke(null, new[] { open, (object)0.5f });

            Assert.That(villageProbability, Is.GreaterThan(openProbability));
            Assert.That(watersideProbability, Is.GreaterThan(openProbability));
            Assert.That(openProbability, Is.InRange(0.2f, 0.8f));
        }

        [Test]
        public void MinimumSpacing_ReservesMoreRoomForTallPalmsThanBananas()
        {
            Type plannerType = GetPlannerType();
            Type speciesType = Type.GetType("Khoa.Vegetation.VegetationSpecies, Khoa.Farming", false);
            MethodInfo spacingMethod = speciesType == null
                ? null
                : plannerType.GetMethod(
                    "GetMinimumSpacing",
                    BindingFlags.Public | BindingFlags.Static,
                    binder: null,
                    types: new[] { speciesType },
                    modifiers: null);

            Assert.That(spacingMethod, Is.Not.Null,
                "Species-specific canopy spacing has not been implemented.");

            object banana = Enum.Parse(speciesType, "Banana");
            object coconut = Enum.Parse(speciesType, "Coconut");
            object palmCluster = Enum.Parse(speciesType, "PalmCluster");
            float bananaSpacing = (float)spacingMethod.Invoke(null, new[] { banana });
            float coconutSpacing = (float)spacingMethod.Invoke(null, new[] { coconut });
            float palmSpacing = (float)spacingMethod.Invoke(null, new[] { palmCluster });

            Assert.That(coconutSpacing, Is.GreaterThan(bananaSpacing));
            Assert.That(palmSpacing, Is.GreaterThan(bananaSpacing));
            Assert.That(Mathf.Max(coconutSpacing, palmSpacing), Is.LessThanOrEqualTo(12f));
        }

        [Test]
        public void PrototypeClassification_UsesAssetFamiliesAndRejectsGameplayRice()
        {
            Type plannerType = GetPlannerType();
            MethodInfo classifyMethod = plannerType.GetMethod(
                "TryClassifyPrototypeName",
                BindingFlags.Public | BindingFlags.Static);

            Assert.That(classifyMethod, Is.Not.Null,
                "Name-based prototype classification has not been implemented.");

            AssertPrototype(classifyMethod, "BaTree2", true, "Banana");
            AssertPrototype(classifyMethod, "Lemon Tree 3 w Fruits", true, "Lemon");
            AssertPrototype(classifyMethod, "TreeBush4", true, "Bamboo");
            AssertPrototype(classifyMethod, "Coconut_Palm_Tree06_AFS", true, "Coconut");
            AssertPrototype(classifyMethod, "MelaleucaAlternifolia_A", true, "Melaleuca");
            AssertPrototype(classifyMethod, "Palm_1_3", true, "ArecaPalm");
            AssertPrototype(classifyMethod, "PalmTreeTrioTwoSided", true, "PalmCluster");
            AssertPrototype(classifyMethod, "RicePlant", false, null);
            AssertPrototype(classifyMethod, "Vegetable", false, null);
        }

        [Test]
        public void TargetDimensions_KeepCoconutTallWithoutAnOversizedCanopy()
        {
            Type plannerType = GetPlannerType();
            Type speciesType = Type.GetType("Khoa.Vegetation.VegetationSpecies, Khoa.Farming", false);
            MethodInfo dimensionsMethod = speciesType == null
                ? null
                : plannerType.GetMethod(
                    "GetTargetDimensions",
                    BindingFlags.Public | BindingFlags.Static,
                    binder: null,
                    types: new[] { speciesType, typeof(float) },
                    modifiers: null);

            Assert.That(dimensionsMethod, Is.Not.Null,
                "Real-world vegetation dimensions have not been implemented.");

            object banana = Enum.Parse(speciesType, "Banana");
            object coconut = Enum.Parse(speciesType, "Coconut");
            Vector2 bananaSize = (Vector2)dimensionsMethod.Invoke(null, new[] { banana, (object)0.5f });
            Vector2 coconutSize = (Vector2)dimensionsMethod.Invoke(null, new[] { coconut, (object)0.5f });

            Assert.That(bananaSize.x, Is.InRange(2.5f, 4.5f));
            Assert.That(bananaSize.y, Is.InRange(2.5f, 4.5f));
            Assert.That(coconutSize.x, Is.InRange(5f, 10f));
            Assert.That(coconutSize.y, Is.InRange(9f, 15f));
            Assert.That(coconutSize.y, Is.GreaterThan(coconutSize.x));
        }

        private static Type GetPlannerType()
        {
            Type plannerType = Type.GetType(
                "Khoa.Vegetation.VegetationSpatialPlanner, Khoa.Farming",
                throwOnError: false);
            Assert.That(plannerType, Is.Not.Null);
            return plannerType;
        }

        private static void AssertPrototype(
            MethodInfo classifyMethod,
            string prototypeName,
            bool expectedResult,
            string expectedSpecies)
        {
            object[] arguments = { prototypeName, null };
            bool result = (bool)classifyMethod.Invoke(null, arguments);
            Assert.That(result, Is.EqualTo(expectedResult), prototypeName);
            if (expectedResult)
            {
                Assert.That(arguments[1].ToString(), Is.EqualTo(expectedSpecies), prototypeName);
            }
        }
    }
}

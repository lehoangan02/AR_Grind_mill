using System;
using System.Collections.Generic;
using UnityEngine;

namespace Khoa.Vegetation
{
    public enum VegetationZone
    {
        VillageGarden,
        Waterside,
        FieldEdge,
        OpenCountryside
    }

    public enum VegetationSpecies
    {
        Banana,
        Lemon,
        Bamboo,
        Coconut,
        Melaleuca,
        ArecaPalm,
        PalmCluster
    }

    /// <summary>
    /// Provides deterministic, testable spatial rules for editor-time vegetation generation.
    /// </summary>
    public static class VegetationSpatialPlanner
    {
        private const float VillageGardenDistance = 35f;
        private const float WatersideDistance = 22f;
        private const float FieldEdgeDistance = 18f;

        public static IReadOnlyList<Vector2> GeneratePoissonPoints(
            Rect area,
            float minimumDistance,
            int seed,
            int rejectionSamples)
        {
            if (area.width <= 0f || area.height <= 0f)
            {
                throw new ArgumentException("Sampling area must have a positive size.", nameof(area));
            }

            if (minimumDistance <= 0f)
            {
                throw new ArgumentOutOfRangeException(nameof(minimumDistance));
            }

            if (rejectionSamples <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rejectionSamples));
            }

            var random = new System.Random(seed);
            float cellSize = minimumDistance / Mathf.Sqrt(2f);
            int columns = Mathf.CeilToInt(area.width / cellSize);
            int rows = Mathf.CeilToInt(area.height / cellSize);
            int[] grid = new int[columns * rows];
            Array.Fill(grid, -1);

            var points = new List<Vector2>();
            var activeIndices = new List<int>();
            var firstPoint = new Vector2(
                Mathf.Lerp(area.xMin, area.xMax, NextFloat(random)),
                Mathf.Lerp(area.yMin, area.yMax, NextFloat(random)));
            AddPoint(firstPoint, area, cellSize, columns, grid, points, activeIndices);

            float minimumDistanceSquared = minimumDistance * minimumDistance;
            while (activeIndices.Count > 0)
            {
                int activeListIndex = random.Next(activeIndices.Count);
                Vector2 origin = points[activeIndices[activeListIndex]];
                bool foundPoint = false;

                for (int attempt = 0; attempt < rejectionSamples; attempt++)
                {
                    float angle = NextFloat(random) * Mathf.PI * 2f;
                    float radius = minimumDistance * (1f + NextFloat(random));
                    var candidate = origin + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;

                    if (!area.Contains(candidate) ||
                        !IsFarEnough(candidate, area, cellSize, columns, rows, grid, points, minimumDistanceSquared))
                    {
                        continue;
                    }

                    AddPoint(candidate, area, cellSize, columns, grid, points, activeIndices);
                    foundPoint = true;
                    break;
                }

                if (!foundPoint)
                {
                    activeIndices.RemoveAt(activeListIndex);
                }
            }

            return points;
        }

        public static VegetationZone ClassifyZone(
            Vector2 point,
            Rect[] gardenAreas,
            Rect[] waterAreas,
            Rect[] fieldAreas)
        {
            if (DistanceToNearest(point, gardenAreas) <= VillageGardenDistance)
            {
                return VegetationZone.VillageGarden;
            }

            if (DistanceToNearest(point, waterAreas) <= WatersideDistance)
            {
                return VegetationZone.Waterside;
            }

            if (DistanceToNearest(point, fieldAreas) <= FieldEdgeDistance)
            {
                return VegetationZone.FieldEdge;
            }

            return VegetationZone.OpenCountryside;
        }

        public static VegetationSpecies SelectSpecies(VegetationZone zone, float sample)
        {
            sample = Mathf.Clamp01(sample);

            return zone switch
            {
                VegetationZone.VillageGarden => sample switch
                {
                    < 0.28f => VegetationSpecies.Banana,
                    < 0.55f => VegetationSpecies.Lemon,
                    < 0.72f => VegetationSpecies.ArecaPalm,
                    < 0.82f => VegetationSpecies.Coconut,
                    < 0.94f => VegetationSpecies.Bamboo,
                    _ => VegetationSpecies.Melaleuca
                },
                VegetationZone.Waterside => sample switch
                {
                    < 0.32f => VegetationSpecies.Coconut,
                    < 0.55f => VegetationSpecies.Bamboo,
                    < 0.70f => VegetationSpecies.Banana,
                    < 0.82f => VegetationSpecies.Melaleuca,
                    < 0.92f => VegetationSpecies.ArecaPalm,
                    _ => VegetationSpecies.Lemon
                },
                VegetationZone.FieldEdge => sample switch
                {
                    < 0.34f => VegetationSpecies.Bamboo,
                    < 0.56f => VegetationSpecies.Banana,
                    < 0.74f => VegetationSpecies.Melaleuca,
                    < 0.86f => VegetationSpecies.Coconut,
                    < 0.96f => VegetationSpecies.Lemon,
                    _ => VegetationSpecies.ArecaPalm
                },
                _ => sample switch
                {
                    < 0.28f => VegetationSpecies.Melaleuca,
                    < 0.50f => VegetationSpecies.Bamboo,
                    < 0.68f => VegetationSpecies.Lemon,
                    < 0.82f => VegetationSpecies.Banana,
                    < 0.90f => VegetationSpecies.Coconut,
                    < 0.96f => VegetationSpecies.ArecaPalm,
                    _ => VegetationSpecies.PalmCluster
                }
            };
        }

        public static float GetRetentionProbability(VegetationZone zone, float densityNoise)
        {
            float baseProbability = zone switch
            {
                VegetationZone.VillageGarden => 0.70f,
                VegetationZone.Waterside => 0.66f,
                VegetationZone.FieldEdge => 0.54f,
                _ => 0.42f
            };
            float noiseMultiplier = Mathf.Lerp(0.75f, 1.25f, Mathf.Clamp01(densityNoise));
            return Mathf.Clamp(baseProbability * noiseMultiplier, 0.20f, 0.85f);
        }

        public static float GetMinimumSpacing(VegetationSpecies species)
        {
            return species switch
            {
                VegetationSpecies.Banana => 4.8f,
                VegetationSpecies.Lemon => 5.5f,
                VegetationSpecies.Bamboo => 6.5f,
                VegetationSpecies.Coconut => 10f,
                VegetationSpecies.Melaleuca => 7f,
                VegetationSpecies.ArecaPalm => 8f,
                VegetationSpecies.PalmCluster => 11f,
                _ => 6f
            };
        }

        public static bool TryClassifyPrototypeName(string prototypeName, out VegetationSpecies species)
        {
            species = default;
            if (string.IsNullOrWhiteSpace(prototypeName))
            {
                return false;
            }

            string normalized = prototypeName.ToLowerInvariant();
            if (normalized.Contains("rice") || normalized.Contains("vegetable"))
            {
                return false;
            }

            if (normalized.Contains("batree"))
            {
                species = VegetationSpecies.Banana;
            }
            else if (normalized.Contains("lemon"))
            {
                species = VegetationSpecies.Lemon;
            }
            else if (normalized.Contains("treebush"))
            {
                species = VegetationSpecies.Bamboo;
            }
            else if (normalized.Contains("coconut_palm"))
            {
                species = VegetationSpecies.Coconut;
            }
            else if (normalized.Contains("melaleuca"))
            {
                species = VegetationSpecies.Melaleuca;
            }
            else if (normalized.Contains("palmtree"))
            {
                species = VegetationSpecies.PalmCluster;
            }
            else if (normalized.Contains("palm_"))
            {
                species = VegetationSpecies.ArecaPalm;
            }
            else
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Returns target canopy width (x) and height (y), in metres.
        /// </summary>
        public static Vector2 GetTargetDimensions(VegetationSpecies species, float sample)
        {
            sample = Mathf.Clamp01(sample);
            return species switch
            {
                VegetationSpecies.Banana => new Vector2(
                    Mathf.Lerp(2.4f, 3.6f, sample),
                    Mathf.Lerp(2.7f, 4.0f, sample)),
                VegetationSpecies.Lemon => new Vector2(
                    Mathf.Lerp(2.5f, 4.5f, sample),
                    Mathf.Lerp(2.5f, 4.5f, sample)),
                VegetationSpecies.Bamboo => new Vector2(
                    Mathf.Lerp(3.0f, 6.0f, sample),
                    Mathf.Lerp(4.5f, 9.0f, sample)),
                VegetationSpecies.Coconut => new Vector2(
                    Mathf.Lerp(6.0f, 9.0f, sample),
                    Mathf.Lerp(9.5f, 14.5f, sample)),
                VegetationSpecies.Melaleuca => new Vector2(
                    Mathf.Lerp(4.0f, 7.0f, sample),
                    Mathf.Lerp(5.5f, 10.5f, sample)),
                VegetationSpecies.ArecaPalm => new Vector2(
                    Mathf.Lerp(3.0f, 5.5f, sample),
                    Mathf.Lerp(8.0f, 13.0f, sample)),
                VegetationSpecies.PalmCluster => new Vector2(
                    Mathf.Lerp(7.0f, 11.0f, sample),
                    Mathf.Lerp(8.5f, 13.0f, sample)),
                _ => new Vector2(4f, 6f)
            };
        }

        private static bool IsFarEnough(
            Vector2 candidate,
            Rect area,
            float cellSize,
            int columns,
            int rows,
            IReadOnlyList<int> grid,
            IReadOnlyList<Vector2> points,
            float minimumDistanceSquared)
        {
            int cellX = Mathf.FloorToInt((candidate.x - area.xMin) / cellSize);
            int cellY = Mathf.FloorToInt((candidate.y - area.yMin) / cellSize);
            int minX = Mathf.Max(0, cellX - 2);
            int maxX = Mathf.Min(columns - 1, cellX + 2);
            int minY = Mathf.Max(0, cellY - 2);
            int maxY = Mathf.Min(rows - 1, cellY + 2);

            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    int pointIndex = grid[y * columns + x];
                    if (pointIndex >= 0 &&
                        (points[pointIndex] - candidate).sqrMagnitude < minimumDistanceSquared)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static void AddPoint(
            Vector2 point,
            Rect area,
            float cellSize,
            int columns,
            IList<int> grid,
            IList<Vector2> points,
            IList<int> activeIndices)
        {
            int pointIndex = points.Count;
            points.Add(point);
            activeIndices.Add(pointIndex);

            int cellX = Mathf.FloorToInt((point.x - area.xMin) / cellSize);
            int cellY = Mathf.FloorToInt((point.y - area.yMin) / cellSize);
            grid[cellY * columns + cellX] = pointIndex;
        }

        private static float NextFloat(System.Random random)
        {
            return (float)random.NextDouble();
        }

        private static float DistanceToNearest(Vector2 point, IReadOnlyList<Rect> areas)
        {
            if (areas == null || areas.Count == 0)
            {
                return float.PositiveInfinity;
            }

            float nearestSquared = float.PositiveInfinity;
            for (int i = 0; i < areas.Count; i++)
            {
                Rect area = areas[i];
                float dx = Mathf.Max(area.xMin - point.x, 0f, point.x - area.xMax);
                float dy = Mathf.Max(area.yMin - point.y, 0f, point.y - area.yMax);
                nearestSquared = Mathf.Min(nearestSquared, dx * dx + dy * dy);
            }

            return Mathf.Sqrt(nearestSquared);
        }
    }

    /// <summary>
    /// Spatial hash used to keep large canopies from overlapping smaller vegetation.
    /// </summary>
    public sealed class VegetationSpacingIndex
    {
        private readonly float maximumRadius;
        private readonly Dictionary<Vector2Int, List<Entry>> cells = new();

        public VegetationSpacingIndex(float maximumRadius)
        {
            if (maximumRadius <= 0f)
            {
                throw new ArgumentOutOfRangeException(nameof(maximumRadius));
            }

            this.maximumRadius = maximumRadius;
        }

        public bool TryAdd(Vector2 point, float radius)
        {
            if (radius <= 0f || radius > maximumRadius)
            {
                throw new ArgumentOutOfRangeException(nameof(radius));
            }

            Vector2Int cell = GetCell(point);
            for (int y = cell.y - 1; y <= cell.y + 1; y++)
            {
                for (int x = cell.x - 1; x <= cell.x + 1; x++)
                {
                    if (!cells.TryGetValue(new Vector2Int(x, y), out List<Entry> entries))
                    {
                        continue;
                    }

                    for (int i = 0; i < entries.Count; i++)
                    {
                        Entry entry = entries[i];
                        float requiredDistance = Mathf.Max(radius, entry.Radius);
                        if ((entry.Position - point).sqrMagnitude < requiredDistance * requiredDistance)
                        {
                            return false;
                        }
                    }
                }
            }

            if (!cells.TryGetValue(cell, out List<Entry> targetCell))
            {
                targetCell = new List<Entry>();
                cells.Add(cell, targetCell);
            }

            targetCell.Add(new Entry(point, radius));
            return true;
        }

        private Vector2Int GetCell(Vector2 point)
        {
            return new Vector2Int(
                Mathf.FloorToInt(point.x / maximumRadius),
                Mathf.FloorToInt(point.y / maximumRadius));
        }

        private readonly struct Entry
        {
            public Entry(Vector2 position, float radius)
            {
                Position = position;
                Radius = radius;
            }

            public Vector2 Position { get; }
            public float Radius { get; }
        }
    }
}

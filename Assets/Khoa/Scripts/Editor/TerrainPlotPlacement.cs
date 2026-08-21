using UnityEngine;

namespace Khoa.Farming.Editor
{
    /// <summary>
    /// Places a flat plot against a Unity Terrain using multiple footprint samples.
    /// The final clearance is calculated from the plot's bottom plane, not only its center.
    /// </summary>
    public static class TerrainPlotPlacement
    {
        public const int DefaultSamplesPerAxis = 3;

        public static bool TryPlaceOnTerrain(
            GameObject plot,
            Terrain terrain,
            Vector3 centerWorld,
            float clearance,
            int samplesPerAxis = DefaultSamplesPerAxis)
        {
            if (plot == null || terrain == null || terrain.terrainData == null)
            {
                return false;
            }

            BoxCollider box = plot.GetComponent<BoxCollider>();
            if (box == null)
            {
                Debug.LogWarning($"Cannot terrain-map {plot.name}: a root BoxCollider is required.");
                return false;
            }

            samplesPerAxis = Mathf.Max(2, samplesPerAxis);
            Vector3 scale = plot.transform.lossyScale;
            float halfWidth = Mathf.Abs(box.size.x * scale.x) * 0.5f;
            float halfLength = Mathf.Abs(box.size.z * scale.z) * 0.5f;
            Vector3 averageNormal = Vector3.zero;

            for (int z = 0; z < samplesPerAxis; z++)
            {
                for (int x = 0; x < samplesPerAxis; x++)
                {
                    Vector3 samplePosition = new Vector3(
                        centerWorld.x + Mathf.Lerp(-halfWidth, halfWidth, SampleT(x, samplesPerAxis)),
                        centerWorld.y,
                        centerWorld.z + Mathf.Lerp(-halfLength, halfLength, SampleT(z, samplesPerAxis)));

                    if (!TrySampleTerrain(terrain, samplePosition, out _, out Vector3 normal))
                    {
                        return false;
                    }

                    averageNormal += normal;
                }
            }

            if (averageNormal.sqrMagnitude < 0.0001f)
            {
                averageNormal = Vector3.up;
            }

            plot.transform.SetPositionAndRotation(
                new Vector3(centerWorld.x, 0f, centerWorld.z),
                Quaternion.FromToRotation(Vector3.up, averageNormal.normalized));

            float requiredCenterY = float.NegativeInfinity;
            for (int z = 0; z < samplesPerAxis; z++)
            {
                for (int x = 0; x < samplesPerAxis; x++)
                {
                    Vector3 localBottomPoint = box.center + new Vector3(
                        Mathf.Lerp(-box.size.x * 0.5f, box.size.x * 0.5f, SampleT(x, samplesPerAxis)),
                        -box.size.y * 0.5f,
                        Mathf.Lerp(-box.size.z * 0.5f, box.size.z * 0.5f, SampleT(z, samplesPerAxis)));
                    Vector3 worldBottomPoint = plot.transform.TransformPoint(localBottomPoint);

                    if (!TrySampleTerrain(terrain, worldBottomPoint, out float terrainHeight, out _))
                    {
                        return false;
                    }

                    float bottomOffsetFromCenter = worldBottomPoint.y - plot.transform.position.y;
                    requiredCenterY = Mathf.Max(
                        requiredCenterY,
                        terrainHeight + Mathf.Max(0f, clearance) - bottomOffsetFromCenter);
                }
            }

            Vector3 finalPosition = plot.transform.position;
            finalPosition.y = requiredCenterY;
            plot.transform.position = finalPosition;
            return true;
        }

        private static float SampleT(int index, int samplesPerAxis)
        {
            return index / (samplesPerAxis - 1f);
        }

        private static bool TrySampleTerrain(
            Terrain terrain,
            Vector3 worldPosition,
            out float height,
            out Vector3 normal)
        {
            Terrain sampleTerrain = FindTerrainContaining(terrain, worldPosition);
            if (sampleTerrain == null)
            {
                height = 0f;
                normal = Vector3.up;
                return false;
            }

            TerrainData data = sampleTerrain.terrainData;
            Vector3 terrainPosition = sampleTerrain.transform.position;
            float normalizedX = (worldPosition.x - terrainPosition.x) / data.size.x;
            float normalizedZ = (worldPosition.z - terrainPosition.z) / data.size.z;

            height = terrainPosition.y + data.GetInterpolatedHeight(normalizedX, normalizedZ);
            normal = sampleTerrain.transform.TransformDirection(data.GetInterpolatedNormal(normalizedX, normalizedZ));
            return true;
        }

        private static Terrain FindTerrainContaining(Terrain preferredTerrain, Vector3 worldPosition)
        {
            if (ContainsWorldPosition(preferredTerrain, worldPosition))
            {
                return preferredTerrain;
            }

            foreach (Terrain candidate in Terrain.activeTerrains)
            {
                if (candidate != preferredTerrain && ContainsWorldPosition(candidate, worldPosition))
                {
                    return candidate;
                }
            }

            return null;
        }

        private static bool ContainsWorldPosition(Terrain terrain, Vector3 worldPosition)
        {
            if (terrain == null || terrain.terrainData == null)
            {
                return false;
            }

            Vector3 origin = terrain.transform.position;
            Vector3 size = terrain.terrainData.size;
            return worldPosition.x >= origin.x && worldPosition.x <= origin.x + size.x &&
                   worldPosition.z >= origin.z && worldPosition.z <= origin.z + size.z;
        }
    }
}

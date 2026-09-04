using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace Khoa.Farming.Editor
{
    public class PlotGridGenerator : EditorWindow
    {
        public const int ProductionRows = 100;
        public const int ProductionColumns = 100;
        public const float ProductionSpacing = 0.08f;
        public const int ProductionTerrainSamplesPerAxis = 5;

        private GameObject plotPrefab;
        private Transform gridOrigin;
        private int rows = ProductionRows;
        private int columns = ProductionColumns;
        private float spacingX = ProductionSpacing;
        private float spacingZ = ProductionSpacing;
        private float maxHeight = 100f; // Ngưỡng độ cao mặc định
        private float yOffset = 0.08f; // Độ nổi của ô đất so với mặt đất
        private int terrainSamplesPerAxis = ProductionTerrainSamplesPerAxis;
        
        [MenuItem("Khoa/Farming/Generate Plot Grid")]
        public static void ShowWindow()
        {
            GetWindow<PlotGridGenerator>("Grid Generator");
        }

        [MenuItem("Khoa/Farming/Generate Production Grid 100x100")]
        public static void GenerateProductionGridInMainScene()
        {
            Scene scene = FarmingSceneIntegrator.OpenOrUseMainScene();
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(
                "Assets/Khoa/Prefabs/Plot_Prefab.prefab");
            if (prefab == null)
            {
                throw new InvalidOperationException("Missing production plot prefab.");
            }

            CropPlot[] existingPlots = UnityEngine.Object.FindObjectsByType<CropPlot>(
                FindObjectsInactive.Include,
                FindObjectsSortMode.None);
            Transform currentGridRoot = FindPrimaryGridRoot(existingPlots);
            if (currentGridRoot == null)
            {
                throw new InvalidOperationException(
                    "Cannot determine the existing farming-grid origin in the main scene.");
            }

            if (existingPlots.Length == ProductionRows * ProductionColumns &&
                currentGridRoot.name == "Farm_Grid_Production_100x100")
            {
                Debug.Log("[Khoa Farming] Production grid is already 100x100; refreshing integration only.");
                FarmingSceneIntegrator.ApplyMainSceneSetup();
                return;
            }

            Vector3 productionOrigin = currentGridRoot.position;
            GameObject generatedRoot = GenerateGridRoot(
                prefab,
                productionOrigin,
                ProductionRows,
                ProductionColumns,
                ProductionSpacing,
                ProductionSpacing,
                100f,
                0.08f,
                ProductionTerrainSamplesPerAxis,
                "Farm_Grid_Production_100x100",
                out int generatedCount);

            int expectedCount = ProductionRows * ProductionColumns;
            if (generatedCount != expectedCount)
            {
                UnityEngine.Object.DestroyImmediate(generatedRoot);
                throw new InvalidOperationException(
                    $"Production grid validation failed: generated {generatedCount}/{expectedCount} plots. " +
                    "The previous grid was preserved.");
            }

            foreach (Transform oldRoot in FindGridRoots().Where(root => root != generatedRoot.transform))
            {
                UnityEngine.Object.DestroyImmediate(oldRoot.gameObject);
            }

            EditorSceneManager.MarkSceneDirty(scene);
            FarmingSceneIntegrator.ApplyMainSceneSetup();
            Debug.Log($"[Khoa Farming] Production grid locked at {ProductionColumns}x{ProductionRows} " +
                      $"({generatedCount} terrain-mapped plots).");
        }

        private void OnEnable()
        {
            plotPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Khoa/Prefabs/Plot_Prefab.prefab");
        }

        private void OnGUI()
        {
            GUILayout.Label("Tạo Ruộng Lúa Theo Grid (Lưới)", EditorStyles.boldLabel);
            EditorGUILayout.HelpBox("1. Tạo một Empty GameObject (nhấp chuột phải -> Create Empty) đặt ở giữa vùng ngập nước.\n2. Kéo nó vào ô 'Grid Origin' bên dưới.", MessageType.Info);

            plotPrefab = (GameObject)EditorGUILayout.ObjectField("Plot Prefab", plotPrefab, typeof(GameObject), false);
            gridOrigin = (Transform)EditorGUILayout.ObjectField("Grid Origin (Tâm)", gridOrigin, typeof(Transform), true);
            
            GUILayout.Space(10);
            rows = EditorGUILayout.IntSlider("Số hàng (Z)", rows, 1, 200);
            columns = EditorGUILayout.IntSlider("Số cột (X)", columns, 1, 200);
            spacingX = EditorGUILayout.FloatField("Khoảng cách X (mét)", spacingX);
            spacingZ = EditorGUILayout.FloatField("Khoảng cách Z (mét)", spacingZ);
            
            GUILayout.Space(10);
            EditorGUILayout.HelpBox("Max Height: Bờ ruộng của bạn cao bao nhiêu? Hãy điền vào đây. Tool sẽ bắn tia Laser từ trên trời xuống, nếu chạm trúng bờ ruộng (chỗ nhô cao hơn số này) thì nó sẽ bỏ qua, chỉ cắm lúa ở vùng trũng (bên dưới mặt nước).", MessageType.Warning);
            maxHeight = EditorGUILayout.FloatField("Max Terrain Height (Y)", maxHeight);

            GUILayout.Space(10);
            EditorGUILayout.HelpBox("Y Offset là khoảng hở tối thiểu giữa Terrain và toàn bộ mặt đáy ô đất. Tool kiểm tra nhiều điểm nên không cần tăng quá cao để chữa phần góc bị chìm.", MessageType.Info);
            yOffset = EditorGUILayout.FloatField("Độ nổi (Y Offset)", yOffset);
            terrainSamplesPerAxis = EditorGUILayout.IntPopup(
                "Mẫu Terrain mỗi chiều",
                terrainSamplesPerAxis,
                new[] { "3 x 3 (Nhanh)", "5 x 5 (Địa hình gồ ghề)" },
                new[] { 3, 5 });

            GUILayout.Space(20);
            if (GUILayout.Button("Tạo Grid Ô Đất", GUILayout.Height(40)))
            {
                GenerateGrid();
            }
        }

        private void GenerateGrid()
        {
            if (plotPrefab == null || gridOrigin == null)
            {
                EditorUtility.DisplayDialog("Lỗi", "Vui lòng gán Plot Prefab và Grid Origin (tạo một Empty Object làm tâm)!", "OK");
                return;
            }

            GameObject generatedRoot = GenerateGridRoot(
                plotPrefab,
                gridOrigin.position,
                rows,
                columns,
                spacingX,
                spacingZ,
                maxHeight,
                yOffset,
                terrainSamplesPerAxis,
                "Farm_Grid_" + DateTime.Now.ToString("HHmmss"),
                out int count);

            foreach (Transform oldRoot in FindGridRoots().Where(root => root != generatedRoot.transform))
            {
                Undo.DestroyObjectImmediate(oldRoot.gameObject);
            }

            Undo.RegisterCreatedObjectUndo(generatedRoot, "Generate Farm Grid");
            EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
            Debug.Log($"<color=green>Đã sinh ra {count} ô đất thành công dọc theo vùng ngập nước!</color>");
        }

        private static GameObject GenerateGridRoot(
            GameObject prefab,
            Vector3 origin,
            int rowCount,
            int columnCount,
            float horizontalSpacing,
            float verticalSpacing,
            float maximumTerrainHeight,
            float clearance,
            int samplesPerAxis,
            string rootName,
            out int generatedCount)
        {
            GameObject group = new GameObject(rootName);
            group.transform.position = origin;
            generatedCount = 0;

            BoxCollider plotCollider = prefab.GetComponent<BoxCollider>();
            float plotSizeX = plotCollider != null
                ? plotCollider.size.x * Mathf.Abs(prefab.transform.localScale.x)
                : Mathf.Abs(prefab.transform.localScale.x);
            float plotSizeZ = plotCollider != null
                ? plotCollider.size.z * Mathf.Abs(prefab.transform.localScale.z)
                : Mathf.Abs(prefab.transform.localScale.z);
            float stepX = plotSizeX + Mathf.Max(0f, horizontalSpacing);
            float stepZ = plotSizeZ + Mathf.Max(0f, verticalSpacing);
            float totalWidth = columnCount * plotSizeX + (columnCount - 1) * Mathf.Max(0f, horizontalSpacing);
            float totalLength = rowCount * plotSizeZ + (rowCount - 1) * Mathf.Max(0f, verticalSpacing);
            Vector3 startPosition = origin - new Vector3(totalWidth * 0.5f, 0f, totalLength * 0.5f) +
                                    new Vector3(plotSizeX * 0.5f, 0f, plotSizeZ * 0.5f);
            Terrain[] terrains = UnityEngine.Object.FindObjectsByType<Terrain>(
                FindObjectsInactive.Exclude,
                FindObjectsSortMode.None);

            try
            {
                for (int x = 0; x < columnCount; x++)
                {
                    if (!Application.isBatchMode)
                    {
                        EditorUtility.DisplayProgressBar(
                            "Generate farming grid",
                            $"Column {x + 1}/{columnCount}",
                            (x + 1f) / columnCount);
                    }

                    for (int z = 0; z < rowCount; z++)
                    {
                        Vector3 center = new Vector3(
                            startPosition.x + x * stepX,
                            origin.y,
                            startPosition.z + z * stepZ);
                        Terrain terrain = FindTerrainContaining(terrains, center);
                        if (terrain == null || SampleTerrainHeight(terrain, center) > maximumTerrainHeight)
                        {
                            continue;
                        }

                        GameObject plot = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
                        if (TerrainPlotPlacement.TryPlaceOnTerrain(
                                plot,
                                terrain,
                                center,
                                clearance,
                                samplesPerAxis))
                        {
                            plot.transform.SetParent(group.transform, true);
                            generatedCount++;
                        }
                        else
                        {
                            UnityEngine.Object.DestroyImmediate(plot);
                        }
                    }
                }
            }
            catch
            {
                UnityEngine.Object.DestroyImmediate(group);
                throw;
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }

            return group;
        }

        private static Transform FindPrimaryGridRoot(IEnumerable<CropPlot> plots)
        {
            return plots
                .Where(plot => plot != null && plot.transform.parent != null)
                .GroupBy(plot => plot.transform.parent)
                .OrderByDescending(group => group.Count())
                .Select(group => group.Key)
                .FirstOrDefault();
        }

        private static IEnumerable<Transform> FindGridRoots()
        {
            return UnityEngine.Object.FindObjectsByType<Transform>(
                    FindObjectsInactive.Include,
                    FindObjectsSortMode.None)
                .Where(transform => transform != null && transform.name.StartsWith("Farm_Grid_"));
        }

        private static Terrain FindTerrainContaining(IEnumerable<Terrain> terrains, Vector3 worldPosition)
        {
            return terrains.FirstOrDefault(terrain =>
            {
                if (terrain == null || terrain.terrainData == null)
                {
                    return false;
                }

                Vector3 terrainOrigin = terrain.transform.position;
                Vector3 size = terrain.terrainData.size;
                return worldPosition.x >= terrainOrigin.x && worldPosition.x <= terrainOrigin.x + size.x &&
                       worldPosition.z >= terrainOrigin.z && worldPosition.z <= terrainOrigin.z + size.z;
            });
        }

        private static float SampleTerrainHeight(Terrain terrain, Vector3 worldPosition)
        {
            TerrainData data = terrain.terrainData;
            Vector3 localPosition = worldPosition - terrain.transform.position;
            return terrain.transform.position.y + data.GetInterpolatedHeight(
                Mathf.Clamp01(localPosition.x / data.size.x),
                Mathf.Clamp01(localPosition.z / data.size.z));
        }
    }
}

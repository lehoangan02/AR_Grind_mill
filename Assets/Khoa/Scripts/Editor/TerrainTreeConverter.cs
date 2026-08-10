using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace Khoa.Farming.Editor
{
    public class TerrainTreeConverter : EditorWindow
    {
        private Terrain targetTerrain;
        private int treePrototypeIndex = 0;
        private GameObject plotPrefab;
        private Transform parentTransform;

        [MenuItem("Khoa/Farming/Convert Terrain Trees to Plots")]
        public static void ShowWindow()
        {
            GetWindow<TerrainTreeConverter>("Tree Converter");
        }

        private void OnEnable()
        {
            if (Terrain.activeTerrain != null)
                targetTerrain = Terrain.activeTerrain;
                
            plotPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Khoa/Prefabs/Plot_Prefab.prefab");
        }

        private void OnGUI()
        {
            GUILayout.Label("Chuyển đổi Lúa trên Terrain thành Ô Đất", EditorStyles.boldLabel);
            EditorGUILayout.HelpBox("Tool này giúp bạn biến hàng ngàn cây lúa (Terrain Tree) thành Plot_Prefab chỉ bằng 1 cú click, không cần xếp tay!", MessageType.Info);

            targetTerrain = (Terrain)EditorGUILayout.ObjectField("Terrain", targetTerrain, typeof(Terrain), true);
            plotPrefab = (GameObject)EditorGUILayout.ObjectField("Plot Prefab", plotPrefab, typeof(GameObject), false);
            
            if (targetTerrain != null)
            {
                // Hiển thị danh sách Tree Prototypes để người dùng chọn
                TreePrototype[] prototypes = targetTerrain.terrainData.treePrototypes;
                string[] options = new string[prototypes.Length];
                for (int i = 0; i < prototypes.Length; i++)
                {
                    options[i] = i + ": " + (prototypes[i].prefab != null ? prototypes[i].prefab.name : "Missing Prefab");
                }
                
                treePrototypeIndex = EditorGUILayout.Popup("Chọn Cây (Tree Index)", treePrototypeIndex, options);
            }

            parentTransform = (Transform)EditorGUILayout.ObjectField("Group Folder (Tùy chọn)", parentTransform, typeof(Transform), true);

            GUILayout.Space(20);

            if (GUILayout.Button("1. Biến Cây Lúa thành Ô Đất (Không xoá cây cũ)", GUILayout.Height(30)))
            {
                ConvertTrees(false);
            }
            
            if (GUILayout.Button("2. Xoá Cây Lúa trên Terrain (Sau khi đã check kỹ)", GUILayout.Height(30)))
            {
                RemoveTrees();
            }
        }

        private void ConvertTrees(bool removeAfter)
        {
            if (targetTerrain == null || plotPrefab == null)
            {
                EditorUtility.DisplayDialog("Lỗi", "Vui lòng gán Terrain và Plot Prefab!", "OK");
                return;
            }

            TerrainData tData = targetTerrain.terrainData;
            TreeInstance[] instances = tData.treeInstances;
            
            // Tạo một GameObject rỗng để chứa toàn bộ các ô đất cho gọn Hierarchy
            if (parentTransform == null)
            {
                GameObject group = new GameObject("Farm_Plots_Generated");
                parentTransform = group.transform;
            }

            int count = 0;
            for (int i = 0; i < instances.Length; i++)
            {
                if (instances[i].prototypeIndex == treePrototypeIndex)
                {
                    // Tính toạ độ thực tế trên Scene
                    Vector3 localPos = new Vector3(
                        instances[i].position.x * tData.size.x,
                        instances[i].position.y * tData.size.y,
                        instances[i].position.z * tData.size.z
                    );
                    Vector3 worldPos = targetTerrain.transform.position + localPos;

                    // Tạo Plot
                    GameObject newPlot = (GameObject)PrefabUtility.InstantiatePrefab(plotPrefab);
                    newPlot.transform.position = worldPos;
                    newPlot.transform.SetParent(parentTransform);
                    count++;
                }
            }

            Debug.Log($"<color=green>Đã sinh ra {count} ô đất thành công!</color>");
        }

        private void RemoveTrees()
        {
            if (targetTerrain == null) return;
            
            if (EditorUtility.DisplayDialog("Cảnh báo", "Hành động này sẽ xoá toàn bộ cây lúa (loại bạn đang chọn) trên Terrain. Bạn có chắc chắn không?", "Xoá luôn", "Hủy"))
            {
                TerrainData tData = targetTerrain.terrainData;
                TreeInstance[] instances = tData.treeInstances;
                List<TreeInstance> newInstances = new List<TreeInstance>();

                int removedCount = 0;
                for (int i = 0; i < instances.Length; i++)
                {
                    if (instances[i].prototypeIndex != treePrototypeIndex)
                    {
                        newInstances.Add(instances[i]);
                    }
                    else
                    {
                        removedCount++;
                    }
                }

                tData.treeInstances = newInstances.ToArray();
                targetTerrain.Flush(); // Cập nhật lại Terrain
                Debug.Log($"<color=orange>Đã xoá {removedCount} cây lúa khỏi Terrain.</color>");
            }
        }
    }
}

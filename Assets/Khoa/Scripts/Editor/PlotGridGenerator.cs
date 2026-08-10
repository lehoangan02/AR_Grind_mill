using UnityEngine;
using UnityEditor;

namespace Khoa.Farming.Editor
{
    public class PlotGridGenerator : EditorWindow
    {
        private GameObject plotPrefab;
        private Transform gridOrigin;
        private int rows = 20;
        private int columns = 20;
        private float spacingX = 1.0f;
        private float spacingZ = 1.0f;
        private float maxHeight = 100f; // Ngưỡng độ cao mặc định
        private float yOffset = 0.08f; // Độ nổi của ô đất so với mặt đất
        
        [MenuItem("Khoa/Farming/Generate Plot Grid")]
        public static void ShowWindow()
        {
            GetWindow<PlotGridGenerator>("Grid Generator");
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
            EditorGUILayout.HelpBox("Y Offset: Tăng số này lên nếu ô đất vẫn bị chìm/cắt xén vào bề mặt Terrain gồ ghề. (0.05 là vừa vặn, 0.1 là nổi hẳn lên)", MessageType.Info);
            yOffset = EditorGUILayout.FloatField("Độ nổi (Y Offset)", yOffset);

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

            // Tự động xoá các Grid cũ (để tránh đè lên nhau nếu user quên xoá)
            GameObject[] allObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
            foreach (var obj in allObjects)
            {
                if (obj.name.StartsWith("Farm_Grid_"))
                {
                    DestroyImmediate(obj);
                }
            }

            // Tạo một group để chứa toàn bộ grid cho gọn Hierarchy
            GameObject group = new GameObject("Farm_Grid_" + System.DateTime.Now.ToString("HHmmss"));
            group.transform.position = gridOrigin.position;

            int count = 0;
            
            // Tính kích thước thực tế của 1 ô (D)
            float plotSizeX = 1f;
            float plotSizeZ = 1f;
            
            BoxCollider col = plotPrefab.GetComponent<BoxCollider>();
            if (col != null)
            {
                plotSizeX = col.size.x * plotPrefab.transform.localScale.x;
                plotSizeZ = col.size.z * plotPrefab.transform.localScale.z;
            }
            else
            {
                plotSizeX = plotPrefab.transform.localScale.x;
                plotSizeZ = plotPrefab.transform.localScale.z;
            }

            // Khoảng cách thực tế giữa tâm ô này đến tâm ô kia
            float stepX = plotSizeX + spacingX;
            float stepZ = plotSizeZ + spacingZ;

            // Tổng chiều dài và rộng của toàn bộ lưới Grid
            float totalWidth = (columns * plotSizeX) + ((columns - 1) * spacingX);
            float totalLength = (rows * plotSizeZ) + ((rows - 1) * spacingZ);

            // Tìm điểm xuất phát (Góc dưới cùng bên trái của Grid)
            Vector3 gridBottomLeft = gridOrigin.position - new Vector3(totalWidth / 2f, 0, totalLength / 2f);
            
            // Toạ độ tâm của ô đất đầu tiên (phải cộng thêm nửa kích thước của ô đó)
            Vector3 startPos = gridBottomLeft + new Vector3(plotSizeX / 2f, 0, plotSizeZ / 2f);

            for (int x = 0; x < columns; x++)
            {
                for (int z = 0; z < rows; z++)
                {
                    // Đặt điểm bắt đầu bắn tia Laser ở tít trên cao (Y + 1000)
                    Vector3 rayStart = new Vector3(startPos.x + x * stepX, gridOrigin.position.y + 1000f, startPos.z + z * stepZ);
                    
                    // Bắn xuyên qua mọi thứ (RaycastAll) để tìm đúng mặt đất (Terrain) kể cả khi có lớp nước che phủ
                    RaycastHit[] hits = Physics.RaycastAll(rayStart, Vector3.down, 2000f);
                    foreach (var hit in hits)
                    {
                        // Kiểm tra xem tia raycast có trúng Terrain không (bỏ qua mặt nước)
                        if (hit.collider is TerrainCollider || hit.collider.gameObject.name.Contains("Terrain"))
                        {
                            // Kiểm tra xem mặt đất ở đó có bị nhô cao quá không (có phải là bờ ruộng không)
                            if (hit.point.y <= maxHeight)
                            {
                                GameObject newPlot = (GameObject)PrefabUtility.InstantiatePrefab(plotPrefab);
                                
                                // Bẻ nghiêng cái ô đất cho nó úp sát bám theo độ dốc của mặt đất
                                newPlot.transform.up = hit.normal;
                                
                                // Gắn chặt xuống mặt đất + nhấc thẳng đứng lên theo trục Y toàn cục (để chắc chắn nó nổi lên)
                                newPlot.transform.position = hit.point + new Vector3(0, yOffset, 0); 

                                newPlot.transform.SetParent(group.transform);
                                count++;
                            }
                            break; // Đã tìm thấy Terrain ở tọa độ X,Z này rồi thì không xét các hit khác nữa
                        }
                    }
                }
            }

            Debug.Log($"<color=green>Đã sinh ra {count} ô đất thành công dọc theo vùng ngập nước!</color>");
        }
    }
}

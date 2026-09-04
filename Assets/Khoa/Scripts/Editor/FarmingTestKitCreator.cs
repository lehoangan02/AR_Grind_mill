using UnityEngine;
using UnityEditor;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;

namespace Khoa.Farming.Editor
{
    public class FarmingTestKitCreator : EditorWindow
    {
        [MenuItem("Khoa/Tạo Bộ Công Cụ Nông Nghiệp (Test)")]
        public static void CreateTestKit()
        {
            // 1. Tự động thêm các Tag cần thiết vào Project
            AddTag("Plow");
            AddTag("Seed");
            AddTag("Fertilizer");
            AddTag("Water");
            AddTag("Sickle");

            // 2. Tìm cái bàn (nếu có) để đặt đồ nghề lên
            GameObject table = GameObject.Find("TestTable");
            Vector3 spawnPos = Vector3.zero;
            if (table != null)
            {
                // Thêm một đoạn offset bự bự một chút lên trên mặt bàn để không bị cắm vào trong bàn
                spawnPos = table.transform.position + Vector3.up * (table.transform.localScale.y / 2f + 0.5f);
            }
            else if (SceneView.lastActiveSceneView != null)
            {
                spawnPos = SceneView.lastActiveSceneView.pivot;
            }

            // 3. Tạo một cái mâm chứa đồ nghề
            GameObject kit = new GameObject("Farming_Test_Kit");
            kit.transform.position = spawnPos;

            // 4. Tạo từng món đồ nghề
            CreateTool("Cuoc_Dat (Plow)", "Plow", Color.gray, kit.transform, new Vector3(-0.8f, 0, 0));
            CreateTool("Bo_Ma (Seed)", "Seed", Color.green, kit.transform, new Vector3(-0.4f, 0, 0));
            CreateTool("Phan_Bon (Fertilizer)", "Fertilizer", new Color(0.5f, 0.3f, 0f), kit.transform, new Vector3(0, 0, 0));
            CreateTool("Binh_Tuoi (Water)", "Water", Color.blue, kit.transform, new Vector3(0.4f, 0, 0));
            CreateTool("Luoi_Liem (Sickle)", "Sickle", Color.red, kit.transform, new Vector3(0.8f, 0, 0));

            Selection.activeGameObject = kit;
            Debug.Log("<color=green>Đã tạo thành công Bộ đồ nghề trên Bàn! Hãy đeo kính VR, cầm từng món đập vào ô đất để test.</color>");
        }

        private static void CreateTool(string name, string tag, Color color, Transform parent, Vector3 offset)
        {
            // Tạo hình khối
            GameObject tool = GameObject.CreatePrimitive(PrimitiveType.Cube);
            tool.name = name;
            tool.tag = tag;
            tool.transform.SetParent(parent);
            tool.transform.localPosition = offset;
            tool.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f); // Kích thước vừa tay cầm VR

            // Đổi màu để dễ nhận diện (Hỗ trợ URP)
            MeshRenderer renderer = tool.GetComponent<MeshRenderer>();
            Shader urpShader = Shader.Find("Universal Render Pipeline/Lit");
            if (urpShader == null) urpShader = Shader.Find("Standard"); // Fallback nếu không xài URP
            
            Material mat = new Material(urpShader);
            mat.color = color;
            renderer.material = mat;

            // BoxCollider có sẵn từ CreatePrimitive. Cần đảm bảo isTrigger = false để va chạm vật lý với đất.
            BoxCollider col = tool.GetComponent<BoxCollider>();
            col.isTrigger = false;

            // Thêm Rigidbody (Bắt buộc phải có để tương tác vật lý và cầm nắm)
            Rigidbody rb = tool.AddComponent<Rigidbody>();
            rb.mass = 1f;

            // Thêm XR Grab Interactable (Để cầm nắm được bằng tay VR)
            XRGrabInteractable grabInteractable = tool.AddComponent<XRGrabInteractable>();
            
            // Đảm bảo Layer tương tác hợp lý
            grabInteractable.interactionLayers = InteractionLayerMask.GetMask("Default");
        }

        private static void AddTag(string tag)
        {
            UnityEngine.Object[] asset = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset");
            if (asset != null && asset.Length > 0)
            {
                SerializedObject tagManager = new SerializedObject(asset[0]);
                SerializedProperty tagsProp = tagManager.FindProperty("tags");

                bool found = false;
                for (int i = 0; i < tagsProp.arraySize; i++)
                {
                    SerializedProperty t = tagsProp.GetArrayElementAtIndex(i);
                    if (t.stringValue.Equals(tag))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    tagsProp.InsertArrayElementAtIndex(tagsProp.arraySize);
                    SerializedProperty newTag = tagsProp.GetArrayElementAtIndex(tagsProp.arraySize - 1);
                    newTag.stringValue = tag;
                    tagManager.ApplyModifiedProperties();
                }
            }
        }
    }
}

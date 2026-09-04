using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Khoa.Farming.Editor
{
    public static class BarnAndCompostSceneIntegrator
    {
        private const string ScenePath = "Assets/Scenes/Grind mill v1.0 Scene.unity";
        public const string SetupRootName = "Khoa_Barn_And_Compost_Setup";

        [MenuItem("Khoa/Farming/Apply Barn & Compost Setup")]
        public static void ApplyBarnAndCompostSetupMenu()
        {
            ApplyBarnAndCompostSetup();
        }

        public static void ApplyBarnAndCompostSetup()
        {
            Scene activeScene = EditorSceneManager.GetActiveScene();
            if (activeScene.path != ScenePath)
            {
                activeScene = EditorSceneManager.OpenScene(ScenePath, OpenSceneMode.Single);
            }

            Debug.Log("<b>[BARN & COMPOST]</b> Bắt đầu thiết lập khu Chuồng Trại, Đống Ủ Phân và Xẻng xúc...");

            GameObject previousRoot = GameObject.Find(SetupRootName);
            if (previousRoot != null)
            {
                Object.DestroyImmediate(previousRoot);
            }

            GameObject root = new GameObject(SetupRootName);
            Undo.RegisterCreatedObjectUndo(root, "Create Barn & Compost Setup");

            // Compact service yard beside the existing StiltHouse (-14,-22) and playable buffalo.
            // Keeping the whole loop together makes the shovel route readable in VR.
            Terrain activeTerrain = Terrain.activeTerrain;

            // 1. Tạo Chuồng Trâu (Buffalo Barn)
            Vector3 buffaloPos = new Vector3(-21.5f, 100f, -17f);
            buffaloPos.y = GetTerrainHeight(buffaloPos, activeTerrain);
            GameObject buffaloBarnGO = CreateBuffaloBarn(root.transform, buffaloPos);
            BarnManureSource buffaloSource = buffaloBarnGO.GetComponentInChildren<BarnManureSource>();

            // 2. Tạo Chuồng Bò (Cow Barn)
            Vector3 cowPos = new Vector3(-20f, 100f, -24f);
            cowPos.y = GetTerrainHeight(cowPos, activeTerrain);
            GameObject cowBarnGO = CreateCowBarn(root.transform, cowPos);
            BarnManureSource cowSource = cowBarnGO.GetComponentInChildren<BarnManureSource>();

            // 3. Tạo Chuồng Heo (Pigsty)
            Vector3 pigPos = new Vector3(-8.5f, 100f, -18f);
            pigPos.y = GetTerrainHeight(pigPos, activeTerrain);
            GameObject pigBarnGO = CreatePigBarn(root.transform, pigPos);
            BarnManureSource pigSource = pigBarnGO.GetComponentInChildren<BarnManureSource>();

            // 4. Tạo Đống Ủ Phân Sinh Học (Compost Pile)
            Vector3 compostPos = new Vector3(-8.5f, 100f, -25f);
            compostPos.y = GetTerrainHeight(compostPos, activeTerrain);
            GameObject compostGO = CreateCompostStation(root.transform, compostPos);
            CompostPile compost = compostGO.GetComponent<CompostPile>();

            // 5. Tạo Xẻng Xúc Phân Cầm Tay (Manure Shovel)
            Vector3 shovelPos = compostPos + new Vector3(1.2f, 0.4f, 0.5f);
            GameObject shovelGO = CreateManureShovel(root.transform, shovelPos);
            ManureShovel shovel = shovelGO.GetComponent<ManureShovel>();

            // 6. Tạo Bảng Hướng Dẫn Nhiệm Vụ 3D (BarnCompostQuestGuide)
            Vector3 guidePos = compostPos + new Vector3(1.8f, 1.15f, -1.2f);
            CreateQuestGuide(root.transform, guidePos, new BarnManureSource[] { buffaloSource, cowSource, pigSource }, shovel, compost);

            EditorSceneManager.MarkSceneDirty(activeScene);
            EditorSceneManager.SaveScene(activeScene);

            Debug.Log("<color=green><b>[BARN & COMPOST] THÀNH CÔNG:</b> Đã thiết lập xong 3 chuồng trại, đống ủ phân 90s, xẻng xúc và bảng hướng dẫn!</color>");
        }

        private static float GetTerrainHeight(Vector3 pos, Terrain terrain)
        {
            if (terrain != null)
            {
                return terrain.SampleHeight(pos) + terrain.transform.position.y;
            }
            return pos.y;
        }

        private static GameObject CreateBuffaloBarn(Transform parent, Vector3 pos)
        {
            GameObject barnGO = new GameObject("Barn_Buffalo_Area");
            barnGO.transform.SetParent(parent);
            barnGO.transform.position = pos;

            CreateFenceEnclosure(barnGO.transform, new Vector3(4.5f, 1.2f, 4f));

            // Tìm hoặc đặt model trâu
            GameObject buffaloSourceModel = GameObject.Find("WaterBuffalo");
            if (buffaloSourceModel != null)
            {
                GameObject buffaloInst = Object.Instantiate(buffaloSourceModel, barnGO.transform);
                buffaloInst.name = "WaterBuffalo_Barn_Visual";
                buffaloInst.transform.position = pos + new Vector3(0f, 0f, 0.5f);
                buffaloInst.transform.rotation = Quaternion.Euler(0f, UnityEngine.Random.Range(30f, 60f), 0f);

                // Gỡ bỏ Plow attachment và Rider script nếu có trên bản clone visual để tránh xung đột
                BuffaloPlowAttachment[] plows = buffaloInst.GetComponentsInChildren<BuffaloPlowAttachment>(true);
                for (int i = plows.Length - 1; i >= 0; i--)
                {
                    if (plows[i] != null)
                    {
                        Object.DestroyImmediate(plows[i].gameObject);
                    }
                }

                foreach (var comp in buffaloInst.GetComponents<MonoBehaviour>())
                {
                    if (comp != null && comp.GetType().Name == "BuffaloRider")
                    {
                        Object.DestroyImmediate(comp);
                    }
                }
            }

            BarnManureSource source = barnGO.AddComponent<BarnManureSource>();
            source.animalType = BarnAnimalType.Buffalo;
            source.respawnCooldown = 120f;
            source.maxUncollected = 2;

            return barnGO;
        }

        private static GameObject CreateCowBarn(Transform parent, Vector3 pos)
        {
            GameObject barnGO = new GameObject("Barn_Cow_Area");
            barnGO.transform.SetParent(parent);
            barnGO.transform.position = pos;

            CreateFenceEnclosure(barnGO.transform, new Vector3(4.5f, 1.2f, 4f));

            string cowPrefabPath = "Assets/_Environment/Cow/Prefab/Cow.prefab";
            GameObject cowPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(cowPrefabPath);
            if (cowPrefab != null)
            {
                GameObject cowInst = (GameObject)PrefabUtility.InstantiatePrefab(cowPrefab, barnGO.transform);
                cowInst.name = "Cow_Barn_Visual";
                cowInst.transform.position = pos + new Vector3(0f, 0f, 0.5f);
                cowInst.transform.rotation = Quaternion.Euler(0f, 120f, 0f);
            }

            BarnManureSource source = barnGO.AddComponent<BarnManureSource>();
            source.animalType = BarnAnimalType.Cow;
            source.respawnCooldown = 120f;
            source.maxUncollected = 2;

            return barnGO;
        }

        private static GameObject CreatePigBarn(Transform parent, Vector3 pos)
        {
            GameObject barnGO = new GameObject("Barn_Pig_Area");
            barnGO.transform.SetParent(parent);
            barnGO.transform.position = pos;

            string pigstyPath = "Assets/_Environment/Pig/Prefab/Pigsty.prefab";
            GameObject pigstyPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(pigstyPath);
            if (pigstyPrefab != null)
            {
                GameObject styInst = (GameObject)PrefabUtility.InstantiatePrefab(pigstyPrefab, barnGO.transform);
                styInst.name = "Pigsty_Structure";
                styInst.transform.position = pos;
            }
            else
            {
                CreateFenceEnclosure(barnGO.transform, new Vector3(4f, 1.0f, 3.5f));
            }

            string pigPath = "Assets/_Environment/Pig/Prefab/Pig.prefab";
            GameObject pigPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(pigPath);
            if (pigPrefab != null)
            {
                GameObject pigInst = (GameObject)PrefabUtility.InstantiatePrefab(pigPrefab, barnGO.transform);
                pigInst.name = "Pig_Visual_1";
                pigInst.transform.position = pos + new Vector3(-0.8f, 0f, 0.2f);

                GameObject pigInst2 = (GameObject)PrefabUtility.InstantiatePrefab(pigPrefab, barnGO.transform);
                pigInst2.name = "Pig_Visual_2";
                pigInst2.transform.position = pos + new Vector3(0.8f, 0f, -0.4f);
            }

            BarnManureSource source = barnGO.AddComponent<BarnManureSource>();
            source.animalType = BarnAnimalType.Pig;
            source.respawnCooldown = 120f;
            source.maxUncollected = 2;

            return barnGO;
        }

        private static void CreateFenceEnclosure(Transform parent, Vector3 size)
        {
            GameObject fence = new GameObject("Fence_Enclosure");
            fence.transform.SetParent(parent, false);

            Material woodMat = new Material(Shader.Find("Universal Render Pipeline/Lit") ?? Shader.Find("Standard"));
            woodMat.color = new Color(0.42f, 0.28f, 0.16f);

            // 4 cọc góc
            Vector3[] postOffsets = new Vector3[]
            {
                new Vector3(-size.x * 0.5f, size.y * 0.5f, -size.z * 0.5f),
                new Vector3(size.x * 0.5f, size.y * 0.5f, -size.z * 0.5f),
                new Vector3(-size.x * 0.5f, size.y * 0.5f, size.z * 0.5f),
                new Vector3(size.x * 0.5f, size.y * 0.5f, size.z * 0.5f)
            };

            for (int i = 0; i < postOffsets.Length; i++)
            {
                GameObject post = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                post.name = $"Post_{i + 1}";
                post.transform.SetParent(fence.transform, false);
                post.transform.localPosition = postOffsets[i];
                post.transform.localScale = new Vector3(0.12f, size.y * 0.5f, 0.12f);
                if (post.GetComponent<Renderer>() != null) post.GetComponent<Renderer>().sharedMaterial = woodMat;
            }

            // Thanh ngang
            CreateRail(fence.transform, new Vector3(0f, size.y * 0.4f, -size.z * 0.5f), new Vector3(size.x, 0.08f, 0.08f), woodMat);
            CreateRail(fence.transform, new Vector3(0f, size.y * 0.8f, -size.z * 0.5f), new Vector3(size.x, 0.08f, 0.08f), woodMat);

            CreateRail(fence.transform, new Vector3(0f, size.y * 0.4f, size.z * 0.5f), new Vector3(size.x, 0.08f, 0.08f), woodMat);
            CreateRail(fence.transform, new Vector3(0f, size.y * 0.8f, size.z * 0.5f), new Vector3(size.x, 0.08f, 0.08f), woodMat);

            CreateRail(fence.transform, new Vector3(-size.x * 0.5f, size.y * 0.4f, 0f), new Vector3(0.08f, 0.08f, size.z), woodMat);
            CreateRail(fence.transform, new Vector3(-size.x * 0.5f, size.y * 0.8f, 0f), new Vector3(0.08f, 0.08f, size.z), woodMat);
        }

        private static void CreateRail(Transform parent, Vector3 localPos, Vector3 localScale, Material mat)
        {
            GameObject rail = GameObject.CreatePrimitive(PrimitiveType.Cube);
            rail.name = "Fence_Rail";
            rail.transform.SetParent(parent, false);
            rail.transform.localPosition = localPos;
            rail.transform.localScale = localScale;
            if (rail.GetComponent<Renderer>() != null) rail.GetComponent<Renderer>().sharedMaterial = mat;
        }

        private static GameObject CreateCompostStation(Transform parent, Vector3 pos)
        {
            GameObject stationGO = new GameObject("Compost_Station");
            stationGO.transform.SetParent(parent);
            stationGO.transform.position = pos;

            // Đống đất ủ hữu cơ
            GameObject pileMesh = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            pileMesh.name = "Compost_Mound_Mesh";
            pileMesh.transform.SetParent(stationGO.transform, false);
            pileMesh.transform.localPosition = new Vector3(0f, 0.25f, 0f);
            pileMesh.transform.localScale = new Vector3(2.2f, 0.35f, 2.2f);

            Material compostMat = new Material(Shader.Find("Universal Render Pipeline/Lit") ?? Shader.Find("Standard"));
            compostMat.color = new Color(0.38f, 0.26f, 0.14f);
            Renderer pileRend = pileMesh.GetComponent<Renderer>();
            if (pileRend != null) pileRend.sharedMaterial = compostMat;

            // Vùng Trigger để xẻng đưa vào
            BoxCollider triggerBox = stationGO.AddComponent<BoxCollider>();
            triggerBox.isTrigger = true;
            triggerBox.center = new Vector3(0f, 0.5f, 0f);
            triggerBox.size = new Vector3(2.4f, 1.2f, 2.4f);

            CompostPile compost = stationGO.AddComponent<CompostPile>();
            compost.pileRenderer = pileRend;
            compost.requiredPortions = 3;
            compost.compostDuration = 90f;

            // UI Bảng Tiến độ World-Space
            GameObject uiGO = new GameObject("Compost_Status_Board");
            uiGO.transform.SetParent(stationGO.transform, false);
            uiGO.transform.localPosition = new Vector3(0f, 1.6f, 0f);
            uiGO.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);

            TextMeshPro tmp = uiGO.AddComponent<TextMeshPro>();
            tmp.fontSize = 0.75f;
            tmp.rectTransform.sizeDelta = new Vector2(1.5f, 0.9f);
            tmp.alignment = TextAlignmentOptions.Center;
            tmp.text = "<color=yellow>ĐỐNG Ủ PHÂN</color>\nTrống (0/3)\n<i>Dùng xẻng xúc phân đổ vào</i>";
            compost.progressText = tmp;

            return stationGO;
        }

        private static GameObject CreateManureShovel(Transform parent, Vector3 pos)
        {
            GameObject shovelGO = new GameObject("Manure_Shovel");
            shovelGO.transform.SetParent(parent);
            shovelGO.transform.position = pos;

            Rigidbody rb = shovelGO.AddComponent<Rigidbody>();
            rb.mass = 2.5f;
            rb.interpolation = RigidbodyInterpolation.Interpolate;

            XRGrabInteractable grab = shovelGO.AddComponent<XRGrabInteractable>();
            grab.movementType = XRBaseInteractable.MovementType.VelocityTracking;

            Material woodMat = new Material(Shader.Find("Universal Render Pipeline/Lit") ?? Shader.Find("Standard"));
            woodMat.color = new Color(0.55f, 0.38f, 0.22f);

            Material ironMat = new Material(Shader.Find("Universal Render Pipeline/Lit") ?? Shader.Find("Standard"));
            ironMat.color = new Color(0.3f, 0.32f, 0.35f);

            // Cán xẻng (Handle)
            GameObject handle = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            handle.name = "Shovel_Handle";
            handle.transform.SetParent(shovelGO.transform, false);
            handle.transform.localPosition = new Vector3(0f, 0.45f, 0f);
            handle.transform.localScale = new Vector3(0.04f, 0.45f, 0.04f);
            if (handle.GetComponent<Renderer>() != null) handle.GetComponent<Renderer>().sharedMaterial = woodMat;

            // Lưỡi xẻng (Blade)
            GameObject blade = GameObject.CreatePrimitive(PrimitiveType.Cube);
            blade.name = "Shovel_Blade";
            blade.transform.SetParent(shovelGO.transform, false);
            blade.transform.localPosition = new Vector3(0f, -0.05f, 0f);
            blade.transform.localScale = new Vector3(0.24f, 0.02f, 0.32f);
            if (blade.GetComponent<Renderer>() != null) blade.GetComponent<Renderer>().sharedMaterial = ironMat;

            // Visual phân trên lưỡi xẻng khi đầy
            GameObject manureVisual = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            manureVisual.name = "Manure_On_Blade_Visual";
            manureVisual.transform.SetParent(blade.transform, false);
            manureVisual.transform.localPosition = new Vector3(0f, 2.5f, 0f);
            manureVisual.transform.localScale = new Vector3(0.8f, 0.4f, 0.8f);
            manureVisual.SetActive(false);
            if (manureVisual.GetComponent<Collider>() != null) Object.DestroyImmediate(manureVisual.GetComponent<Collider>());
            if (manureVisual.GetComponent<Renderer>() != null)
            {
                Material mMat = new Material(Shader.Find("Universal Render Pipeline/Lit") ?? Shader.Find("Standard"));
                mMat.color = new Color(0.35f, 0.22f, 0.12f);
                manureVisual.GetComponent<Renderer>().sharedMaterial = mMat;
            }

            // Blade Trigger Collider
            BoxCollider triggerCol = shovelGO.AddComponent<BoxCollider>();
            triggerCol.isTrigger = true;
            triggerCol.center = new Vector3(0f, -0.05f, 0f);
            triggerCol.size = new Vector3(0.3f, 0.2f, 0.4f);

            ManureShovel shovel = shovelGO.AddComponent<ManureShovel>();
            shovel.bladeTriggerCollider = triggerCol;
            shovel.manureVisualOnBlade = manureVisual;

            return shovelGO;
        }

        private static void CreateQuestGuide(Transform parent, Vector3 pos, BarnManureSource[] sources, ManureShovel shovel, CompostPile compost)
        {
            GameObject guideGO = new GameObject("Barn_Compost_Quest_Guide");
            guideGO.transform.SetParent(parent);
            guideGO.transform.position = pos;
            guideGO.transform.rotation = Quaternion.Euler(0f, 180f, 0f);

            BarnCompostQuestGuide guide = guideGO.AddComponent<BarnCompostQuestGuide>();
            guide.manureSources = sources;
            guide.shovel = shovel;
            guide.compostPile = compost;

            // Bảng gỗ phía sau
            GameObject board = GameObject.CreatePrimitive(PrimitiveType.Cube);
            board.name = "Guide_Board_Backing";
            board.transform.SetParent(guideGO.transform, false);
            board.transform.localPosition = new Vector3(0f, 0f, 0.05f);
            board.transform.localScale = new Vector3(1.6f, 1.1f, 0.04f);

            Material boardMat = new Material(Shader.Find("Universal Render Pipeline/Lit") ?? Shader.Find("Standard"));
            boardMat.color = new Color(0.2f, 0.15f, 0.1f);
            if (board.GetComponent<Renderer>() != null) board.GetComponent<Renderer>().sharedMaterial = boardMat;

            // Text tiêu đề
            GameObject titleGO = new GameObject("Quest_Title");
            titleGO.transform.SetParent(guideGO.transform, false);
            titleGO.transform.localPosition = new Vector3(0f, 0.35f, 0f);
            TextMeshPro titleTMP = titleGO.AddComponent<TextMeshPro>();
            titleTMP.fontSize = 0.62f;
            titleTMP.rectTransform.sizeDelta = new Vector2(1.5f, 0.3f);
            titleTMP.alignment = TextAlignmentOptions.Center;
            titleTMP.text = "<color=yellow><b>HƯỚNG DẪN Ủ PHÂN BÓN LÓT</b></color>";
            guide.questTitleText = titleTMP;

            // Text chi tiết
            GameObject detailGO = new GameObject("Step_Detail");
            detailGO.transform.SetParent(guideGO.transform, false);
            detailGO.transform.localPosition = new Vector3(0f, -0.05f, 0f);
            TextMeshPro detailTMP = detailGO.AddComponent<TextMeshPro>();
            detailTMP.fontSize = 0.48f;
            detailTMP.rectTransform.sizeDelta = new Vector2(1.45f, 0.72f);
            detailTMP.alignment = TextAlignmentOptions.Center;
            guide.stepDetailText = detailTMP;
        }
    }
}

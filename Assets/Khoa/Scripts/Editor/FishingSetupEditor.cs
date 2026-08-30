using UnityEngine;
using UnityEditor;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using TMPro;

namespace Khoa.Farming.Editor
{
    public static class FishingSetupEditor
    {
        [MenuItem("Khoa/Fishing/Setup Fishing Mechanics in Scene")]
        public static void SetupFishingInScene()
        {
            Debug.Log("<b>[FISHING SETUP]</b> Đang thiết lập hệ thống cần câu và vùng câu cá vào Scene...");

            GameObject root = GameObject.Find("Khoa_Fishing_Runtime_Setup");
            if (root == null)
            {
                root = new GameObject("Khoa_Fishing_Runtime_Setup");
                Undo.RegisterCreatedObjectUndo(root, "Create Fishing Setup Root");
            }

            // 1. Tìm hoặc tạo Cần câu (VRFishingController)
            VRFishingController fishingController = Object.FindAnyObjectByType<VRFishingController>();
            if (fishingController == null)
            {
                GameObject rodModelPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/_Environment/FishingRod/fish_rod.fbx");
                GameObject rodGO;
                if (rodModelPrefab != null)
                {
                    rodGO = (GameObject)PrefabUtility.InstantiatePrefab(rodModelPrefab, root.transform);
                    rodGO.name = "VR_Fishing_Rod";
                }
                else
                {
                    rodGO = new GameObject("VR_Fishing_Rod");
                    rodGO.transform.SetParent(root.transform);
                }

                rodGO.transform.position = new Vector3(-12.5f, 103.2f, -20.5f);
                rodGO.transform.rotation = Quaternion.Euler(0, 45f, 0);

                fishingController = rodGO.AddComponent<VRFishingController>();
                Undo.RegisterCreatedObjectUndo(rodGO, "Create Fishing Rod");
            }

            if (fishingController == null || fishingController.gameObject == null)
            {
                Debug.LogError("<b>[FISHING SETUP] LỖI:</b> Không thể tạo hoặc tìm thấy VRFishingController!");
                return;
            }

            GameObject rodObj = fishingController.gameObject;

            // 2. Tạo / Căn chỉnh TopAnchor (Điểm Anchor cao nhất của ngọn cần câu)
            Transform tipTrans = rodObj.transform.Find("TopAnchor");
            if (tipTrans == null)
            {
                tipTrans = rodObj.transform.Find("Anchor") ?? rodObj.transform.Find("Top") ?? rodObj.transform.Find("RodTipPoint");
            }

            if (tipTrans == null)
            {
                GameObject tipGO = new GameObject("TopAnchor");
                tipGO.transform.SetParent(rodObj.transform, false);
                tipGO.transform.localPosition = CalculateRodTipLocalPosition(rodObj);
                tipTrans = tipGO.transform;
            }
            else
            {
                tipTrans.name = "TopAnchor";
            }
            fishingController.topAnchor = tipTrans;

            // 3. Đảm bảo HookWithLine & HookMesh tồn tại và nối vào Ngọn Cần TopAnchor
            if (fishingController.hookWithLine == null)
            {
                Transform lineTrans = rodObj.transform.Find("HookWithLine");
                if (lineTrans == null)
                {
                    GameObject lineGO = new GameObject("HookWithLine");
                    lineGO.transform.SetParent(rodObj.transform, false);
                    lineGO.transform.position = tipTrans.position;
                    lineTrans = lineGO.transform;
                }
                fishingController.hookWithLine = lineTrans;
            }
            else
            {
                fishingController.hookWithLine.position = tipTrans.position;
            }

            if (fishingController.hookMesh == null && fishingController.hookWithLine != null)
            {
                Transform meshTrans = fishingController.hookWithLine.Find("HookMesh");
                if (meshTrans == null)
                {
                    GameObject hookMeshGO = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    hookMeshGO.name = "HookMesh";
                    hookMeshGO.transform.SetParent(fishingController.hookWithLine, false);
                    hookMeshGO.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    meshTrans = hookMeshGO.transform;
                }
                fishingController.hookMesh = meshTrans;
            }

            // 4. Căn chỉnh Bounding Box (BoxCollider) ôm sát cán cần câu
            Rigidbody rb = rodObj.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = rodObj.AddComponent<Rigidbody>();
                rb.isKinematic = true;
                rb.useGravity = false;
            }

            BoxCollider rodCol = rodObj.GetComponent<BoxCollider>();
            if (rodCol == null)
            {
                rodCol = rodObj.AddComponent<BoxCollider>();
            }
            rodCol.center = new Vector3(0f, 0.05f, 0.35f);
            rodCol.size = new Vector3(0.12f, 0.12f, 0.8f);

            // 5. Đảm bảo XRGrabInteractable
            XRGrabInteractable grab = rodObj.GetComponent<XRGrabInteractable>();
            if (grab == null)
            {
                grab = rodObj.AddComponent<XRGrabInteractable>();
                EditorUtility.SetDirty(rodObj);
            }

            // 6. Gán Audio Source và các âm thanh Procedural/Clip
            AudioSource audioSource = rodObj.GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = rodObj.AddComponent<AudioSource>();
            }

            audioSource.spatialBlend = 1.0f;
            audioSource.playOnAwake = false;

            if (fishingController.castSound == null) fishingController.castSound = FishingAudioFXHelper.CreateWaterSplashClip();
            if (fishingController.biteSound == null) fishingController.biteSound = FishingAudioFXHelper.CreateBiteAlertClip();
            if (fishingController.catchSound == null) fishingController.catchSound = FishingAudioFXHelper.CreateCatchSuccessClip();

            // 7. Gán prefab con cá mặc định (fish1.prefab)
            if (fishingController.fishPrefab == null)
            {
                string[] guids = AssetDatabase.FindAssets("fish1 t:Prefab");
                if (guids.Length > 0)
                {
                    string path = AssetDatabase.GUIDToAssetPath(guids[0]);
                    fishingController.fishPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
                }
            }

            // 8. Thêm Collider (isTrigger) + FishingHookTrigger lên PHAO (hookMesh) cuối dây
            if (fishingController.hookMesh != null)
            {
                Transform hookMeshTrans = fishingController.hookMesh;
                GameObject hookGO = hookMeshTrans.gameObject;

                // Đặt phao ở cuối dây (độ dài = idleScaleY) để khớp visual khi để cần nghỉ
                if (fishingController.hookWithLine != null)
                {
                    hookMeshTrans.SetParent(fishingController.hookWithLine, true);
                    hookMeshTrans.localPosition = new Vector3(0f, -fishingController.idleScaleY, 0f);
                }

                Collider lineCol = hookGO.GetComponent<Collider>();
                if (lineCol == null)
                {
                    SphereCollider sCol = hookGO.AddComponent<SphereCollider>();
                    sCol.isTrigger = true;
                    sCol.radius = 0.15f;
                }
                else
                {
                    lineCol.isTrigger = true;
                }

                FishingHookTrigger trigger = hookGO.GetComponent<FishingHookTrigger>();
                if (trigger == null)
                {
                    trigger = hookGO.AddComponent<FishingHookTrigger>();
                }

                if (trigger != null)
                {
                    trigger.fishingController = fishingController;
                    trigger.EnsureControllerReference();
                    EditorUtility.SetDirty(trigger);
                }
            }

            // 9. Tạo Bảng tương tác 1-click "LẤY / CẤT CẦN CÂU"
            SetupFishingStationBoard(root, fishingController);

            // 10. Tạo & vị trí các Vùng Câu Cá (Fishing Zones)
            SetupFishingZones(root);

            EditorUtility.SetDirty(fishingController);
            Debug.Log("<b>[FISHING SETUP] THÀNH CÔNG:</b> Đã tạo TopAnchor tại điểm cao nhất của ngọn cần câu và gán trực tiếp vào VRFishingController!");
        }

        private static Vector3 CalculateRodTipLocalPosition(GameObject rodObj)
        {
            MeshFilter[] filters = rodObj.GetComponentsInChildren<MeshFilter>();
            if (filters.Length == 0) return new Vector3(0f, 0.45f, 2.1f);

            Vector3 localTip = new Vector3(0f, 0.45f, 2.1f);
            float maxZ = float.MinValue;

            foreach (MeshFilter filter in filters)
            {
                if (filter.sharedMesh == null) continue;
                Vector3[] vertices = filter.sharedMesh.vertices;
                Transform t = filter.transform;

                foreach (Vector3 v in vertices)
                {
                    Vector3 worldV = t.TransformPoint(v);
                    Vector3 localV = rodObj.transform.InverseTransformPoint(worldV);

                    if (localV.z > maxZ)
                    {
                        maxZ = localV.z;
                        localTip = localV;
                    }
                }
            }

            return localTip;
        }

        private static void SetupFishingStationBoard(GameObject root, VRFishingController rod)
        {
            GameObject boardGO = GameObject.Find("Khoa_Fishing_Station_Board");
            if (boardGO == null)
            {
                boardGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
                boardGO.name = "Khoa_Fishing_Station_Board";
                boardGO.transform.SetParent(root.transform);
                boardGO.transform.position = new Vector3(-12f, 103.5f, -19.5f);
                boardGO.transform.rotation = Quaternion.Euler(0, 135f, 0);
                boardGO.transform.localScale = new Vector3(1.4f, 0.9f, 0.1f);
            }

            FishingStationBoard board = boardGO.GetComponent<FishingStationBoard>();
            if (board == null)
            {
                board = boardGO.AddComponent<FishingStationBoard>();
            }

            board.fishingRod = rod;
            board.defaultRackPosition = rod.transform.position;
            board.defaultRackRotation = rod.transform.rotation;

            Transform textTrans = boardGO.transform.Find("FishingBoard_Text");
            GameObject textGO;
            if (textTrans == null)
            {
                textGO = new GameObject("FishingBoard_Text");
                textGO.transform.SetParent(boardGO.transform, false);
                textGO.transform.localPosition = new Vector3(0, 0, -0.55f);
                textGO.transform.localRotation = Quaternion.Euler(0, 180f, 0);
                textTrans = textGO.transform;
            }
            else
            {
                textGO = textTrans.gameObject;
            }

            TextMeshPro text = textGO.GetComponent<TextMeshPro>();
            if (text == null)
            {
                text = textGO.AddComponent<TextMeshPro>();
            }

            text.fontSize = 3.5f;
            text.alignment = TextAlignmentOptions.Center;
            text.text = "<color=green>Bấm vào đây để LẤY Cần Câu</color>";
            board.statusText = text;

            EditorUtility.SetDirty(board);
        }

        private static void SetupFishingZones(GameObject root)
        {
            GameObject catfishZoneGO = GameObject.Find("FishingZone_Catfish_CauCaTra");
            if (catfishZoneGO == null)
            {
                catfishZoneGO = new GameObject("FishingZone_Catfish_CauCaTra");
                catfishZoneGO.transform.SetParent(root.transform);
                catfishZoneGO.transform.position = new Vector3(-15f, 100f, 10f);

                BoxCollider box = catfishZoneGO.AddComponent<BoxCollider>();
                box.isTrigger = true;
                box.size = new Vector3(10f, 4f, 10f);

                FishingZone zone = catfishZoneGO.AddComponent<FishingZone>();
                zone.zoneName = "Sau nhà chị Tám - Cầu Cá Tra";
                zone.fishType = FishType.Catfish;
                zone.minBiteDelay = 2.0f;
                zone.maxBiteDelay = 4.0f;
                zone.pullThresholdMultiplier = 1.2f;

                string[] guids = AssetDatabase.FindAssets("KoiFish t:Prefab");
                if (guids.Length > 0)
                {
                    zone.customFishPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(AssetDatabase.GUIDToAssetPath(guids[0]));
                }
            }

            GameObject snakeheadZoneGO = GameObject.Find("FishingZone_Snakehead_DeepRiver");
            if (snakeheadZoneGO == null)
            {
                snakeheadZoneGO = new GameObject("FishingZone_Snakehead_DeepRiver");
                snakeheadZoneGO.transform.SetParent(root.transform);
                snakeheadZoneGO.transform.position = new Vector3(-35f, 100f, 25f);

                BoxCollider box = snakeheadZoneGO.AddComponent<BoxCollider>();
                box.isTrigger = true;
                box.size = new Vector3(15f, 4f, 15f);

                FishingZone zone = snakeheadZoneGO.AddComponent<FishingZone>();
                zone.zoneName = "Vùng Sông Sâu - Câu Cá Lóc";
                zone.fishType = FishType.Snakehead;
                zone.minBiteDelay = 3.0f;
                zone.maxBiteDelay = 6.0f;
                zone.pullThresholdMultiplier = 1.4f;

                string[] guids = AssetDatabase.FindAssets("fish1 t:Prefab");
                if (guids.Length > 0)
                {
                    zone.customFishPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(AssetDatabase.GUIDToAssetPath(guids[0]));
                }
            }
        }
    }
}

using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Khoa.Farming.Boating.Editor
{
    public static class BoatingSceneIntegrator
    {
        private const string ScenePath = "Assets/Scenes/Grind mill v1.0 Scene.unity";
        public const string SetupRootName = "Khoa_Sampan_Boating_Setup";

        [MenuItem("Khoa/Boating/Apply Sampan & Water Setup")]
        public static void ApplySampanAndWaterSetupMenu()
        {
            ApplySampanAndWaterSetup();
        }

        public static void ApplySampanAndWaterSetup()
        {
            Scene activeScene = EditorSceneManager.GetActiveScene();
            if (activeScene.path != ScenePath)
            {
                activeScene = EditorSceneManager.OpenScene(ScenePath, OpenSceneMode.Single);
            }

            Debug.Log("<b>[BOATING SETUP]</b> Đang thiết lập hệ thống Xuồng Ba Lá VR và Mặt nước Thủy động học...");

            GameObject previousRoot = GameObject.Find(SetupRootName);
            if (previousRoot != null)
            {
                Object.DestroyImmediate(previousRoot);
            }

            GameObject root = new GameObject(SetupRootName);
            Undo.RegisterCreatedObjectUndo(root, "Create Sampan Boating Setup");

            float waterPlaneY = 98.9f;
            Vector3 dockPosition = new Vector3(-13.5f, waterPlaneY, -19.5f); // Bến nước gần khu câu cá và đường ra sông

            // 1. Tạo WaterSurfaceVolume phủ toàn bộ lòng sông
            GameObject waterVolGO = CreateWaterSurfaceVolume(root.transform, new Vector3(30f, waterPlaneY, 15f), new Vector3(120f, 6f, 80f));
            WaterSurfaceVolume waterVolume = waterVolGO.GetComponent<WaterSurfaceVolume>();
            waterVolume.waterSurfaceY = waterPlaneY;

            // 2. Tạo Bến Gỗ (Wooden Pier/Dock)
            GameObject dockGO = CreateWoodenDock(root.transform, dockPosition + new Vector3(1.6f, 0.4f, 0f));

            // 3. Tạo Xuồng Ba Lá VR
            GameObject sampanGO = CreateSampanInstance(root.transform, dockPosition, waterVolume);
            SampanPhysics sampanPhysics = sampanGO.GetComponent<SampanPhysics>();
            SampanSeat sampanSeat = sampanGO.GetComponentInChildren<SampanSeat>();

            // 4. Tạo Bảng Hướng Dẫn Chèo Xuồng 3D trên bến
            Vector3 guidePos = dockGO.transform.position + new Vector3(0.5f, 1.4f, -1.2f);
            CreateBoatingQuestGuide(root.transform, guidePos, sampanSeat, sampanPhysics);

            EditorSceneManager.MarkSceneDirty(activeScene);
            EditorSceneManager.SaveScene(activeScene);

            Debug.Log("<color=green><b>[BOATING SETUP] THÀNH CÔNG:</b> Đã tạo Xuồng Ba Lá VR, 2 mái chèo, ghế ngồi và bến đỗ an toàn!</color>");
        }

        private static GameObject CreateWaterSurfaceVolume(Transform parent, Vector3 center, Vector3 size)
        {
            GameObject go = new GameObject("River_Water_Surface_Volume");
            go.transform.SetParent(parent);
            go.transform.position = center;

            BoxCollider box = go.AddComponent<BoxCollider>();
            box.isTrigger = true;
            box.size = size;

            WaterSurfaceVolume vol = go.AddComponent<WaterSurfaceVolume>();
            vol.waterSurfaceY = center.y;
            vol.waterDensity = 1000f;

            return go;
        }

        private static GameObject CreateWoodenDock(Transform parent, Vector3 pos)
        {
            GameObject dock = new GameObject("Wooden_Dock_Pier");
            dock.transform.SetParent(parent);
            dock.transform.position = pos;

            Material woodMat = new Material(Shader.Find("Universal Render Pipeline/Lit") ?? Shader.Find("Standard"));
            woodMat.color = new Color(0.48f, 0.33f, 0.18f);

            // Sàn cầu ván gỗ
            GameObject plank = GameObject.CreatePrimitive(PrimitiveType.Cube);
            plank.name = "Dock_Plank";
            plank.transform.SetParent(dock.transform, false);
            plank.transform.localPosition = new Vector3(0f, 0f, 0f);
            plank.transform.localScale = new Vector3(1.8f, 0.12f, 3.2f);
            if (plank.GetComponent<Renderer>() != null) plank.GetComponent<Renderer>().sharedMaterial = woodMat;

            // Cọc cắm xuống đáy sông
            Vector3[] legOffsets = new Vector3[]
            {
                new Vector3(-0.8f, -1.2f, -1.4f),
                new Vector3(0.8f, -1.2f, -1.4f),
                new Vector3(-0.8f, -1.2f, 1.4f),
                new Vector3(0.8f, -1.2f, 1.4f)
            };

            for (int i = 0; i < legOffsets.Length; i++)
            {
                GameObject leg = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                leg.name = $"Dock_Leg_{i + 1}";
                leg.transform.SetParent(dock.transform, false);
                leg.transform.localPosition = legOffsets[i];
                leg.transform.localScale = new Vector3(0.14f, 1.2f, 0.14f);
                if (leg.GetComponent<Renderer>() != null) leg.GetComponent<Renderer>().sharedMaterial = woodMat;
            }

            return dock;
        }

        private static GameObject CreateSampanInstance(Transform parent, Vector3 pos, WaterSurfaceVolume waterVol)
        {
            GameObject sampanGO = new GameObject("Xuong_Ba_La_VR");
            sampanGO.transform.SetParent(parent);
            sampanGO.transform.position = pos;
            sampanGO.transform.rotation = Quaternion.Euler(0f, 35f, 0f); // Hướng dọc sông ra chợ nổi

            // Rigidbody & Vật lý nổi
            Rigidbody rb = sampanGO.AddComponent<Rigidbody>();
            rb.mass = 100f;
            rb.linearDamping = 0.8f;
            rb.angularDamping = 2.0f;
            rb.interpolation = RigidbodyInterpolation.Interpolate;

            SampanPhysics physics = sampanGO.AddComponent<SampanPhysics>();
            physics.waterVolume = waterVol;
            physics.defaultWaterY = (waterVol != null) ? waterVol.waterSurfaceY : 98.9f;

            // Audio & VFX
            SampanAudioAndVFX audioVFX = sampanGO.AddComponent<SampanAudioAndVFX>();

            // Mesh Xuồng Ba Lá Tapered Hull
            GameObject hullGO = new GameObject("Sampan_Hull_Visual");
            hullGO.transform.SetParent(sampanGO.transform, false);
            hullGO.transform.localPosition = new Vector3(0f, -0.1f, 0f);

            MeshFilter mf = hullGO.AddComponent<MeshFilter>();
            MeshRenderer mr = hullGO.AddComponent<MeshRenderer>();
            mf.sharedMesh = SampanMeshGenerator.GenerateSampanHullMesh(3.6f, 0.88f, 0.45f);

            Material boatMat = new Material(Shader.Find("Universal Render Pipeline/Lit") ?? Shader.Find("Standard"));
            boatMat.color = new Color(0.42f, 0.28f, 0.16f);
            mr.sharedMaterial = boatMat;

            // Colliders cho thân xuồng (Đáy + 2 Mạn để người chơi và đồ vật đứng được bên trong)
            BoxCollider bottomCol = sampanGO.AddComponent<BoxCollider>();
            bottomCol.center = new Vector3(0f, -0.08f, 0f);
            bottomCol.size = new Vector3(0.65f, 0.08f, 3.2f);

            BoxCollider leftWall = sampanGO.AddComponent<BoxCollider>();
            leftWall.center = new Vector3(-0.38f, 0.15f, 0f);
            leftWall.size = new Vector3(0.08f, 0.35f, 3.0f);

            BoxCollider rightWall = sampanGO.AddComponent<BoxCollider>();
            rightWall.center = new Vector3(0.38f, 0.15f, 0f);
            rightWall.size = new Vector3(0.08f, 0.35f, 3.0f);

            // Đòn ngồi (Bench)
            GameObject bench = GameObject.CreatePrimitive(PrimitiveType.Cube);
            bench.name = "Seating_Bench";
            bench.transform.SetParent(sampanGO.transform, false);
            bench.transform.localPosition = new Vector3(0f, 0.08f, -0.3f);
            bench.transform.localScale = new Vector3(0.82f, 0.06f, 0.28f);
            if (bench.GetComponent<Renderer>() != null) bench.GetComponent<Renderer>().sharedMaterial = boatMat;

            // Ghế ngồi VR (SampanSeat)
            GameObject seatAnchorGO = new GameObject("Player_Seat_Anchor");
            seatAnchorGO.transform.SetParent(sampanGO.transform, false);
            seatAnchorGO.transform.localPosition = new Vector3(0f, 0.35f, -0.3f);

            SampanSeat seat = sampanGO.AddComponent<SampanSeat>();
            seat.seatAnchor = seatAnchorGO.transform;

            // Mount Interactable trên ghế
            XRSimpleInteractable mountInteractable = bench.AddComponent<XRSimpleInteractable>();
            seat.mountInteractable = mountInteractable;

            // Dismount Handle trên tay vịn mạn thuyền
            GameObject dismountHandleGO = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            dismountHandleGO.name = "Dismount_Handle";
            dismountHandleGO.transform.SetParent(sampanGO.transform, false);
            dismountHandleGO.transform.localPosition = new Vector3(0.42f, 0.3f, -0.2f);
            dismountHandleGO.transform.localScale = new Vector3(0.06f, 0.15f, 0.06f);
            XRSimpleInteractable dismountInteractable = dismountHandleGO.AddComponent<XRSimpleInteractable>();
            seat.dismountInteractable = dismountInteractable;

            // 2 Cọc chèo (Oarlocks) & 2 Mái chèo (Oars)
            CreateOar(sampanGO.transform, physics, audioVFX, OarSide.Left, new Vector3(-0.48f, 0.22f, 0.25f));
            CreateOar(sampanGO.transform, physics, audioVFX, OarSide.Right, new Vector3(0.48f, 0.22f, 0.25f));

            // Dev Input
            sampanGO.AddComponent<SampanDevInput>();

            return sampanGO;
        }

        private static GameObject CreateOar(Transform sampanTrans, SampanPhysics physics, SampanAudioAndVFX audioVFX, OarSide side, Vector3 oarlockPos)
        {
            // Cọc chèo
            GameObject oarlockGO = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            oarlockGO.name = $"Oarlock_{side}";
            oarlockGO.transform.SetParent(sampanTrans, false);
            oarlockGO.transform.localPosition = oarlockPos;
            oarlockGO.transform.localScale = new Vector3(0.04f, 0.12f, 0.04f);

            // Mái chèo
            GameObject oarGO = new GameObject($"Oar_{side}");
            oarGO.transform.SetParent(sampanTrans, false);
            oarGO.transform.localPosition = oarlockPos + new Vector3(side == OarSide.Left ? -0.4f : 0.4f, 0f, 0f);
            oarGO.transform.localRotation = Quaternion.Euler(15f, side == OarSide.Left ? -25f : 25f, 0f);

            Material woodMat = new Material(Shader.Find("Universal Render Pipeline/Lit") ?? Shader.Find("Standard"));
            woodMat.color = new Color(0.55f, 0.38f, 0.22f);

            // Cán chèo (Shaft)
            GameObject shaft = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            shaft.name = "Shaft";
            shaft.transform.SetParent(oarGO.transform, false);
            shaft.transform.localPosition = new Vector3(0f, 0f, 0f);
            shaft.transform.localScale = new Vector3(0.04f, 1.1f, 0.04f);
            shaft.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
            if (shaft.GetComponent<Renderer>() != null) shaft.GetComponent<Renderer>().sharedMaterial = woodMat;

            // Lưỡi chèo (Blade)
            GameObject blade = GameObject.CreatePrimitive(PrimitiveType.Cube);
            blade.name = "Blade";
            blade.transform.SetParent(oarGO.transform, false);
            blade.transform.localPosition = new Vector3(0f, -0.1f, -1.1f);
            blade.transform.localScale = new Vector3(0.18f, 0.02f, 0.55f);
            if (blade.GetComponent<Renderer>() != null) blade.GetComponent<Renderer>().sharedMaterial = woodMat;

            // BladeTip (sensor ngập nước)
            GameObject bladeTip = new GameObject("BladeTip");
            bladeTip.transform.SetParent(blade.transform, false);
            bladeTip.transform.localPosition = new Vector3(0f, 0f, -0.5f);

            // Rigidbody & Grab
            Rigidbody oarRb = oarGO.AddComponent<Rigidbody>();
            oarRb.mass = 3.5f;
            oarRb.interpolation = RigidbodyInterpolation.Interpolate;

            XRGrabInteractable grab = oarGO.AddComponent<XRGrabInteractable>();
            grab.movementType = XRBaseInteractable.MovementType.VelocityTracking;

            // SampanOar script
            SampanOar oar = oarGO.AddComponent<SampanOar>();
            oar.sampan = physics;
            oar.oarlockPivot = oarlockGO.transform;
            oar.side = side;
            oar.bladeTip = bladeTip.transform;
            oar.audioAndVFX = audioVFX;

            // Hinge/Configurable Joint neo mái chèo vào cọc chèo
            HingeJoint joint = oarGO.AddComponent<HingeJoint>();
            joint.connectedBody = sampanTrans.GetComponent<Rigidbody>();
            joint.anchor = oarGO.transform.InverseTransformPoint(oarlockGO.transform.position);
            joint.axis = Vector3.up;
            joint.useLimits = true;
            JointLimits limits = joint.limits;
            limits.min = -65f;
            limits.max = 65f;
            joint.limits = limits;

            return oarGO;
        }

        private static void CreateBoatingQuestGuide(Transform parent, Vector3 pos, SampanSeat seat, SampanPhysics sampan)
        {
            GameObject guideGO = new GameObject("Sampan_Quest_Guide");
            guideGO.transform.SetParent(parent);
            guideGO.transform.position = pos;
            guideGO.transform.rotation = Quaternion.Euler(0f, 150f, 0f);

            SampanQuestGuide guide = guideGO.AddComponent<SampanQuestGuide>();
            guide.seat = seat;
            guide.sampan = sampan;

            // Bảng gỗ
            GameObject board = GameObject.CreatePrimitive(PrimitiveType.Cube);
            board.name = "Guide_Board_Backing";
            board.transform.SetParent(guideGO.transform, false);
            board.transform.localPosition = new Vector3(0f, 0f, 0.05f);
            board.transform.localScale = new Vector3(1.8f, 1.2f, 0.04f);

            Material boardMat = new Material(Shader.Find("Universal Render Pipeline/Lit") ?? Shader.Find("Standard"));
            boardMat.color = new Color(0.2f, 0.15f, 0.1f);
            if (board.GetComponent<Renderer>() != null) board.GetComponent<Renderer>().sharedMaterial = boardMat;

            // Text
            GameObject textGO = new GameObject("Guide_Text");
            textGO.transform.SetParent(guideGO.transform, false);
            textGO.transform.localPosition = new Vector3(0f, 0f, 0f);

            TextMeshPro tmp = textGO.AddComponent<TextMeshPro>();
            tmp.fontSize = 2.6f;
            tmp.alignment = TextAlignmentOptions.Center;
            guide.guideText = tmp;
        }
    }
}

#if UNITY_EDITOR
using System;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Khoa.UI.EditorTools
{
    /// <summary>
    /// Integrates the in-world-space UIManager into the main VR farming scene.
    ///
    /// What it does (idempotent — re-runnable):
    ///  - Instantiates UIManager.prefab at scene root if missing
    ///  - Creates a world-space canvas + UIAnchorController parented at scene root
    ///  - Wires UIManager.uiAnchor to the world canvas
    ///  - Restricts screenPrefabs to [Pause, Settings, Confirmation] (drops MainMenu, Inventory)
    ///  - Wires VRController.inputSystemReference to the XRI menu action so the existing
    ///    VRController.Toggle() handler opens/closes the pause menu
    ///
    /// What it deliberately does NOT do:
    ///  - Touch VRController.Toggle() (we modify it once in source; runtime handles menu)
    ///  - Delete the legacy ObjectName Canvas / Inventory toolbar (different concerns)
    /// </summary>
    public static class UISceneIntegrator
    {
        private const string MainScenePath = "Assets/Scenes/Grind mill v1.0 Scene.unity";
        private const string UIManagerPrefabPath = "Assets/Prefabs/UI/UIManager.prefab";
        private const string SetupRootName = "Khoa_UI_Runtime_Setup";
        private const string UIManagerInstanceName = "Khoa_UIManager";
        private const string WorldAnchorInstanceName = "Khoa_UI_WorldAnchor";

        private const string VRControllerName = "VRControllerManager";

        private const string XriActionsPath = "Assets/Samples/XR Interaction Toolkit/3.3.2/Starter Assets/XRI Default Input Actions.inputactions";
        private const string MenuMapName = "XRI Right Locomotion";
        private const string MenuActionName = "Jump";

        [MenuItem("Khoa/UI/Apply Main Scene UI Integration")]
        public static void ApplyMainSceneUISetup()
        {
            Scene scene = OpenOrUseMainScene();

            GameObject uiManagerPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(UIManagerPrefabPath);
            if (uiManagerPrefab == null)
            {
                throw new InvalidOperationException($"UIManager prefab missing at {UIManagerPrefabPath}");
            }

            string[] screenPrefabPaths =
            {
                "Assets/Prefabs/UI/Screens/Pause.prefab",
                "Assets/Prefabs/UI/Screens/Settings.prefab",
                "Assets/Prefabs/UI/Screens/Confirmation.prefab",
            };
            GameObject[] screenPrefabs = screenPrefabPaths
                .Select(AssetDatabase.LoadAssetAtPath<GameObject>)
                .ToArray();
            for (int i = 0; i < screenPrefabs.Length; i++)
            {
                if (screenPrefabs[i] == null)
                {
                    throw new InvalidOperationException($"Screen prefab missing: {screenPrefabPaths[i]}");
                }
            }

            InputActionReference menuActionRef = ResolveInputActionReference(MenuMapName, MenuActionName);

            GameObject previousSetup = FindSceneObjectByName(SetupRootName);
            if (previousSetup != null)
            {
                UnityEngine.Object.DestroyImmediate(previousSetup);
            }

            GameObject setupRoot = new GameObject(SetupRootName);

            GameObject anchor = CreateWorldSpaceAnchor(setupRoot.transform, WorldAnchorInstanceName);

            GameObject uiManagerInstance = (GameObject)PrefabUtility.InstantiatePrefab(uiManagerPrefab, setupRoot.transform);
            uiManagerInstance.name = UIManagerInstanceName;

            UIManager manager = uiManagerInstance.GetComponent<UIManager>();
            SerializedObject managerSO = new SerializedObject(manager);
            managerSO.FindProperty("uiAnchor").objectReferenceValue = anchor.transform;
            SerializedProperty screenPrefabsProp = managerSO.FindProperty("screenPrefabs");
            screenPrefabsProp.arraySize = screenPrefabs.Length;
            for (int i = 0; i < screenPrefabs.Length; i++)
            {
                screenPrefabsProp.GetArrayElementAtIndex(i).objectReferenceValue = screenPrefabs[i];
            }
            managerSO.ApplyModifiedPropertiesWithoutUndo();

            WireVRControllerMenuAction(menuActionRef);

            EditorUtility.SetDirty(uiManagerInstance);
            EditorUtility.SetDirty(anchor);

            SceneView.RepaintAll();

            EditorSceneManager.MarkSceneDirty(scene);
            EditorSceneManager.SaveScene(scene);
            AssetDatabase.SaveAssets();

            Debug.Log($"[Khoa UI] Main scene UI integrated. UIManager={uiManagerInstance.name}, WorldAnchor={anchor.name}, screenPrefabs=[Pause,Settings,Confirmation], menuAction={MenuMapName}/{MenuActionName}.");
        }

        internal static Scene OpenOrUseMainScene()
        {
            Scene activeScene = SceneManager.GetActiveScene();
            if (activeScene.IsValid() &&
                string.Equals(activeScene.path, MainScenePath, StringComparison.OrdinalIgnoreCase))
            {
                return activeScene;
            }

            if (activeScene.IsValid() && activeScene.isDirty)
            {
                if (Application.isBatchMode)
                {
                    throw new InvalidOperationException(
                        "Cannot open the main scene in batch mode while another scene has unsaved changes.");
                }
                if (!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                {
                    throw new OperationCanceledException(
                        "Main scene UI integration was cancelled — unsaved scene changes remain intact.");
                }
            }

            return EditorSceneManager.OpenScene(MainScenePath, OpenSceneMode.Single);
        }

        private static GameObject CreateWorldSpaceAnchor(Transform parent, string objectName)
        {
            GameObject anchor = new GameObject(objectName, typeof(RectTransform));
            anchor.transform.SetParent(parent, worldPositionStays: false);

            RectTransform rect = anchor.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(1f, 1f);

            Canvas canvas = anchor.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvas.sortingOrder = 100;

            CanvasScaler scaler = anchor.AddComponent<CanvasScaler>();
            scaler.dynamicPixelsPerUnit = 10f;
            scaler.referencePixelsPerUnit = 100f;

            anchor.AddComponent<GraphicRaycaster>();
            anchor.AddComponent<UIAnchorController>();

            return anchor;
        }

        private static void WireVRControllerMenuAction(InputActionReference menuActionRef)
        {
            VRController vr = UnityEngine.Object.FindFirstObjectByType<VRController>();
            if (vr == null)
            {
                Debug.LogWarning("[Khoa UI] VRController not found in scene. Menu action not wired — open the scene once and re-run.");
                return;
            }

            SerializedObject vrSO = new SerializedObject(vr);
            vrSO.FindProperty("inputSystemReference").objectReferenceValue = menuActionRef;
            vrSO.ApplyModifiedPropertiesWithoutUndo();
            EditorUtility.SetDirty(vr.gameObject);

            Debug.Log($"[Khoa UI] Wired VRController.inputSystemReference -> {MenuMapName}/{MenuActionName} on {vr.gameObject.name}.");
        }

        private static InputActionReference ResolveInputActionReference(string mapName, string actionName)
        {
            UnityEngine.Object[] assets = AssetDatabase.LoadAllAssetsAtPath(XriActionsPath);
            foreach (UnityEngine.Object asset in assets)
            {
                if (asset is InputActionReference iar &&
                    iar.action != null &&
                    iar.action.actionMap != null &&
                    iar.action.actionMap.name == mapName &&
                    iar.action.name == actionName)
                {
                    return iar;
                }
            }
            throw new InvalidOperationException(
                $"Cannot find InputActionReference for '{mapName}/{actionName}' in {XriActionsPath}.");
        }

        private static GameObject FindSceneObjectByName(string objectName)
        {
            Scene activeScene = SceneManager.GetActiveScene();
            return UnityEngine.Object.FindObjectsByType<Transform>(
                    FindObjectsInactive.Include,
                    FindObjectsSortMode.None)
                .Where(transform => transform != null && transform.name == objectName)
                .Select(transform => transform.gameObject)
                .FirstOrDefault(gameObject => gameObject.scene == activeScene);
        }
    }
}
#endif
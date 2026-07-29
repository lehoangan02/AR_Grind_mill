using UnityEngine;
using System;
using System.Collections.Generic;


public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    [SerializeField] private GameObject[] screenPrefabs;
    [SerializeField] public AudioSource uiAudioSource;
    [SerializeField] private float zDepthSpacing = 0.01f;

    private List<UIScreen> screenStack = new List<UIScreen>();
    private UIScreenAnimator animator;
    private UIScreen hudScreen;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        animator = GetComponent<UIScreenAnimator>();
        if (animator == null)
        {
            Debug.LogError("[UIManager] UIScreenAnimator component not found on this GameObject");
        }

        UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor xrRayInteractor = FindFirstObjectByType<UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor>();
        if (xrRayInteractor == null)
        {
            Debug.LogError("[UIManager] No XRRayInteractor found in scene. XR UI interaction will not work.");
        }
    }

    private void OnDestroy()
    {
        CloseAll();
    }

    public void Open<T>(UIScreenData data = null) where T : UIScreen
    {
        if (animator != null && animator.IsAnimating)
        {
            Debug.LogWarning("[UIManager] Open blocked — animation in progress");
            return;
        }

        if (IsScreenOpen<T>())
        {
            Debug.LogWarning($"[UIManager] Open blocked — screen of type {typeof(T).Name} is already in stack");
            return;
        }

        GameObject prefab = FindPrefabByType<T>();
        if (prefab == null)
        {
            Debug.LogError($"[UIManager] No prefab found with component {typeof(T).Name}");
            return;
        }

        if (screenStack.Count > 0)
        {
            UIScreen previous = screenStack[screenStack.Count - 1];
            previous.OnPause();
        }

        GameObject instance = Instantiate(prefab, transform);
        instance.name = prefab.name;

        T newScreen = instance.GetComponent<T>();
        int stackIndex = screenStack.Count;
        instance.transform.localPosition = new Vector3(0f, 0f, -(stackIndex + 1) * zDepthSpacing);

        screenStack.Add(newScreen);

        CanvasGroup cg = instance.GetComponent<CanvasGroup>();

        if (animator != null)
        {
            animator.PlayOpen(cg, () =>
            {
                newScreen.OnOpen(data);
            });
        }
        else
        {
            newScreen.OnOpen(data);
        }

        Debug.Log($"[UIManager] Opened {typeof(T).Name} — stack depth: {screenStack.Count}, z: {instance.transform.localPosition.z:F3}");
    }

    public void Close()
    {
        if (animator != null && animator.IsAnimating)
        {
            Debug.LogWarning("[UIManager] Close blocked — animation in progress");
            return;
        }

        if (screenStack.Count == 0)
        {
            Debug.LogWarning("[UIManager] Close blocked — screen stack is empty");
            return;
        }

        int lastIndex = screenStack.Count - 1;
        UIScreen closingScreen = screenStack[lastIndex];
        screenStack.RemoveAt(lastIndex);

        CanvasGroup cg = closingScreen.GetComponent<CanvasGroup>();

        if (animator != null)
        {
            animator.PlayClose(cg, () =>
            {
                CompleteClose(closingScreen);
            });
        }
        else
        {
            CompleteClose(closingScreen);
        }
    }

    public void CloseAll()
    {
        for (int i = screenStack.Count - 1; i >= 0; i--)
        {
            UIScreen screen = screenStack[i];
            if (screen != null)
            {
                screen.OnClose();
                Destroy(screen.gameObject);
            }
        }
        screenStack.Clear();
        Debug.Log("[UIManager] CloseAll — all screens removed");
    }

    public void ShowConfirmation(string message, Action onYes, Action onNo)
    {
        UIScreenData data = new UIScreenData();
        data.payload["message"] = message;
        data.payload["onYes"] = onYes;
        data.payload["onNo"] = onNo;
        Open<ConfirmationDialog>(data);
    }

    public T GetScreen<T>() where T : UIScreen
    {
        foreach (UIScreen screen in screenStack)
        {
            if (screen is T typedScreen)
                return typedScreen;
        }
        return null;
    }

    public bool IsScreenOpen<T>() where T : UIScreen
    {
        foreach (UIScreen screen in screenStack)
        {
            if (screen is T)
                return true;
        }
        return false;
    }

    public void OpenHUD<THud>() where THud : UIScreen
    {
        if (hudScreen != null)
        {
            Debug.LogWarning("[UIManager] OpenHUD blocked — HUD is already open");
            return;
        }

        GameObject prefab = FindPrefabByType<THud>();
        if (prefab == null)
        {
            Debug.LogError($"[UIManager] No HUD prefab found with component {typeof(THud).Name}");
            return;
        }

        GameObject instance = Instantiate(prefab, transform);
        instance.name = prefab.name;
        instance.transform.localPosition = Vector3.zero;

        hudScreen = instance.GetComponent<THud>();
        if (hudScreen == null)
        {
            Debug.LogError($"[UIManager] HUD prefab {prefab.name} has no {typeof(THud).Name} component");
            Destroy(instance);
            return;
        }

        hudScreen.OnOpen();

        Debug.Log($"[UIManager] HUD opened: {typeof(THud).Name} at z=0");
    }

    public void PauseHUD()
    {
        if (hudScreen == null)
        {
            Debug.LogWarning("[UIManager] PauseHUD — no HUD to pause");
            return;
        }

        CanvasGroup cg = hudScreen.GetComponent<CanvasGroup>();
        if (cg != null)
        {
            cg.alpha = 0.5f;
            cg.interactable = false;
        }
        Debug.Log("[UIManager] HUD paused");
    }

    public void ResumeHUD()
    {
        if (hudScreen == null)
        {
            Debug.LogWarning("[UIManager] ResumeHUD — no HUD to resume");
            return;
        }

        CanvasGroup cg = hudScreen.GetComponent<CanvasGroup>();
        if (cg != null)
        {
            cg.alpha = 1f;
            cg.interactable = true;
        }
        Debug.Log("[UIManager] HUD resumed");
    }

    private GameObject FindPrefabByType<T>() where T : UIScreen
    {
        if (screenPrefabs == null)
            return null;

        foreach (GameObject prefab in screenPrefabs)
        {
            if (prefab == null)
                continue;

            if (prefab.GetComponent<T>() != null)
                return prefab;
        }
        return null;
    }

    private void CompleteClose(UIScreen closingScreen)
    {
        closingScreen.OnClose();
        Destroy(closingScreen.gameObject);

        ShiftRemainingScreens();

        if (screenStack.Count > 0)
        {
            UIScreen resumeTarget = screenStack[screenStack.Count - 1];
            resumeTarget.OnResume();
        }

        Debug.Log($"[UIManager] Closed {closingScreen.GetType().Name} — stack depth: {screenStack.Count}");
    }

    private void ShiftRemainingScreens()
    {
        for (int i = 0; i < screenStack.Count; i++)
        {
            UIScreen screen = screenStack[i];
            if (screen != null)
            {
                screen.transform.localPosition = new Vector3(0f, 0f, -(i + 1) * zDepthSpacing);
            }
        }
    }
}

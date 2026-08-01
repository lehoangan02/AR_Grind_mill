using UnityEngine;
using UnityEngine.UI;

public class UITabGroup : MonoBehaviour
{
    [SerializeField] private GameObject[] tabPanels;
    [SerializeField] private Button[] tabButtons;

    private int _currentIndex = -1;

    private static readonly Color HighlightColor = Color.white;
    private static readonly Color DimColor = new Color(0.5f, 0.5f, 0.5f, 1f);

    private void Start()
    {
        if (tabPanels == null || tabButtons == null)
        {
            Debug.LogError("[UITabGroup] tabPanels or tabButtons is null. Skipping initialization.");
            return;
        }

        if (tabPanels.Length != tabButtons.Length)
        {
            Debug.LogError($"[UITabGroup] tabPanels ({tabPanels.Length}) and tabButtons ({tabButtons.Length}) length mismatch.");
            return;
        }

        if (tabPanels.Length == 0)
            return;

        for (int i = 0; i < tabButtons.Length; i++)
        {
            int captured = i;
            tabButtons[i].onClick.AddListener(() => SelectTab(captured));
        }

        SelectTab(0);
    }

    public void SelectTab(int index)
    {
        if (index < 0 || index >= tabPanels.Length)
            return;

        if (index == _currentIndex)
            return;

        for (int i = 0; i < tabPanels.Length; i++)
        {
            bool selected = i == index;
            tabPanels[i].SetActive(selected);

            ColorBlock colors = tabButtons[i].colors;
            colors.normalColor = selected ? HighlightColor : DimColor;
            tabButtons[i].colors = colors;
        }

        _currentIndex = index;
    }
}

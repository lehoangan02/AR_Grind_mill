using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public static Color selectedColor;
    private static Color originalColor;
    [SerializeField]
    private Image image;
    private bool isClicked = false;
    private int pressFrame = -1;
    void Awake()
    {
        image = GetComponent<Image>();
        selectedColor = new Color ((float)193/255, (float)193/255, (float)193/255, 1);
        originalColor = Color.white;
    }
    public void SetSelected(bool isSelected)
    {
        if (isSelected)
        {
            image.color = selectedColor;
            // Debug.Log("Selected slot: " + name + " is now with color: " + image.color);
        }
        else
        {
            image.color = originalColor;
        }
    }
    public bool IsFull()
    {
        InventoryItem itemInSlot = GetComponentInChildren<InventoryItem>();
        return itemInSlot != null;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        isClicked = true;
        pressFrame = Time.frameCount;
    }
    public bool IsClicked()
    {
        return isClicked;
    }
    void Update()
    {
        if (pressFrame != Time.frameCount)
        {
            isClicked = false;
        }
    }
}

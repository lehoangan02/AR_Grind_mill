using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [HideInInspector]
    public ItemData itemData;
    [Header("UI")]
    public Image image;
    void Awake()
    {
        image = GetComponent<Image>();
    }
    void Start()
    {
        if (itemData == null)
        {
            Debug.LogError("Item is not assigned in the inspector!");
            return;
        }
    }
    public virtual void InitialiseItem(ItemData newItem)
    {
        itemData = newItem;
        image.sprite = newItem.image;
    }
    void Update()
    {
        
    }
    public void SetSprite(Sprite arg_sprite)
    {
        image.sprite = arg_sprite;
    }
}

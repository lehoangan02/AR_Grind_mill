using UnityEngine;

public class RiceBasketController : InteractableObject
{
    private GameObject riceBunch;
    [SerializeField]
    private bool isFull = false;
    void Awake()
    {
        ItemName = "Rice Basket";
        riceBunch = transform.Find("Basket_rice_bunch").gameObject;
        if (riceBunch == null)
        {
            Debug.LogError("RiceBunch GameObject not found in the hierarchy.");
        }
        isFull = false;
        SetFull(isFull);
    }
    void Start()
    {
        
    }
    protected override void Update()
    {
        // if (SelectionController.instance.IsPlayerPointedAtObject() && SelectionController.instance.IsInteractButtonPressed())
        // {
        //     if (this == SelectionController.instance.GetCurrentPointedInteractableObject())
        //     {
        //         if (!InventoryController.instance.IsFull())
        //         {
        //             int inventoryIndex = InventoryController.instance.AddItem(InventoryController.instance.itemDataList[(int)ItemType.RiceBasket]);
        //             // Debug.Log("RiceBasketController: Added item to inventory: " + ItemName);
        //             Destroy(gameObject);
        //             ItemData itemData = InventoryController.instance.GetItemData(inventoryIndex);
        //             RiceBasketItemData riceBasketItemData = itemData as RiceBasketItemData;
        //             if (riceBasketItemData != null)
        //             {
        //                 // Successfully cast, use riceBasketItemData
        //             }
        //             else
        //             {
        //                 Debug.LogError("Failed to cast ItemData to RiceBasketItemData.");
        //             }
        //             riceBasketItemData.SetFull(isFull);
        //         }
        //         else
        //         {
        //             Debug.Log("Inventory is full. Cannot add item.");
        //         }
        //     }
        // }
        if (SelectionController.instance.IsPlayerPointedAtObject() && VRController.instance.IsRightTriggerPressed())
        {
            if (this == SelectionController.instance.GetCurrentPointedInteractableObject())
            {
                if (!InventoryController.instance.IsFull())
                {
                    int inventoryIndex = InventoryController.instance.AddItem(InventoryController.instance.itemDataList[(int)ItemType.RiceBasket]);
                    // Debug.Log("RiceBasketController: Added item to inventory: " + ItemName);
                    Destroy(gameObject);
                    ItemData itemData = InventoryController.instance.GetItemData(inventoryIndex);
                    RiceBasketItemData riceBasketItemData = itemData as RiceBasketItemData;
                    if (riceBasketItemData != null)
                    {
                        // Successfully cast, use riceBasketItemData
                    }
                    else
                    {
                        Debug.LogError("Failed to cast ItemData to RiceBasketItemData.");
                    }
                    Sprite filledSprite = riceBasketItemData.GetSprite(isFull);
                    InventorySlot currentSlot = InventoryController.instance.inventorySlots[inventoryIndex];
                    InventoryItem itemInSlot = currentSlot.GetComponentInChildren<InventoryItem>();
                    itemInSlot.SetSprite(filledSprite);
                    riceBasketItemData.SetFull(isFull);
                }
                else
                {
                    Debug.Log("Inventory is full. Cannot add item.");
                }
            }
        }
    }
    public void SetFull(bool arg_isFull)
    {
        isFull = arg_isFull;
        if (isFull)
        {
            riceBunch.SetActive(true);
        }
        else
        {
            if (riceBunch == null)
            {
                Debug.LogError("rice bunch not found!");
            }
            riceBunch.SetActive(false);
        }
    }
    public bool IsFull()
    {
        return isFull;
    }
}

using UnityEngine;

public class RiceContainerController : InteractableObject
{
    [SerializeField]
    void Start()
    {
    }

    protected override void Update()
    {
        if (SelectionController.instance.IsPlayerPointedAtObject() && SelectionController.instance.IsInteractButtonPressed())
        {
            if (this == SelectionController.instance.GetCurrentPointedInteractableObject())
            {
                Debug.Log("RiceContainerController: Interact button pressed.");
                InventorySlot currentSlot = InventoryController.instance.inventorySlots[
                    InventoryController.instance.GetSelectedSlotIndex()];
                if (currentSlot.IsFull())
                {
                    InventoryItem itemInSlot = currentSlot.GetComponentInChildren<InventoryItem>();
                    ItemType itemType = itemInSlot.itemData.type;
                    if (itemType == ItemType.RiceBasket)
                    {
                        ItemData itemData = itemInSlot.itemData;
                        RiceBasketItemData riceBasketItemData = itemData as RiceBasketItemData;
                        bool isFull = riceBasketItemData.IsFull();
                        if (!isFull)
                        {
                            riceBasketItemData.SetFull(true);
                            // Debug.Log("Set rice basket to full!");
                            Sprite filledSprite = riceBasketItemData.GetSprite(true);
                            itemInSlot.SetSprite(filledSprite);
                        }
                    }
                    else
                    {
                        Debug.Log("RiceContainerController: Selected item is not a rice basket.");
                    }
                }
                else
                {
                    Debug.Log("RiceContainerController: Selected slot is empty.");
                }
            }
        }
    }
}

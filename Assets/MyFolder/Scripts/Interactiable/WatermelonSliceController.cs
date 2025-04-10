using UnityEngine;

public class WatermelonSliceController : InteractableObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (SelectionController.instance.IsPlayerPointedAtObject() && SelectionController.instance.IsInteractButtonPressed())
        {
            if (this == SelectionController.instance.GetCurrentPointedInteractableObject())
            {
                if (!InventoryController.instance.IsFull())
                {
                    Debug.Log("Index of WatermelonSlice: " + (int)ItemType.WatermelonSlice);
                    InventoryController.instance.AddItem(InventoryController.instance.itemDataList[(int)ItemType.WatermelonSlice]);
                    Debug.Log("RiceBasketController: Added item to inventory: " + ItemName);
                    Destroy(gameObject); // Destroy the rice basket after adding it to the inventory
                }
                else
                {
                    Debug.Log("Inventory is full. Cannot add item.");
                }
            }
        }
    }
}

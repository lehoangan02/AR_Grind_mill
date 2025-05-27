using UnityEngine;

public class RicebasketInventoryItem : InventoryItem
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void InitialiseItem(ItemData newItem)
    {
        RiceBasketItemData riceBasketItemData = newItem as RiceBasketItemData;
        image.sprite = riceBasketItemData.image;
        itemData = riceBasketItemData;
        Debug.Log("Initialized item! " + itemData.name);
    }
}

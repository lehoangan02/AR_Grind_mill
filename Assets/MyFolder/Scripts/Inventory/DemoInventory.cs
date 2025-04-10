using UnityEngine;

public class DemoInventory : MonoBehaviour
{
    public InventoryController inventoryController;
    public ItemData[] itemToPickUp;
    public void PickUpItem(int id)
    {
        Debug.Log("Item to pick up: " + itemToPickUp[id].name);
        inventoryController.AddItem(itemToPickUp[id]);
    }
    [SerializeField] GameObject itemPrefab;
    public void SpawnItem()
    {
        Transform cameraTransform = Camera.main.transform;
        Vector3 spawnPosition = cameraTransform.position + cameraTransform.forward * 1.0f;
        GameObject item = Instantiate(itemPrefab, spawnPosition, cameraTransform.rotation);

    }
}

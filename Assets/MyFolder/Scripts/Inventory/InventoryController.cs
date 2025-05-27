using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.InputSystem.XR;


public class InventoryController : MonoBehaviour
{
    public InputActionReference leftBButtonAction;
    public static InventoryController instance { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        leftBButtonAction.action.Enable();
        leftBButtonAction.action.performed += OnLeftBButtonPressed;
        InputSystem.onDeviceChange += OnDeviceChange;
    }

    private void OnLeftBButtonPressed(InputAction.CallbackContext context)
    {
        RemoveItem();
    }

    private void OnDestroy()
    {
        leftBButtonAction.action.Disable();
        leftBButtonAction.action.performed -= OnLeftBButtonPressed;
        InputSystem.onDeviceChange -= OnDeviceChange;
    }

    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        switch (change)
        {
            case InputDeviceChange.Disconnected:
                leftBButtonAction.action.Disable();
                break;
            case InputDeviceChange.Reconnected:
                leftBButtonAction.action.Enable();
                break;
        }
    }

    public InventorySlot[] inventorySlots;
    [SerializeField]
    private GameObject inventoryItemPrefab;
    int selectedSlotIndex = -1;

    public void SelectSlot(int index)
    {
        if (selectedSlotIndex != -1)
        {
            inventorySlots[selectedSlotIndex].SetSelected(false);
        }
        selectedSlotIndex = index;
        inventorySlots[selectedSlotIndex].SetSelected(true);
    }
    public int GetSelectedSlotIndex()
    {
        return selectedSlotIndex;
    }
    void Start()
    {
        SelectSlot(0);
    }
    void Update()
    {
        HandleSlotSelection();
        // ToggleDropButton();
        VRControllerDropItem();
    }
    void HandleSlotSelection()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            SelectSlot(0);
        }
        else if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            SelectSlot(1);
        }
        else if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            SelectSlot(2);
        }
        else if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            SelectSlot(3);
        }
        else if (Keyboard.current.digit5Key.wasPressedThisFrame)
        {
            SelectSlot(4);
        }
        else if (Keyboard.current.digit6Key.wasPressedThisFrame)
        {
            SelectSlot(5);
        }
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].IsClicked())
            {
                SelectSlot(i);
                Debug.Log("Clicked on slot: " + i);
            }
        }
    }
    public bool IsFull()
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            if (!slot.IsFull())
            {
                return false;
            }
        }
        return true;
    }
    public int AddItem(ItemData item)
    {
        // Find an empty slot
        for (int i = 0; i < inventorySlots.Length; ++i)
        {
            if (!inventorySlots[i].IsFull())
            {
                var slot = inventorySlots[i];
                SpawnItem(item, slot);
                return i;
            }
        }
        Debug.Log("No empty slots available!");
        return -1;
    }
    public ItemData GetItemData(int index)
    {
        var inventorySlot = inventorySlots[index];
        return inventorySlot.GetComponentInChildren<InventoryItem>().itemData;
    }
    private void SpawnItem(ItemData itemData, InventorySlot slot)
    {
        GameObject newItem = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItem.GetComponent<InventoryItem>();
        if (inventoryItem == null)
        {
            Debug.LogError("InventoryItem component not found on the prefab.");
            return;
        }
        inventoryItem.InitialiseItem(itemData);
    }
    public ItemData[] itemDataList;
    public GameObject[] itemPrefab;
    [SerializeField]
    private Button DropButton;
    public GameObject SpawnConcreteItem(int id)
    {
        Transform cameraTransform = Camera.main.transform;
        Vector3 spawnPosition = cameraTransform.position + cameraTransform.forward * 1.5f;
        GameObject item = Instantiate(itemPrefab[id], spawnPosition, cameraTransform.rotation);
        return item;
    }
    public void RemoveItem(bool spawnInEnviroment = true)
    {
        int slotIndex = selectedSlotIndex;
        if (slotIndex == -1)
        {
            Debug.Log("No slot selected");
            return;
        }
        InventoryItem inventoryItem = inventorySlots[slotIndex].GetComponentInChildren<InventoryItem>();
        if (inventoryItem == null)
        {
            Debug.Log("No item in slot " + slotIndex);
            return;
        }
        else
        {
            if (!inventorySlots[selectedSlotIndex].IsFull()) 
            {
                Debug.Log("Slot is empty, cannot remove item.");
                return;
            }
            Destroy(inventoryItem.gameObject);
            Debug.Log("Removed item from slot " + slotIndex);
            if (spawnInEnviroment)
            {
                GameObject concreteItem = SpawnConcreteItem((int)inventoryItem.itemData.type);
                if (inventoryItem.itemData.type == ItemType.RiceBasket)
                {
                    Debug.Log("Spawned rice basket");
                    RiceBasketItemData riceBasketItemData = inventoryItem.itemData as RiceBasketItemData;
                    if (riceBasketItemData != null)
                    {
                        // Successfully cast, use riceBasketItemData
                    }
                    else
                    {
                        Debug.LogError("Failed to cast ItemData to RiceBasketItemData.");
                    }
                    bool isFull = riceBasketItemData.IsFull();
                    Debug.Log("Rice basket is full: " + isFull);
                    RiceBasketController riceBasketController = concreteItem.GetComponent<RiceBasketController>();
                    riceBasketController.SetFull(isFull);
                    Debug.Log("Set rice basket full: " + isFull);
                }
            }
        }
    }
    public void ToggleDropButton()
    {
        if (selectedSlotIndex == -1) return;
        if (inventorySlots[selectedSlotIndex].IsFull())
        {
            DropButton.gameObject.SetActive(true);
            DropButton.interactable = true;
            DropButton.GetComponentInChildren<TextMeshProUGUI>().text = "Drop";
        }
        else
        {
            // DropButton.interactable = false;
            // DropButton.GetComponentInChildren<TextMeshProUGUI>().text = "";
            DropButton.gameObject.SetActive(false);
        }
    }
    public void VRControllerDropItem()
    {
        // check if the A button is pressed on the right controller
        if (selectedSlotIndex == -1)
        {
            Debug.Log("No slot selected");
            return;
        }
        bool isRightAPressed = VRController.instance.IsRightButtonAPressed();
        // RemoveItem();
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class GrindMillController : InteractableObject
{
    
    [SerializeField] Transform handleGroup;
    private HandlebarInput_v3 handlebarInputController;
    private bool isSelected = false;
    [SerializeField]
    private GameObject riceGrindProgressBar;
    [SerializeField]
    private Button alternateInteractButton;
    [SerializeField]
    // private Button leftThumbButton;
    public bool isPlayerInHandleRange;
     [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;
    void Awake()
    {
        ItemName = "Grind mill";
    }
    void Start()
    {
        isSelected = false;
        handlebarInputController = handleGroup.GetComponent<HandlebarInput_v3>();
        if (handlebarInputController == null)
        {
            Debug.LogError("HandlebarInput_v2 component not found on handleGroup.");
        }
        alternateInteractButton.gameObject.SetActive(false);
    }
    protected override void Update()
    {
        if (SelectionController.instance.IsPlayerPointedAtObject() &&
        SelectionController.instance.GetCurrentPointedInteractableObject().ItemName == "Grind mill")
        {
            if (InventoryController.instance == null)
            {
                Debug.LogError("InventoryController.instance is null");
            }
            else if (InventoryController.instance.inventorySlots == null)
            {
                Debug.LogError("inventorySlots is null");
            }
            InventorySlot selectedSlot = InventoryController.instance.inventorySlots[InventoryController.instance.GetSelectedSlotIndex()];
            if (selectedSlot.IsFull() && selectedSlot.GetComponentInChildren<InventoryItem>().itemData.type == ItemType.RiceBasket)
            {
                alternateInteractButton.gameObject.SetActive(true);
            }
            else
            {
                alternateInteractButton.gameObject.SetActive(false);
            }
        }
        else
        {
            alternateInteractButton.gameObject.SetActive(false);
        }
        // if (SelectionController.instance.IsPlayerPointedAtObject() &&
        // SelectionController.instance.GetCurrentPointedInteractableObject().ItemName == "Grind mill" &&
        // alternateInteractButton.gameObject.GetComponent<ButtonPressController>().isButtonPressed())
        // {
        //     InventorySlot selectedSlot = InventoryController.instance.inventorySlots[InventoryController.instance.GetSelectedSlotIndex()];
        //     if (selectedSlot.IsFull() && selectedSlot.GetComponentInChildren<InventoryItem>().itemData.type == ItemType.RiceBasket)
        //     {
        //         ItemData itemData = selectedSlot.GetComponentInChildren<InventoryItem>().itemData;
        //         RiceBasketItemData riceBasketItemData = itemData as RiceBasketItemData;
        //         if (riceBasketItemData.IsFull())
        //         {
        //             riceBasketItemData.SetFull(false);
        //             Sprite emptySprite = riceBasketItemData.GetSprite(false);
        //             selectedSlot.GetComponentInChildren<InventoryItem>().SetSprite(emptySprite);
        //             // Debug.Log("Set rice basket to empty!");
        //             gameObject.GetComponentInChildren<RiceLevelController>().ResetRiceLevel();
        //         }
        //     }
        // }
        if (SelectionController.instance.IsPlayerPointedAtObject() &&
        SelectionController.instance.GetCurrentPointedInteractableObject().ItemName == "Grind mill" &&
        VRController.instance.IsRightGripPressed())
        {
            InventorySlot selectedSlot = InventoryController.instance.inventorySlots[InventoryController.instance.GetSelectedSlotIndex()];
            if (selectedSlot.IsFull() && selectedSlot.GetComponentInChildren<InventoryItem>().itemData.type == ItemType.RiceBasket)
            {
                ItemData itemData = selectedSlot.GetComponentInChildren<InventoryItem>().itemData;
                RiceBasketItemData riceBasketItemData = itemData as RiceBasketItemData;
                if (riceBasketItemData.IsFull())
                {
                    riceBasketItemData.SetFull(false);
                    Sprite emptySprite = riceBasketItemData.GetSprite(false);
                    selectedSlot.GetComponentInChildren<InventoryItem>().SetSprite(emptySprite);
                    // Debug.Log("Set rice basket to empty!");
                    gameObject.GetComponentInChildren<RiceLevelController>().ResetRiceLevel();
                }
            }
        }
        // if (SelectionController.instance.IsInteractButtonHeld() && 
        // leftThumbButton.GetComponent<ButtonPressController>().IsButtonHeld())
        // {
        //     handlebarInputController.enabled = true;
        //     isSelected = true;
        //     riceGrindProgressBar.SetActive(true);
        // }
        // else
        // {
        //     handlebarInputController.enabled = false;
        //     isSelected = false;
        //     riceGrindProgressBar.SetActive(false);
        // }
        // if (VRController.instance.IsRightTriggerPressed() &&
        // VRController.instance.IsLeftTriggerPressed())
        // // press A
        // // if (Keyboard.current.zKey.isPressed)
        // {
        //     handlebarInputController.enabled = true;
        //     isSelected = true;
        //     riceGrindProgressBar.SetActive(true);
        //     textMeshProUGUI.text = "Ready to grind rice!";
        // }
        // else
        // {
        //     handlebarInputController.enabled = false;
        //     isSelected = false;
        //     riceGrindProgressBar.SetActive(false);
        //     textMeshProUGUI.text = "Not ready to grind rice!";
        // }
        
        if (Keyboard.current.zKey.isPressed)
        {
            handlebarInputController.enabled = true;
            isSelected = true;
            riceGrindProgressBar.SetActive(true);
            textMeshProUGUI.text = "Ready to grind rice!";
        }
        else
        {
            handlebarInputController.enabled = false;
            isSelected = false;
            riceGrindProgressBar.SetActive(false);
            textMeshProUGUI.text = "Not ready to grind rice!";
        }
    }
}

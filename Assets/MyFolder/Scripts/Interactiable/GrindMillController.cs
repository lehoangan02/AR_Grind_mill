using UnityEngine;
using UnityEngine.UI;

public class GrindMillController : InteractableObject
{
    
    [SerializeField] Transform handleGroup;
    private HandlebarInput_v2 handlebarInputController;
    private bool isSelected = false;
    [SerializeField]
    private GameObject riceGrindProgressBar;
    [SerializeField]
    private Button alternateInteractButton;
    [SerializeField]
    private Button leftThumbButton;
    public bool isPlayerInHandleRange;
    void Awake()
    {
        ItemName = "Grind mill";
    }
    void Start()
    {
        isSelected = false;
        handlebarInputController = handleGroup.GetComponent<HandlebarInput_v2>();
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
        if (SelectionController.instance.IsPlayerPointedAtObject() &&
        SelectionController.instance.GetCurrentPointedInteractableObject().ItemName == "Grind mill" &&
        alternateInteractButton.gameObject.GetComponent<ButtonPressController>().isButtonPressed())
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
        if (SelectionController.instance.IsInteractButtonHeld() && 
        leftThumbButton.GetComponent<ButtonPressController>().IsButtonHeld())
        {
            handlebarInputController.enabled = true;
            isSelected = true;
            riceGrindProgressBar.SetActive(true);
        }
        else
        {
            handlebarInputController.enabled = false;
            isSelected = false;
            riceGrindProgressBar.SetActive(false);
        }
    }
}

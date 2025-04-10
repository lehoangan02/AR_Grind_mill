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
    private Button AlternateInteractButton;
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
    }

    protected override void Update()
    {
        if (SelectionController.instance.IsPlayerPointedAtObject() && SelectionController.instance.IsInteractButtonPressed())
        {
            if (this == SelectionController.instance.GetCurrentPointedInteractableObject())
            {
                handlebarInputController.enabled = !handlebarInputController.enabled;
                isSelected = !isSelected;
                riceGrindProgressBar.SetActive(isSelected);
                // Debug.Log("HandlebarInput_v2 component toggled: " + handlebarInputController.enabled);
            }
            else
            {
                handlebarInputController.enabled = false;
                isSelected = false;
                riceGrindProgressBar.SetActive(false);
            }
        }
        else if (SelectionController.instance.IsPlayerPointedAtObject() &&
        SelectionController.instance.GetCurrentPointedInteractableObject().ItemName == "Grind mill" &&
        AlternateInteractButton.gameObject.GetComponent<ButtonPressController>().isButtonPressed())
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
    }
}

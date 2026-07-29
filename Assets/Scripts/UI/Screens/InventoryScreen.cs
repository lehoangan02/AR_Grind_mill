using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryScreen : UIScreen
{
    [SerializeField] private Transform slotContainer;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Button removeButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private TMP_Text noInventoryText;

    private GameObject[] instantiatedSlots;

    void Start()
    {
        if (removeButton != null)
        {
            removeButton.onClick.AddListener(() =>
            {
                if (InventoryController.instance == null)
                {
                    Debug.LogWarning("[InventoryScreen] Cannot remove — InventoryController.instance is null");
                    return;
                }
                InventoryController.instance.RemoveItem();
                RefreshHighlights();
                Debug.Log("[InventoryScreen] RemoveItem called");
            });
        }
        else
        {
            Debug.LogWarning("[InventoryScreen] removeButton is not assigned");
        }

        if (closeButton != null)
        {
            closeButton.onClick.AddListener(() =>
            {
                Debug.Log("[InventoryScreen] Close button clicked");
                UIManager.instance.Close();
            });
        }
        else
        {
            Debug.LogWarning("[InventoryScreen] closeButton is not assigned");
        }
    }

    public override void OnOpen(UIScreenData data = null)
    {
        base.OnOpen(data);
        Debug.Log("[InventoryScreen] OnOpen — building inventory UI");

        var controller = InventoryController.instance;
        if (controller == null)
        {
            Debug.LogWarning("[InventoryScreen] InventoryController.instance is null — cannot build inventory");
            if (noInventoryText != null)
            {
                noInventoryText.gameObject.SetActive(true);
            }
            return;
        }

        if (noInventoryText != null)
        {
            noInventoryText.gameObject.SetActive(false);
        }

        if (slotContainer == null)
        {
            Debug.LogError("[InventoryScreen] slotContainer is not assigned");
            return;
        }

        if (slotPrefab == null)
        {
            Debug.LogError("[InventoryScreen] slotPrefab is not assigned");
            return;
        }

        InventorySlot[] slots = controller.inventorySlots;
        if (slots == null || slots.Length == 0)
        {
            Debug.LogWarning("[InventoryScreen] inventorySlots is null or empty");
            return;
        }

        instantiatedSlots = new GameObject[slots.Length];

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
            {
                Debug.LogWarning($"[InventoryScreen] Slot {i} is null — skipping");
                continue;
            }

            GameObject slotObj = Instantiate(slotPrefab, slotContainer);
            instantiatedSlots[i] = slotObj;

            // Set text to item name from InventoryItem in the slot
            InventoryItem item = slots[i].GetComponentInChildren<InventoryItem>();
            TMP_Text nameText = slotObj.GetComponentInChildren<TMP_Text>();
            if (nameText != null)
            {
                nameText.text = (item != null && item.itemData != null) ? item.itemData.name : "Empty";
            }

            // Wire click to select slot
            Button slotButton = slotObj.GetComponentInChildren<Button>();
            if (slotButton != null)
            {
                int capturedIndex = i;
                slotButton.onClick.AddListener(() =>
                {
                    if (InventoryController.instance == null)
                    {
                        Debug.LogWarning("[InventoryScreen] Cannot select — InventoryController.instance is null");
                        return;
                    }
                    InventoryController.instance.SelectSlot(capturedIndex);
                    RefreshHighlights();
                    Debug.Log($"[InventoryScreen] Slot {capturedIndex} selected");
                });
            }
        }

        RefreshHighlights();
    }

    void RefreshHighlights()
    {
        var controller = InventoryController.instance;
        if (controller == null || instantiatedSlots == null)
        {
            return;
        }

        int selectedIndex = controller.GetSelectedSlotIndex();

        for (int i = 0; i < instantiatedSlots.Length; i++)
        {
            if (instantiatedSlots[i] == null)
            {
                continue;
            }

            Image img = instantiatedSlots[i].GetComponent<Image>();
            if (img != null)
            {
                img.color = (i == selectedIndex) ? Color.grey : Color.white;
            }
        }
    }

    public override void OnClose()
    {
        base.OnClose();
        Debug.Log("[InventoryScreen] OnClose — destroying slot instances");

        if (slotContainer != null)
        {
            foreach (Transform child in slotContainer)
            {
                Destroy(child.gameObject);
            }
        }

        instantiatedSlots = null;
    }
}

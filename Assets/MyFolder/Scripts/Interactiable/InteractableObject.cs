using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string ItemName = "";
    [SerializeField] private Collider TriggerCollider;
    void Start()
    {
        if (string.IsNullOrEmpty(ItemName))
        {
            ItemName = "Name not set";
            Debug.LogError("Item name is not set. Please set the item name in the inspector.");
        }
        if (TriggerCollider == null)
        {
            Collider[] colliders = GetComponents<Collider>();
            foreach (var col in colliders)
            {
                if (col.isTrigger)
                {
                    TriggerCollider = col;
                    break;
                }
            }
            
            // If still null, just use any collider
            if (TriggerCollider == null)
                TriggerCollider = GetComponent<Collider>();
                
            if (TriggerCollider == null)
            {
                Debug.LogError("No Collider found on " + gameObject.name + " for InteractableObject.");
                return;
            }
        }
        Collider[] hits = Physics.OverlapBox(TriggerCollider.bounds.center, TriggerCollider.bounds.extents, transform.rotation);
        PlayerInRange = false;
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                PlayerInRange = true;
                // Debug.Log("Player is already in range of " + ItemName);
                break;
            }
        }

    }
    public bool PlayerInRange;
    public string getItemName()
    {
        // Debug.Log("Item name is: " + ItemName);
        return ItemName;
    }
    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log($"OnTriggerEnter called with {other.name}");
        if (other.CompareTag("Player"))
        {
            PlayerInRange = true;
            // Debug.Log("Player is in range of " + ItemName);
            // Debug.Log("Set PlayerInRange to true");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // Debug.Log($"OnTriggerExit called with {other.name}");
        if (other.CompareTag("Player"))
        {
            PlayerInRange = false;
            // Debug.Log("Player is out of range of " + ItemName);
            // Debug.Log("Set PlayerInRange to false");
        }
    }
    public bool IsPlayerInRange()
    {
        return PlayerInRange;
    }
     
    virtual protected void Update()
    {
        // if (SelectionController.instance.IsPlayerPointedAtObject())
        // {
            // Debug.Log("Player is pointed at something");
        // }
        // if (SelectionController.instance.IsInteractButtonPressed())
        // {
        //     Debug.Log("Interact button from interactable object pressed");
        // }
    }
}

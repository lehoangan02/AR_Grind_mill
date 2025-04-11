using UnityEngine;
using UnityEngine.UI;

public class GrindingActivation : MonoBehaviour
{
    GameObject grindMill;
    private bool isPlayerInHandleRange;
    [SerializeField] private Collider TriggerCollider;
    [SerializeField] private Button interactButton;
    [SerializeField] private Button leftThumbButton;
    void Start()
    {
        grindMill = transform.parent.gameObject;
        Collider[] hits = Physics.OverlapBox(TriggerCollider.bounds.center, TriggerCollider.bounds.extents, transform.rotation);
        isPlayerInHandleRange = false;
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                isPlayerInHandleRange = true;
                // Debug.Log("Player is already in range of " + ItemName);
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        isPlayerInHandleRange = true;
        interactButton.interactable = true;
        leftThumbButton.gameObject.SetActive(true);
    }
    void OnTriggerExit(Collider other)
    {
        isPlayerInHandleRange = false;
        leftThumbButton.gameObject.SetActive(false);
    }
    public bool IsPlayerInRange()
    {
        return isPlayerInHandleRange;
    }
}

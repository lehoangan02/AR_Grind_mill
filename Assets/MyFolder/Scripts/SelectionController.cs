using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SelectionController : MonoBehaviour
{
    // material variables and objects
    [SerializeField] private Material SelectedMaterial;
    [SerializeField] private string SelectableTag = "Selectable";
    private Transform PreviousSelected;
    private Dictionary<Renderer, Material[]> OriginalMaterialsDict = new Dictionary<Renderer, Material[]>();
    // UI Objects
    [SerializeField] private GameObject InteractableObjectName_UI;
    private Text InteractableObjectNameText;
    public static SelectionController instance {get; private set;}
    private bool PlayerPointedAtObject = false;
    [SerializeField] private Button InteractButton;
    private InteractableObject CurrentInteractableObject;
    [SerializeField] private GrindingActivation grindingActvation;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        InteractableObjectNameText = InteractableObjectName_UI.GetComponent<Text>();
        PlayerPointedAtObject = false;
    }
    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        ViewInteractableObject();
        IsInteractButtonPressed();
    }
    void ViewInteractableObject()
    {
        Vector3 ScreenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        Ray ScreenRay = Camera.main.ScreenPointToRay(ScreenCenter);
        bool hitFound = Physics.Raycast(ScreenRay, out RaycastHit hit);
        if (hitFound)
        {
            Transform SelectedTransform = hit.transform;
            if (SelectedTransform.GetComponent<InteractableObject>() != null
             && SelectedTransform.GetComponent<InteractableObject>().IsPlayerInRange())
            {
                InteractableObjectName_UI.SetActive(true);
                InteractableObjectNameText.text = SelectedTransform.GetComponent<InteractableObject>().getItemName();
                PlayerPointedAtObject = true;
                InteractButton.interactable = true;
                CurrentInteractableObject = SelectedTransform.GetComponent<InteractableObject>();
            }
            else
            {
                InteractableObjectName_UI.SetActive(false);
                PlayerPointedAtObject = false;
                if (!grindingActvation.IsPlayerInRange())
                    InteractButton.interactable = false;
                if (CurrentInteractableObject != null)
                {
                    CurrentInteractableObject = null;
                }
            }
        }
        else
        {
            InteractableObjectName_UI.SetActive(false);
            PlayerPointedAtObject = false;
            if (!grindingActvation.IsPlayerInRange())
                    InteractButton.interactable = false;
            if (CurrentInteractableObject != null)
            {
                CurrentInteractableObject = null;
            }
        }
    }
    public bool IsPlayerPointedAtObject()
    {
        return PlayerPointedAtObject;
    }
    public bool IsInteractButtonPressed()
    {
        bool Result = InteractButton.GetComponent<ButtonPressController>().isButtonPressed();
        if (Result)
        {
            // Debug.Log("Interact button pressed");
        }
        return Result;
    }
    public bool IsInteractButtonHeld()
    {
        return InteractButton.GetComponent<ButtonPressController>().IsButtonHeld();
    }
    public InteractableObject GetCurrentPointedInteractableObject()
    {
        return CurrentInteractableObject;
    }

    // Apply the selected material to the object
    void ChangeTextureUponRaycastHit()
    {
        Vector3 ScreenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        Ray ScreenRay = Camera.main.ScreenPointToRay(ScreenCenter);
        RaycastHit hit;
        if (Physics.Raycast(ScreenRay, out hit))
        {
            var Selected = hit.transform;
            if (Selected.CompareTag(SelectableTag))
            {

                if (PreviousSelected != null && PreviousSelected != Selected)
                {
                    ReapplyOriginalMaterials(PreviousSelected);
                    PreviousSelected = Selected;
                    OriginalMaterialsDict.Clear();
                    StoreOriginalMaterials(Selected);
                    ApplyNewMaterials(Selected);
                }
                else if (PreviousSelected == null)
                {
                    PreviousSelected = Selected;
                    OriginalMaterialsDict.Clear();
                    StoreOriginalMaterials(Selected);
                    ApplyNewMaterials(Selected);
                }
                else if (PreviousSelected == Selected)
                {
                }
            }
        }
        else
        {
            if (PreviousSelected != null)
            {
                ReapplyOriginalMaterials(PreviousSelected);
                PreviousSelected = null;
                OriginalMaterialsDict.Clear();
            }
        }
    }
    private void ReapplyOriginalMaterials(Transform previousSelected)
    {
        Renderer[] renderers = previousSelected.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            Material[] mats = OriginalMaterialsDict[renderer];
            renderer.materials = mats;
        }
    }
    private void StoreOriginalMaterials(Transform selected)
    {
        Renderer[] renderers = selected.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            Material[] mats = renderer.materials;
            OriginalMaterialsDict.Add(renderer, mats);
        }
    }
    private void ApplyNewMaterials(Transform selected)
    {
        Renderer[] renderers = selected.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            Material[] mats = renderer.materials;
            for (int i = 0; i < mats.Length; i++)
            {
                mats[i] = SelectedMaterial;
            }
            renderer.materials = mats;
        }
    }
}

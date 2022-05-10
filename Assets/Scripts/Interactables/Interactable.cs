using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string interactName;


    protected enum Types { Pickup, Camera, Map, Inventory, Power}

    [SerializeField]
    protected Types interactType;
    
    void Awake()
    {

    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + interactName);
        switch (interactType)
        {
            case Types.Pickup:
                break;
            case Types.Camera:
                GameObject.Find("Canvas").GetComponent<CameraSystem>().ToggleCameraSystem();
                break;
            case Types.Map:
                GameObject.Find("Canvas").GetComponent<MapSystem>().ToggleMapSystem();
                break;
            case Types.Inventory:
                GameObject.Find("Canvas").GetComponent<InventorySystem>().ToggleInventorySystem();
                break;
            case Types.Power:
                break;
        }
    }


}

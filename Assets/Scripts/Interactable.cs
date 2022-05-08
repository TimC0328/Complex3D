using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private string interactName;

    private enum Types { Pickup, Camera, Map }

    [SerializeField]
    private Types interactType;
    
    void Awake()
    {

    }

    public void Interact()
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
        }
    }


}

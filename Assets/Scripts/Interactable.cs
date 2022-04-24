using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private string interactName;

    private enum Types { Pickup, Camera }

    [SerializeField]
    private Types interactType;
   
    [SerializeField]
    private CameraSystem camSystem;
    
    void Awake()
    {
        switch(interactType)
        {
            case Types.Pickup:
                break;
            case Types.Camera:
                camSystem = GameObject.Find("Canvas").GetComponent<CameraSystem>();
                break;
        }
    }

    public void Interact()
    {
        Debug.Log("Interacting with " + interactName);
        switch (interactType)
        {
            case Types.Pickup:
                break;
            case Types.Camera:
                Cameras();
                break;
        }
    }

    void Cameras()
    {
        camSystem.ToggleCameraSystem();
    }
}

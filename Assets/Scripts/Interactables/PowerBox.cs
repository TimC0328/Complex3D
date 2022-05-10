using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBox : Interactable
{
    public bool interacted = false;
    [SerializeField]
    private List<int> cameras = new List<int>();

    public override void Interact()
    {
        CameraSystem cameraSystem = GameObject.Find("Canvas").GetComponent<CameraSystem>();
        Debug.Log("Interacting with power box!");

        foreach(int i in cameras)
        {
            cameraSystem.ChangePower(i);
            Debug.Log("Providing power for camera: " + i);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.rescue.currentInteract = this;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.rescue.currentInteract = null;
            if(interacted && interactType == Types.Power)
            {
                Destroy(this);
            }
        }
    }
}

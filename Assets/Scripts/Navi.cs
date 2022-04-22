using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navi : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    int layerMask = 1 << 8;

    public GameObject cameraHUD = null;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
       // if (cameraHUD.activeSelf)
        //    return;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        //transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);

        if (Input.GetButtonDown("Fire"))
            CheckPickup();

    }

    void CheckPickup()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, 100f, layerMask))
        {
            //hit.collider.gameObject.GetComponent<Interactable>().Interact();
            Debug.Log("Hit!");

        }
    }
    public void AdjustMouseSpeed(float newSpeed)
    {
        mouseSensitivity = newSpeed * 200;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSystem : MonoBehaviour
{
    private GameObject camSystem;
    private GameObject camList;

    [SerializeField]
    private Camera currentCam;
    private Camera fpsCam;

    [SerializeField]
    private List<Camera> allCameras;
    
    [SerializeField]
    private GameObject rooms;

    // Start is called before the first frame update
    void Awake()
    {
        camSystem = transform.GetChild(0).gameObject;
        camList = camSystem.transform.GetChild(0).gameObject;
        fpsCam = GameObject.Find("Navigator/Body/Main Camera").GetComponent<Camera>();

        rooms = GameObject.Find("Environment/Complex/Rooms");


        allCameras = new List<Camera>();
    }

    void Start()
    {
        InitCameras();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleCameraSystem()
    {
        camSystem.SetActive(!camSystem.activeSelf);
    }

    public void ToggleCamList()
    {
        camList.SetActive(!camList.activeSelf);
    }

    void InitCameras()
    {
        int i = 0;
        foreach (Transform child in camList.transform)
        {
            child.GetChild(0).gameObject.GetComponent<Text>().text = "Camera " + i;
            i++;
        }
       foreach (Transform child in rooms.transform)
        {
            allCameras.Add(child.GetChild(0).gameObject.GetComponent<Camera>());
        }
    }

    public void ChangeCamera(int camID)
    {
        if(camID == -1)
        {
            currentCam.enabled = false;
            fpsCam.enabled = true;
            return;
        }
        fpsCam.enabled = false;

        currentCam.enabled = false;
        currentCam = allCameras[camID];
        currentCam.enabled = true;
    }
}

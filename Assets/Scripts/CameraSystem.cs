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

    // Start is called before the first frame update
    void Awake()
    {
        camSystem = transform.GetChild(0).gameObject;
        camList = camSystem.transform.GetChild(0).gameObject;
        fpsCam = GameObject.Find("Navigator/Body/Main Camera").GetComponent<Camera>();
        
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
    }

    void ChangeCamera(int camID)
    {

    }
}

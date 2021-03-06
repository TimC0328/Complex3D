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
    private List<bool> hasPower;
    
    [SerializeField]
    private GameObject rooms;

    private Text powerText;

    // Start is called before the first frame update
    void Awake()
    {
        camSystem = transform.GetChild(0).gameObject;
        camList = camSystem.transform.GetChild(0).gameObject;
        fpsCam = GameObject.Find("Navigator/Body/Main Camera").GetComponent<Camera>();

        rooms = GameObject.Find("Environment/Complex/Rooms");

        powerText = camSystem.transform.GetChild(3).gameObject.GetComponent<Text>();
        powerText.text = "";


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
        GameManager.Instance.navi.usingScreen = !GameManager.Instance.navi.usingScreen;
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
            hasPower.Add(false);
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

        if(!hasPower[camID])
        {
            StartCoroutine(NoPower(camID));
            return;
        }

        fpsCam.enabled = false;

        currentCam.enabled = false;
        currentCam = allCameras[camID];
        currentCam.enabled = true;
    }

    public void ChangePower(int i)
    {
        hasPower[i] = true;
    }

    IEnumerator NoPower(int camID)
    {
        powerText.text = "CAMERA " + camID + " HAS NO POWER";
        yield return new WaitForSeconds(2f);
        powerText.text = "";
        yield return null;
    }
}

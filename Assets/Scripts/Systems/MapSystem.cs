using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSystem : MonoBehaviour
{
    private GameObject mapSystem;

    public Text countdownTimer;

    private float countdown = 600;
    public float minutesLeft;
    public float secondsLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        mapSystem = transform.GetChild(1).gameObject;
        countdownTimer = mapSystem.transform.GetChild(0).GetChild(2).gameObject.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
            minutesLeft = Mathf.FloorToInt(countdown / 60);
            secondsLeft = Mathf.FloorToInt(countdown % 60);
            countdownTimer.text = string.Format("{0:00}:{1:00}", minutesLeft, secondsLeft);
        }
        else
            GameManager.Instance.GameOver();
    }

    public void ToggleMapSystem()
    {
        mapSystem.SetActive(!mapSystem.activeSelf);
        GameManager.Instance.navi.usingScreen = !GameManager.Instance.navi.usingScreen;
    }

}

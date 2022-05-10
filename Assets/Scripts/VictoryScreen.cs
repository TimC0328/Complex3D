using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    public Win winstats;
    
    void Start()
    {
        gameObject.GetComponent<Text>().text = "Time remaining: " + winstats.timeRemaining;
    }
}

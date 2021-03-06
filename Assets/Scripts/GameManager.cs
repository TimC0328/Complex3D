using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    // Start is called before the first frame update

    public Rescue rescue;
    public Navi navi;

    public List<Enemy> enemies = new List<Enemy>();

    public int currentRoom = 0;

    public Win winStats;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {
        GameObject.Find("/Canvas").GetComponent<SceneSwitcher>().ChangeScene("GameOver");
    }

    public void Win()
    {
        winStats.timeRemaining = GameObject.Find("/Canvas").GetComponent<MapSystem>().countdownTimer.text;
        GameObject.Find("/Canvas").GetComponent<SceneSwitcher>().ChangeScene("Win");
    }

    public void EnableEnemies()
    {
        foreach(Enemy enemy in enemies)
        {
            if (enemy.roomID == currentRoom)
                enemy.SetState(1);
            else
                enemy.SetState(0);
        }
    }
}

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

    void ChangeRoom()
    {

    }

    public void GameOver()
    {
        GameObject.Find("/Canvas").GetComponent<SceneSwitcher>().ChangeScene("GameOver");
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

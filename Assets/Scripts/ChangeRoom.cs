using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    public int nextRoom;
    void OnTriggerEnter(Collider other)
    {
        int temp;
        if (other.gameObject.tag == "Player")
        {
            temp = GameManager.Instance.currentRoom;

            if (nextRoom == -1)
            {
                GameManager.Instance.Win();
                return;
            }

            GameManager.Instance.currentRoom = nextRoom;
            nextRoom = temp;
            GameManager.Instance.EnableEnemies();
        }
    }

}

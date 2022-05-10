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
            GameManager.Instance.currentRoom = nextRoom;
            nextRoom = temp;
            GameManager.Instance.EnableEnemies();
        }
    }

}

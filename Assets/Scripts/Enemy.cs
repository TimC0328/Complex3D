using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int health;
    public int roomID;

    private enum States { Asleep, Active, Attack, Damage}
    private States state;

    // Start is called before the first frame update
    void Start()
    {
        state = States.Asleep;
        GameManager.Instance.enemies.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        else state = States.Damage;

    }
}

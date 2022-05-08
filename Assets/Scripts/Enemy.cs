using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int health;

    public int roomID;

    private enum States { Asleep, Active, Attack, Damage, Reset, Stun}
    private States state;

    private Transform target;

    private float speed = 1.5f;

    private int attackDamage = 20;

    Vector3 dest;

    // Start is called before the first frame update
    void Start()
    {
        state = States.Asleep;
        GameManager.Instance.enemies.Add(this);
    }

    // Update is called once per frame
    void Update()
    {

        if (state == States.Active)
        {
            dest = Vector3.MoveTowards(transform.position, target.position, (speed * Time.deltaTime));
            dest.y = transform.position.y;
            transform.position = dest;
        }
        if(state == States.Reset)
        {
            dest = Vector3.MoveTowards(transform.position, target.position, (-10f * Time.deltaTime));
            dest.y = transform.position.y;
            transform.position = dest;
        }
    }

    public void DamageEnemy(int damage)
    {
        Debug.Log("Enemy has taken damage");
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        else state = States.Damage;

    }

    IEnumerator AttackPlayer()
    {
        Debug.Log("Start attack state");
        yield return new WaitForSeconds(2f);

        GameManager.Instance.rescue.Damage(attackDamage);

        StartCoroutine(ResetAttack());

        yield return null;
    }

    IEnumerator ResetAttack()
    {
        state = States.Reset;
        yield return new WaitForSeconds(0.1f);

        state = States.Stun;
        GameManager.Instance.rescue.SetState(0);
        
        yield return new WaitForSeconds(1f);
        state = States.Active;

        Debug.Log("Attack reset!");
    }

    public void SetState(int i)
    {
        if (i == 1 && state == States.Asleep)
        {
            target = GameManager.Instance.rescue.transform;
        }

        state = (States)i;
    }

    void OnTriggerEnter(Collider other)
    {
        if (state == States.Attack || state == States.Reset)
            return;
        if(other.gameObject.tag == "Player")
        {
            state = States.Attack;
            GameManager.Instance.rescue.SetState(3);
            StartCoroutine(AttackPlayer());
        }
    }

}
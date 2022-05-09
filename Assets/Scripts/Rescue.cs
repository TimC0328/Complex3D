using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Rescue : MonoBehaviour
{
    private CharacterController controller;

    private enum States { Default, Pause, Attack, Damage, Dialogue }
    [SerializeField] 
    private States state = 0;

    private float speed = 3.0f;
    private float turnSpeed = 150.0f;

    int layerMaskCombat = 1 << 9;

    private Vector3 weaponOffset = new Vector3(0f, 1.4f, 0f);

    [SerializeField]
    private int health = 100;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Start()
    {
        GameManager.Instance.rescue = this;
        GameManager.Instance.EnableEnemies();
    }

    void Update()
    {
        HandleMovement();
        HandleCombat();
    }

    void HandleMovement()
    {
        //No movement if paused or being damaged
        if (state == States.Pause || state == States.Dialogue || state == States.Damage)
            return;


        //Player can rotate while attacking, but must stand still;
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

        if (state == States.Attack)
            return;

        if (Input.GetKey(KeyCode.LeftControl))
            speed = 6f;
        else
            speed = 3f;

        Vector3 moveDir;

        moveDir = transform.forward * Input.GetAxis("Vertical") * speed;
        controller.Move(moveDir * Time.deltaTime);
    }

    void HandleCombat()
    {
        RaycastHit hit;

        if (state != States.Default && state != States.Attack)
            return;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            state = States.Attack;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if (Physics.Raycast(transform.position + weaponOffset, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMaskCombat))
                {
                    Debug.DrawRay(transform.position + weaponOffset, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                    Debug.Log("Did Hit");

                    hit.collider.gameObject.GetComponent<Enemy>().DamageEnemy(10);
                }
                Debug.Log("Fire!");
            }
        }
        else
            state = States.Default;
    }

    public void SetState(int i)
    {
        state = (States)i;
    }

    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
            GameManager.Instance.GameOver();
    }


}

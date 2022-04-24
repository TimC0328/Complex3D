using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Rescue : MonoBehaviour
{
    private CharacterController controller;

    public enum States { Default, Pause, Attack, Damage, Dialogue }
    public States state = 0;

    public float speed = 12.0f;
    public float turnSpeed = 120.0f;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
 
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        //No movement if paused
        if (state == States.Pause || state == States.Dialogue)
            return;


        //Player can rotate while attacking, but must stand still;
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

        if (state == States.Attack)
            return;


        Vector3 moveDir;

        moveDir = transform.forward * Input.GetAxis("Vertical") * speed;
        // moves the character in horizontal direction
        //controller.Move(moveDir * Time.deltaTime - Vector3.up * 0.1f);
        controller.Move(moveDir * Time.deltaTime);
    }
}

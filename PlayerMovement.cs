using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController control;


    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpH = 3f;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDist = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // creates a physichs sphere to check if it's touching anything with "groundMask" layer
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);

        // If isGrounded is true and velocity is less than 0
        // then reset velocity
        if (isGrounded && velocity.y < 0)
        {

            velocity.y = -2f;

        }

        // Gets necessary horizontal and vertical inputs from keyboard
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpH * -2 * gravity);
        }

        // takes the X and Z inputs and turns them into a direction to move to
        Vector3 move = transform.right * x + transform.forward * z;

        // moves the character depending on the direction
        control.Move(move * speed * Time.deltaTime);

        // makes player fall when mid air
        velocity.y += gravity * Time.deltaTime;
        control.Move(velocity * Time.deltaTime);
    }
}

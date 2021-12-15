using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {     
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //Velocity is resetted here
        if(isGrounded && velocity.y < 0)
        {
            //-2f used as an even smaller number than zero to ensure player hits the ground 
            velocity.y = -2f;
        }
        //Contains input of directions
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Sets the directions for the movement of the player
        Vector3 move = transform.right * x + transform.forward * z;

        //Allows the player to move at speed of 12f
        controller.Move(move * speed * Time.deltaTime);

        //If the jump button is pressed(spacebar) and player is on the ground
        if(Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            //player will jump
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); 
        }

        //Gravity added to current velocity
        velocity.y += gravity * Time.deltaTime;

        //Velocity is then added to player
        controller.Move(velocity * Time.deltaTime);
    }
}

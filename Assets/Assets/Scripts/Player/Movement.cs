using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{ 
    public CharacterController controller;
    public float speed = 7f;
    
    private Vector3 velocity;
    public float gravity = -30f;
    public float jumpHeight = 2f;

    public bool isGrounded;
    
    public Transform groundCheck;
    public float groundDistance = 0.4f; 
    public LayerMask groundMask;
    void Start()
    {
        
    }
 
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * Time.deltaTime * speed);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
        
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 12f;
        }
        else
        {
            speed = 5f;
        }
        
        
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
    
}

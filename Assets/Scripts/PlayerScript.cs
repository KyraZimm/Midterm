using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float horizontalInput;
    private bool canJump;
    private bool isJumping;

    private Rigidbody2D rb;
    private float jumpHeight = 2, speed = 5;
    
    //animation
    private Animator dawnAnim;

   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dawnAnim = GetComponent<Animator>();
    }

    
    void Update()
    {
        //movement
        horizontalInput = Input.GetAxis("Horizontal");
        
        Animate();
    }

    void FixedUpdate()
    {
        MovementControls();

    }

    void MovementControls()
    {
        Vector2 inputMagnitude = new Vector2(horizontalInput * speed, rb.velocity.y);

        rb.velocity = inputMagnitude;
        
        
        int ground = LayerMask.GetMask("Ground");
        

        RaycastHit2D groundCheckRaycastHit =
            Physics2D.Raycast(transform.position, Vector2.down, jumpHeight, ground);


        if (groundCheckRaycastHit.collider != null)
        {
            Debug.Log("can jump");
            Debug.DrawRay(transform.position, Vector2.down * jumpHeight, Color.green);
            canJump = true;
            isJumping = false;
        }
        else
        {
            canJump = false;
            Debug.DrawRay(transform.position, Vector2.down * jumpHeight, Color.red);
        }

        if (Input.GetKey(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
        else if (Input.GetKey(KeyCode.Space) && !canJump && isJumping)
        {
            //double-jump animation
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }

    void Animate()
    {
        if (rb.velocity.x == 0)
        {
            dawnAnim.Play("Dawn_Idle");
        }
        else if (rb.velocity.x != 0)
        {
            
        }
    }
}

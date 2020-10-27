﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //movement & physics
    private float horizontalInput;
    private Rigidbody2D rb;
    private bool canMove = true;
    private float jumpForce = 13;

    //jumping ability
    private float speed = 11;
    private bool grounded = false, secondJump = false;
    public bool doubleJump = false;
    
    //animation
    private Animator dawnAnim;
    private SpriteRenderer playerSprite;
    
    //dashing
    public bool dash = true;
    private bool dashing = false;
    
    //inventory
    public List<string> collectedPieces;

   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dawnAnim = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        Debug.Log(rb.velocity.y);
        
        //get movement axis
        horizontalInput = Input.GetAxis("Horizontal");

        //jumping controls
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded || (doubleJump && !secondJump))
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                secondJump = false;
                
                

                if (!secondJump)
                {
                    secondJump = true;
                }
            }
        }


        //dashing controls
        if (Input.GetButtonDown("Dash") && dash)
        {
            Debug.Log("should dash");
            StartCoroutine(Dash(0.5f));
        }

        if (canMove)
        {
            Animate();
        }
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            HorizontalMovement();
        }

        CheckForGround();

    }

    void HorizontalMovement()
    {
        Vector2 inputMagnitude = new Vector2(horizontalInput * speed, rb.velocity.y);

        rb.velocity = inputMagnitude;
        
        //handle sprite flipping
        if (horizontalInput > 0)
        {
            playerSprite.flipX = true;
        }
        else if (horizontalInput < 0)
        {
            playerSprite.flipX = false;
        }
    }

    void CheckForGround()
    {
        int ground = LayerMask.GetMask("Ground");
        
        RaycastHit2D groundCheckRaycastHit =
            Physics2D.Raycast(transform.position, Vector2.down, 1.9f, ground);


        if (groundCheckRaycastHit.collider != null)
        {
            Debug.Log("can jump");
            Debug.DrawRay(transform.position, Vector2.down * 1.9f, Color.green);
            grounded = true;
            secondJump = false;
        }
        else
        {
            Debug.DrawRay(transform.position, Vector2.down * 1.9f, Color.red);
            grounded = false;
        }
    }

    IEnumerator Dash(float dashTime)
    {
        canMove = false;
        //animate dash
        rb.gravityScale = 0;
        
        dawnAnim.Play("Dawn_Dash");

        float dashForce = 20;
        if (playerSprite.flipX)
        {
            rb.velocity = Vector2.right*dashForce;
        }
        else
        {
            rb.velocity = Vector2.left*dashForce;
        }
        
        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = 1;
        //animate end of dash
        canMove = true;
    }

    void Animate()
    {
        if (grounded)
        {
            if (rb.velocity.x == 0)
            {
                dawnAnim.Play("Dawn_Idle");
            }
            else if (rb.velocity.x != 0)
            {
                dawnAnim.Play("Dawn_RunAnim");
            }
        }
        else
        {
            if (rb.velocity.y > 0)
            {
                if (secondJump)
                {
                    dawnAnim.Play("Dawn_DoubleJump");
                }
                else
                {
                    dawnAnim.Play("Dawn_JumpUp");
                }
            }
            else
            {
                dawnAnim.Play("Dawn_Fall");
            }
        }
    }
}

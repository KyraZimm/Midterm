using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //movement & physics
    private float horizontalInput;
    private Rigidbody2D rb;
    private float jumpHeight = 10, speed = 5;
    private int jumpCount = 1;
    
    //animation
    private Animator dawnAnim;
    
    //abilities
    public bool doubleJump = false;
    public bool dash = false;
    
    //inventory
    public List<string> collectedPieces;

   
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

        
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            jumpCount--;
        }
        
        Debug.Log(collectedPieces.Count);
    }

    void FixedUpdate()
    {
        Vector2 inputMagnitude = new Vector2(horizontalInput * speed, rb.velocity.y);

        rb.velocity = inputMagnitude;
        
        
        int ground = LayerMask.GetMask("Ground");
        

        RaycastHit2D groundCheckRaycastHit =
            Physics2D.Raycast(new Vector3(transform.position.x + 1.5f, transform.position.y, 0), Vector2.down, 1.7f, ground);


        if (groundCheckRaycastHit.collider != null)
        {
            Debug.Log("can jump");
            Debug.DrawRay(new Vector3(transform.position.x + 1.5f, transform.position.y, 0), Vector2.down * 1.7f, Color.green);
            if (doubleJump)
            {
                jumpCount = 2;
            }
            else
            {
                jumpCount = 1;
            }
        }
        else
        {
            if (doubleJump)
            {
                jumpCount = 2;
            }
            else
            {
                jumpCount = 1;
            }
            Debug.DrawRay(new Vector3(transform.position.x + 1.5f, transform.position.y, 0), Vector2.down * 1.7f, Color.red);
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

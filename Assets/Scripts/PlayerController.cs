using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float jumpforce;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
    float xInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetTrigger("isIdle");
        xInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerJump();
        }

        if (xInput !=0)
        {
            PlayerRun(xInput);
        }
       

        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerSlide();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerAttack();
        }
    }

    private void PlayerAttack()
    {
        animator.SetTrigger("isAttacking");
    }

    private void PlayerSlide()
    {
        animator.SetTrigger("isSliding");
    }

    private void PlayerJump()
    {
            rb.AddForce(Vector3.up * jumpforce);
            animator.SetTrigger("isJumping");        
    }

    private void PlayerRun(float xInput)
    {
        rb.velocity = new Vector2(playerSpeed * xInput,rb.velocity.y);
        if (xInput> 0 || xInput < 0) 
        {
            animator.SetTrigger("isRunning");
        }
        if (xInput > 0 )
        {
            sprite.flipX = false;
        }
        else if (xInput < 0)
        {
            sprite.flipX = true;
        }
    }
}

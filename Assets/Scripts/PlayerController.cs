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
    ScoreManager score;
    float xInput;
    bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        score = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetTrigger("isIdle");
        xInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            PlayerJump();
        }

        else if (xInput !=0)
        {
            PlayerRun(xInput);
        }
       

        else if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerSlide();
        }

        else if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerAttack();
        }

        else if (Input.GetKeyDown(KeyCode.RightShift) && isGrounded == true)
        {
            PlayerDoubleJump();
        }
    }

    private void PlayerDoubleJump()
    {
        rb.AddForce(Vector3.up * jumpforce * 2);
        animator.SetTrigger("isJumping");
        isGrounded = false;
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
        isGrounded = false;
             
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            score.ScoreCalculator(10);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "FallDown")
        {
            gameObject.SetActive(false);
            print("Game Over");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
}

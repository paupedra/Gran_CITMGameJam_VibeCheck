using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    Vector3 movement = new Vector3(0f, 0f,0f);
    public Vector3 maxSpeed = new Vector3(5f, 2f,0f);
    public Vector2 jumpSpeed = new Vector2(0f, 5f);
    static Rigidbody2D rb;
    public Vector2 jumpForce;
    public Vector3 feetOffset;
    public Vector3 handsOffset;

    public bool running;
    public bool falling;
    public bool jumping;

    bool isGrounded;
    public LayerMask whatIsGround;
    public float checkRadious;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I have been born");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        transform.position += movement * Time.deltaTime * maxSpeed.x;

        animator.SetBool("isRunning", false);
        animator.SetBool("isFalling", false);
        animator.SetBool("isJumping", false);

        running = false;

        if (Input.GetAxis("Horizontal") > 0)
        {
            animator.SetBool("isRunning", true);
            running = true;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            //Debug.Log("Running");
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            animator.SetBool("isRunning", true);
            running = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            //Debug.Log("Running");
        }

        feetOffset.y = -2 * transform.localScale.y;
        isGrounded = Physics2D.OverlapCircle(transform.position + feetOffset, checkRadious, whatIsGround);

        if(running && !isGrounded)
        {
            animator.SetBool("isRunning", false);
            running = false;
        }

        if(isGrounded)
        {
            falling = false;
            jumping = false;
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }
        else
        {
            running = false;

            if(rb.velocity.y > 0)
            {
                animator.SetBool("isJumping", true);
                animator.SetBool("isFalling", false);
               // Debug.Log("Jumping!");
                jumping = true;
                falling = false;
            }
            else
            {
                animator.SetBool("isFalling", true);
                animator.SetBool("isJumping", false);
               // Debug.Log("Falling!");
                falling = true;
                jumping = false;
            }
        }

        if(isGrounded && Input.GetButtonDown("Jump") )
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}

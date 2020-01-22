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
    public bool flipped;

    bool isGrounded;
    public LayerMask whatIsGround;
    public float checkRadious;

    //public int versionss = random.Next(2000);

 

    Animator animator;

    //Crate Grab
    public BoxCollider2D[] crateArray;
    public CapsuleCollider2D playerCollider;

    private BoxCollider2D grabbedCrate;

    private bool isGrabbing = false;

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
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isGrabbing)
            {
                OnCrateCollision();
            }
            else
            {
                ThrowCrate(grabbedCrate);
            }
        }

        if (isGrabbing)
        {
            PickCrate(grabbedCrate);
        }

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
            flipped = false;
            //Debug.Log("Running");
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            animator.SetBool("isRunning", true);
            running = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            flipped = true;
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
    public void OnCrateCollision()
    {
        int size = crateArray.Length;

        for (int i = 0; i < size; i++)
        {
            if (playerCollider.IsTouching(crateArray[i]))
            {
                isGrabbing = true;
                grabbedCrate = crateArray[i];
            }
        }
    }

    public void PickCrate(BoxCollider2D crate)
    {
        if(!flipped)
        {
            crate.transform.position = new Vector3(playerCollider.transform.position.x + playerCollider.size.x - 0.25f, (playerCollider.transform.position.y + 1), playerCollider.transform.position.z);
        }
        else
        {
            crate.transform.position = new Vector3(playerCollider.transform.position.x - playerCollider.size.x + 0.25f, (playerCollider.transform.position.y + 1), playerCollider.transform.position.z);
        }
        crate.transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }

    public void ThrowCrate(BoxCollider2D crate)
    {
        isGrabbing = false;

        //crate.gameObject.transform = new Vector3(playerCollider.transform.position.x, (playerCollider.transform.position.y * 0.5f), playerCollider.transform.position.z);
    }
}

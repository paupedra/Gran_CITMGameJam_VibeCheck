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

    bool isGrounded;
    public Transform feetPos;
    public LayerMask whatIsGround;
    public float checkRadious;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I have been born");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        transform.position += movement * Time.deltaTime * maxSpeed.x;

        //if(Input.GetButtonDown("Jump"))
        //{
        //    rb.AddForce(jumpSpeed, ForceMode2D.Impulse);
        //    Debug.Log("Jumped!");
        //}

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadious, whatIsGround);

        if(isGrounded && Input.GetButtonDown("Jump") )
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        if(isGrounded)
        {

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float speed = 2.0f;

    private Vector2 beltVelocity;
    public Rigidbody2D rb;
    public BoxCollider2D collMOVE;
    public CapsuleCollider2D playerColl;
    public Rigidbody2D playerRigidMember;

    private Vector2 velocity = new Vector2(1.0f, 0.0f);

    public void initBelt()
    {
        //rb = GetComponent<Rigidbody2D>();
        //beltVelocity = transform.forward * -speed * Time.deltaTime;

        if (collMOVE.IsTouching(playerColl))
        {
            //playerRigidMember.gameObject.transform.forward = new Vector3(1.0f, 0.0f, 0.0f);
            playerRigidMember.position += new Vector2(0.05f, 0.0f);
            playerRigidMember.MovePosition(playerRigidMember.position);
        }
        beltVelocity = velocity; /*transform.forward * -speed * Time.deltaTime;*/
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Rigidbody2D>();
        //rigidbody.position -= transform.forward * speed * Time.deltaTime;
        //rigidbody.MovePosition(rigidbody.position + transform.forward * speed * Time.deltaTime);

        initBelt();

        //rb.position -= beltVelocity;
        //rb.MovePosition(rb.position + beltVelocity);
    }
}

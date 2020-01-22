using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    public bool dead = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("isDead", true);
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("DummyEmpty"))
        {
            Destroy(gameObject);
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Box")
        {
            dead = true;
        }
    }
}

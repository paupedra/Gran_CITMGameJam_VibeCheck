using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public Vector3 velocity = new Vector3(0.05f, 0.0f, 0.0f);
    public BoxCollider2D conveyorCollider;
    public CapsuleCollider2D playerCollider;

    public void initBelt()
    {
        if (conveyorCollider.IsTouching(playerCollider))
        {
            playerCollider.gameObject.transform.position += velocity * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        initBelt();
    }
}

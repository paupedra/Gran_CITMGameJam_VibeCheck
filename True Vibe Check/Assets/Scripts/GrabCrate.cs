using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCrate : MonoBehaviour
{
    public BoxCollider2D[] crateArray;
    public CapsuleCollider2D playerCollider;

    private BoxCollider2D grabbedCrate;

    private bool isGrabbing = false;

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
        crate.transform.position = new Vector3(playerCollider.transform.position.x + playerCollider.size.x - 0.25f, (playerCollider.transform.position.y + 1), playerCollider.transform.position.z);
    }

    public void ThrowCrate(BoxCollider2D crate)
    {
        isGrabbing = false;

        //crate.gameObject.transform = new Vector3(playerCollider.transform.position.x, (playerCollider.transform.position.y * 0.5f), playerCollider.transform.position.z);
    }
}


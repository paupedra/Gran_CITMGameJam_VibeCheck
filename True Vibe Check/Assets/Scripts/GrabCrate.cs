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
        OnCrateCollision();

        PickCrate();
    }

    public void OnCrateCollision()
    {
        int size = crateArray.Length;

        for (int i = 0; i < size; i++)
        {
            if (playerCollider.IsTouching(crateArray[i]) && Input.GetKeyDown(KeyCode.E))
            {
                isGrabbing = true;
                grabbedCrate = crateArray[i];
            }
        }
    }

    public void PickCrate()
    {
        if (isGrabbing)
        {
            grabbedCrate.transform.position = new Vector3(playerCollider.transform.position.x, (playerCollider.transform.position.y * 0.5f), playerCollider.transform.position.z);
        }
    }
}

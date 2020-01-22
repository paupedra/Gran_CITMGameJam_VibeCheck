using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public Vector3 velocity = new Vector3(0.05f, 0.0f, 0.0f);                               //Velocity of the conveyor belt.
    public BoxCollider2D conveyorCollider;                                                  //Collider of the conveyot belt.
    public CapsuleCollider2D playerCollider;                                                //Collider of the player.

    public BoxCollider2D[] crateArray;                                                      //Array that contains the colliders of the crates present in the scene.

    // Update is called once per frame
    void Update()
    {
        OnBeltContact();                                                                    //Calls the OnBeltContact() method.
    }

    public void OnBeltContact()
    {
        if (conveyorCollider.IsTouching(playerCollider))                                    //If the player's collider collider is touching the conveyor belt's collider... 
        {
            playerCollider.gameObject.transform.position += velocity * Time.deltaTime;      //The player's game object (and it's collider along with it) will be displaced according to the direction of the velocity vector.
        }

        CheckCrates();                                                                      //Calls the CheckCrates() method.
    }

    public void CheckCrates()
    {
        int size = crateArray.Length;                                                       //Stores in size the current size of the crateArray.

        for (int i = 0; i < size; i++)
        {
            if (conveyorCollider.IsTouching(crateArray[i]))                                 //If the conveyor collider is in contact with the crate being iterated.
            {
                crateArray[i].gameObject.transform.position += velocity * Time.deltaTime;   //The crate's game object (and it's collider along with it) will be displaced according to the direction of it.
            }
        }
    }
}

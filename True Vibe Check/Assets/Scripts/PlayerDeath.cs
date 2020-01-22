using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public BoxCollider2D worldFloorLimit;
    public CapsuleCollider2D playerCollider;
    public Level_Changer loader;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        CheckOutOfBounds(); 
    }

    public void CheckOutOfBounds()
    {
        if (worldFloorLimit.IsTouching(playerCollider))
        {
            loader.FadeToLevel(loader.ReturnCurrentSceneIndex());
        }
    }
}

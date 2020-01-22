using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorButton : MonoBehaviour
{
    public bool activated;
    public BoxCollider2D buttonCollider;
    public CapsuleCollider2D playerCollider;

    public GameObject[] crateArray;
    public BoxCollider2D[] crateColliderArray;

    Animator animator;

    //public DoorButton button_1;
    //public DoorButton button_2;
    //public DoorButton button_3;

    // Update is called once per frame
    void Update()
    {
        OnElementContact();
    }

    void OnElementContact()
    {
        if (buttonCollider.IsTouching(playerCollider) || /*buttonCollider.IsTouching(crateCollider)*/ OnCrateContact())
        {
            activated = true;
            //animator.SetBool("isPressed", true);
            Debug.Log("Button Pressed!!");
            //buttonCollider.gameObject.transform.position = new Vector3(0.0f, 100.0f, 0.0f);
        }
        else
        {
            activated = false;
           // animator.SetBool("isPressed", false);
        }
    }

    bool OnCrateContact()
    {
        bool ret = false;

        int size = crateColliderArray.Length;

        for (int i = 0; i < size; i++)
        {
            if (buttonCollider.IsTouching(crateColliderArray[i]))
            {
                ret = true;
            }
        }

        return ret;
    }
}

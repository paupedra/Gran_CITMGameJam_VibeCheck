using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public BoxCollider2D door;
    public DoorButton[] buttonsArray;

    public float elevationSpeed = 0.05f;
    public float elevationLimit = 10.0f;
    private bool allButtonsActivated;
    private float doorElevation = 0.0f;

    // Update is called once per frame
    void Update()
    {
        OnAllButtonsActivated();
    }

    public void OnAllButtonsActivated()
    {
        CheckActivatedButtons();

        if (allButtonsActivated)
        {
            if (doorElevation != elevationLimit)
            {
                //door.transform.position += new Vector3(0.0f, 0.05f, 0.0f);
                door.gameObject.transform.position += new Vector3(0.0f, elevationSpeed, 0.0f);
                doorElevation += elevationSpeed;
            }
            else
            {
                allButtonsActivated = false;
            }
        }
    }

    public void CheckActivatedButtons()
    {
        int size = buttonsArray.Length;

        for (int i = 0; i < size; i++)
        {
            allButtonsActivated = buttonsArray[i].activated;
        }
    }
}

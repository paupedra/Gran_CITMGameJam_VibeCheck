using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedCamera : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform playerTransform;

    private Vector3 newCameraPos;

    void refreshCameraPos()
    {
        //newCameraPos = new Vector3(playerTransform.position.x, playerTransform.position.y, cameraTransform.position.z);

        if (playerTransform.position.x < cameraTransform.position.x)
        {
            newCameraPos = new Vector3(playerTransform.position.x + 10, playerTransform.position.y, cameraTransform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        refreshCameraPos();
        cameraTransform.position = newCameraPos;
    }
}

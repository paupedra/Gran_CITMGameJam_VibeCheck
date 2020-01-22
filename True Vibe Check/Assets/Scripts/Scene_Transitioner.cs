using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Transitioner : MonoBehaviour
{
    public Level_Changer changer;
    public CapsuleCollider2D playerCollider;
    public BoxCollider2D transitionerCollider;

    // Update is called once per frame
    void Update()
    {
        if(playerCollider.IsTouching(transitionerCollider))
        {
            changer.FadeToNextLevel();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFx : MonoBehaviour
{

    public GameObject PlayerObj;
    private PlayerMovement player;
    public AudioSource explosion;
    public AudioClip fx;
    bool played;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerObj.GetComponent<PlayerMovement>();
        explosion = explosion.GetComponent<AudioSource>();
        played = false;
    }

    // Update is called once per frame
    void Update()
    {
     if(player.dead && !played)
        {
            explosion.Play();
            played = true;
        }
    }
}

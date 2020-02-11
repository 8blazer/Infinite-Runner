using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class camerafollow : MonoBehaviour
{
    public Transform player;
    public GameObject fader;
    public float forwardlimit;
    public bool backwardspossible = false;
    public float backwardlimit;
    public float upperlimit;
    public float lowerlimit;
    public string lvlName;
    string nxtlvl;
    public float nextlevelposition = 103;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        if (transform.position.x + forwardlimit < player.position.x)
        {
            transform.position = new Vector3(player.position.x - forwardlimit, transform.position.y, transform.position.z);
        }
        if (backwardspossible == true && transform.position.x - backwardlimit > player.position.x)
        {
            transform.position = new Vector3(player.position.x + backwardlimit, transform.position.y, transform.position.z);
        }
        if (transform.position.y + upperlimit < player.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.position.y - upperlimit, transform.position.z);
        }
        else if (transform.position.y - lowerlimit > player.position.y )
        {
            transform.position = new Vector3(transform.position.x, player.position.y + lowerlimit, transform.position.z);
        }
        if (transform.position.y < -0.5f)
        {
            transform.position = new Vector3(transform.position.x, -0.5f, transform.position.z);
        }
        if (transform.position.x > 99)
        {
            transform.position = new Vector3(99, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < 1)
        {
            transform.position = new Vector3(1, transform.position.y, transform.position.z);
        }
        if (player.position.x >= nextlevelposition)
        {
            fader.GetComponent<LevelFade>().run();
        }
    }
}

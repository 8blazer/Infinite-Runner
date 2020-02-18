using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow1 : MonoBehaviour
{
    public GameObject player;
    public float speed;
    bool behind = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (this.gameObject.name == "terror")
        {
            transform.position = new Vector3(player.transform.position.x + 3, player.transform.position.y, -10);
        }
        else if (ActualRunning.stopped == false && behind == false)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y , -10);
            if (transform.position.y < 0f)
            {
                transform.position = new Vector3(transform.position.x, 0f, -10);
            }
        }
        else if (ActualRunning.stopped == false && behind)
        {
            transform.position = new Vector3(transform.position.x - speed, player.transform.position.y, -10);
            if (transform.position.y < 0f)
            {
                transform.position = new Vector3(transform.position.x, 0f, -10);
            }
            if (transform.position.x < player.transform.position.x)
            {
                behind = false;
            }
        }
        else
        {
            behind = true;
            transform.position = new Vector3(transform.position.x + speed, player.transform.position.y, -10);
            if (transform.position.y < 0f)
            {
                transform.position = new Vector3(transform.position.x, 0f, -10);
            }
        }
    }
}

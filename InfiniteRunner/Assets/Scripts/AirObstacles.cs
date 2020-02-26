using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirObstacles : MonoBehaviour
{
    public GameObject bombPrefab;
    public GameObject rocketPrefab;
    public GameObject cloudPrefab;
    public GameObject player;
    float oldX = 0;
    System.Random rnd = new System.Random();
    int rndPrefab;
    int rndHeight;
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
        if (!Running.running && Cannon.shot && player.transform.position.x > oldX + 30)
        {
            oldX = player.transform.position.x;
            rndPrefab = rnd.Next(1, 5);
            rndHeight = rnd.Next(-20, 21);
            if (player.transform.position.y + rndHeight < 0)
            {
                while (player.transform.position.y + rndHeight < 0)
                {
                    rndHeight = rnd.Next(-7, 8);
                }
            }
            if (rndPrefab == 1)
            {
                Instantiate(bombPrefab, new Vector3(player.transform.position.x + 12, player.transform.position.y + rndHeight, player.transform.position.z), Quaternion.identity);
            }
            else if (rndPrefab == 2)
            {
                Instantiate(rocketPrefab, new Vector3(player.transform.position.x + 12, player.transform.position.y + rndHeight, player.transform.position.z), Quaternion.identity);
            }
            else
            {
                Instantiate(cloudPrefab, new Vector3(player.transform.position.x + 12, player.transform.position.y + rndHeight, player.transform.position.z), Quaternion.identity);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public GameObject player;
    float startX;
    System.Random rnd = new System.Random();
    int i;
    int xScale;
    int yScale;
    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
        i = rnd.Next(10, 21);
        transform.localScale = new Vector3(i, 10, 1);
        i = rnd.Next(10, 21);
        transform.localScale = new Vector3(transform.localScale.x, i, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (player.transform.position.x > startX + 10)
        {
            Destroy(this.gameObject);
        }
    }
    
}
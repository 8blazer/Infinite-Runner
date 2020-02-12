using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : MonoBehaviour
{
    float accTimer = 0;
    float oldX = 0;
    static public bool running = false;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        oldX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > -4.5f && running == false)
        {
            accTimer += Time.deltaTime;
            if (accTimer > 1)
            {
                if (oldX + .1f > transform.position.x)
                {
                    transform.rotation = Quaternion.identity;
                    running = true;
                }
                accTimer = 0;
                oldX = transform.position.x;
            }
        }
        if (running)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}

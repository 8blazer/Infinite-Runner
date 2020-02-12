using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : MonoBehaviour
{
    float accTimer = 0;
    float oldX = 0;
    // Start is called before the first frame update
    void Start()
    {
        oldX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > -4.5f)
        {
            accTimer += Time.deltaTime;
            if (accTimer > 1)
            {
                if (oldX + .1f > transform.position.x)
                {
                    transform.Rotate(0, 0, transform.rotation.z * -1);
                }
                accTimer = 0;
                oldX = transform.position.x;
            }
        }
    }
}

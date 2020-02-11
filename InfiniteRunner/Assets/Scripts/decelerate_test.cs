using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decelerate_test : MonoBehaviour
{
    public float power;
    public float decel_factor;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 launch = new Vector2(1, 1);
        launch.Normalize();
        GetComponent<Rigidbody2D>().velocity = launch * power;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity * (1.0f / decel_factor);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLooper : MonoBehaviour
{
    public Transform source;
    Vector3 previousSourcePos;
    public float parallaxScale;
    // Start is called before the first frame update
    void Start()
    {
        previousSourcePos = source.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float parallax = (previousSourcePos.x - source.position.x)
            * parallaxScale;
        Vector3 pos = transform.position;
        pos.x += parallax;
        transform.position = pos;
        if (transform.position.x <= source.position.x -25.425f)
        {
            Vector3 pos2 = new Vector3(transform.position.x + 50.85f, transform.position.y, transform.position.z);
            transform.position = pos2;
            pos = pos2;
        }
        previousSourcePos = source.position;
    }
}

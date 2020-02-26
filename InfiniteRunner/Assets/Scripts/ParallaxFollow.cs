using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxFollow : MonoBehaviour
{
    public Transform cam;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(cam.position.x, cam.position.y, transform.position.z);
        transform.position = pos;
        
    }
}

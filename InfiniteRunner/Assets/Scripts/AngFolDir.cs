using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngFolDir : MonoBehaviour
{
    Vector3 lastpos;
    // Start is called before the first frame update
    void Start()
    {
        lastpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = gameObject.transform.position - lastpos;
        if (moveDirection != Vector3.zero && Running.running == false)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            lastpos = transform.position;
        }
    }
}

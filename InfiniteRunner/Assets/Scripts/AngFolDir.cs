using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngFolDir : MonoBehaviour
{
    Vector3 lastpos;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        lastpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = gameObject.transform.position - lastpos;
        if (Cannon.rotating == false && Cannon.power == false)
        {
            timer += Time.deltaTime;
        }
        if (moveDirection != Vector3.zero && Running.running == false /*&& timer > 1.5*/)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            lastpos = transform.position;
        }
        /*if (transform.rotation.eulerAngles.z < -90)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + 1, 0);
        }
        else if (transform.rotation.eulerAngles.z > 90)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x - 1, 0);
        }
        */
    }
}

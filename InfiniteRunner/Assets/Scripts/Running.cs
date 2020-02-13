using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Running : MonoBehaviour
{
    float accTimer = 0;
    float oldX = 0;
    static public bool running = false;
    static public bool grounded = true;
    public int speed;
    public Button jumpButton;
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
                    jumpButton.GetComponent<Image>().enabled = true;
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        grounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false;
    }
}

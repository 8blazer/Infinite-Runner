using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Running : MonoBehaviour
{
    float accTimer = 0;
    float oldX = 0;
    static public bool running = false;
    public bool runningCheck = false;
    public GameObject animatingFish;
    public int speed;
    public Button jumpButton;
    public Text jumpButtonText;
    static public bool timerGoing = false;
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        oldX = transform.position.x;
        GetComponent<BoxCollider2D>().enabled = false;
        running = false;
    }

    // Update is called once per frame
    void Update()
    {
        runningCheck = running;
        if (transform.position.x > -4.5f)
        {
            accTimer += Time.deltaTime;
            if (accTimer > 1)
            {
                if (oldX + .1f > transform.position.x && running)
                {
                    Instantiate(animatingFish, transform.position + new Vector3(0,.65f,0), Quaternion.identity);
                    jumpButton.GetComponent<Image>().enabled = true;
                    jumpButtonText.GetComponent<Text>().enabled = true;
                    Destroy(this.gameObject);
                }
                accTimer = 0;
                oldX = transform.position.x;
            }
        }
        if (timerGoing)
        {
            timer += Time.deltaTime;
            if (timer > .25)
            {
                GetComponent<BoxCollider2D>().enabled = true;
                timerGoing = false;
            }
        }
        if (running)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            running = true;
            timerGoing = false;
        }
    }
}

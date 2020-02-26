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
    public Text rotationText;
    public Text velocityText;
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
        if (rotationText != null)
        {
            rotationText.text = transform.rotation.eulerAngles.z.ToString();
            velocityText.text = "v: " + GetComponent<Rigidbody2D>().velocity.y.ToString();
        }
        runningCheck = running;
        if (transform.position.x > -4.5f)
        {
            accTimer += Time.deltaTime;
            if (accTimer > 1)
            {
                if (oldX + .1f > transform.position.x && running)
                {
                    Instantiate(animatingFish, transform.position + new Vector3(0,.65f,0), Quaternion.identity);
                    Destroy(this.gameObject);
                }
                accTimer = 0;
                oldX = transform.position.x;
            }
        /*    if (GetComponent<Rigidbody2D>().velocity.y < -10)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -10);
            }
            */
            if (transform.rotation.eulerAngles.z == 90 || transform.rotation.eulerAngles.z == 270)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + 1, 0);
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

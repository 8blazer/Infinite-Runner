using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonTest : MonoBehaviour
{
    static public bool rotating = true;
    static public bool power = false;
    bool onUp = true;
    bool powerUp = true;
    bool shot = false;
    int i = 0;
    public int speed = 0;
    public Vector2 velocity;
    public Slider slider;
    public GameObject player;
    public float timer;
    public bool collide = false;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<BoxCollider2D>().enabled = false;
        player.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0.25f && shot == true)
        {
            timer += Time.deltaTime;
        }
        else if (timer > 0.25f && shot == true)
        {
            timer = 1;
        }
        if (timer == 1 && collide == false)
        {
            player.GetComponent<BoxCollider2D>().enabled = true;
            collide = true;
        }
        if (rotating)
        {
            if (onUp)
            {
                transform.Rotate(0, 0, 1);
                i++;
                if (i > 55)
                {
                    onUp = false;
                    i = 0;
                }
            }
            else
            {
                transform.Rotate(0, 0, -1);
                i++;
                if (i > 55)
                {
                    onUp = true;
                    i = 0;
                }
            }
        }
        if (power)
        {
            if (powerUp)
            {
                slider.value += Time.deltaTime;
                if (slider.value == 1)
                {
                    powerUp = false;
                }
            }
            else
            {
                slider.value -= Time.deltaTime;
                if (slider.value == 0)
                {
                    powerUp = true;
                }
            }
        }
        if (rotating == false && power == false && shot == false)
        {
            player.transform.rotation = transform.rotation;
            player.transform.position = new Vector3(transform.position.x + 2, transform.position.y + 2, player.transform.position.z);
            player.GetComponent<SpriteRenderer>().enabled = true;
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
            if (slider.value < .1f)
            {
                slider.value = .1f;
            }
            if (PlayerPrefs.GetString("Cannon") == "Normal")
            {
                player.GetComponent<Rigidbody2D>().velocity = player.transform.right * speed * slider.value;
            }
            else if (PlayerPrefs.GetString("Cannon") == "Tank")
            {
                player.GetComponent<Rigidbody2D>().velocity = player.transform.right * speed * slider.value * 1.1f;
            }
            else if (PlayerPrefs.GetString("Cannon") == "Gold")
            {
                player.GetComponent<Rigidbody2D>().velocity = player.transform.right * speed * slider.value * 1.2f;
            }
            else if (PlayerPrefs.GetString("Cannon") == "Candy")
            {
                player.GetComponent<Rigidbody2D>().velocity = player.transform.right * speed * slider.value * 1.3f;
            }
            shot = true;
            Destroy(slider.gameObject);
        }
    }
    public void Flap()
    {

    }
}

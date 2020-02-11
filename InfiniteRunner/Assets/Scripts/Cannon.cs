using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
            player.GetComponent<SpriteRenderer>().enabled = true;
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
            player.GetComponent<Rigidbody2D>().velocity = player.transform.right * speed * slider.value;
            shot = true;
        }
    }
}

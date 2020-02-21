using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{
    static public bool rotating = true;
    static public bool power = false;
    public Sprite defaultSprite;
    public Sprite tankSprite;
    public Sprite goldSprite;
    public Sprite candySprite;
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
    public float flappower;
    public int maxflaps;
    int flaps = 0;
    public GameObject flapbutton;
    public Text flapbuttonText;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("Cannon") == "Default")
        {
            GetComponent<SpriteRenderer>().sprite = defaultSprite;
        }
        else if (PlayerPrefs.GetString("Cannon") == "Tank")
        {
            GetComponent<SpriteRenderer>().sprite = tankSprite;
        }
        else if (PlayerPrefs.GetString("Cannon") == "Gold")
        {
            GetComponent<SpriteRenderer>().sprite = goldSprite;
        }
        else if (PlayerPrefs.GetString("Cannon") == "Candy")
        {
            GetComponent<SpriteRenderer>().sprite = candySprite;
        }
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
            if (slider.value < .1f)
            {
                slider.value = .1f;
            }
            if (PlayerPrefs.GetString("Cannon") == "Normal")
            {
                player.GetComponent<Rigidbody2D>().velocity = player.transform.right * speed * (slider.value + .1f);
            }
            else if (PlayerPrefs.GetString("Cannon") == "Tank")
            {
                player.GetComponent<Rigidbody2D>().velocity = player.transform.right * speed * (slider.value + .1f) * 1.1f;
            }
            else if (PlayerPrefs.GetString("Cannon") == "Gold")
            {
                player.GetComponent<Rigidbody2D>().velocity = player.transform.right * speed * (slider.value + .1f) * 1.2f;
            }
            else if (PlayerPrefs.GetString("Cannon") == "Candy")
            {
                player.GetComponent<Rigidbody2D>().velocity = player.transform.right * speed * (slider.value + .1f) * 1.3f;
            }
            shot = true;
            Destroy(slider.gameObject);
            flapbutton.GetComponent<Image>().enabled = true;
            flapbuttonText.GetComponent<Text>().enabled = true;
        }
        if (Running.running == true || ActualRunning.running == true)
        {
            Destroy(flapbutton);
        }
    }
    public void Flap()
    {
        Vector2 flapdirection = new Vector2(0, 1);
        flapdirection.Normalize();
        if (flaps < maxflaps)
        {
            player.GetComponent<Animator>().SetTrigger("flap");
            player.GetComponent<Rigidbody2D>().velocity += (flapdirection * flappower);
            flaps++;
        }
        else if (flaps == maxflaps)
        {
            player.GetComponent<Animator>().SetTrigger("flap");
            player.GetComponent<Rigidbody2D>().velocity += (flapdirection * flappower);
            Destroy(flapbutton);
        }
    }
}

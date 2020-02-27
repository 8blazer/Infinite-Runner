using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FlapPowerup : MonoBehaviour
{
    public GameObject player;
    float startX;
    public GameObject flapButton;
    public GameObject flapButtonText;
    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            flapButton = GameObject.FindGameObjectWithTag("FlapButton");
            flapButtonText = GameObject.FindGameObjectWithTag("FlapButtonText");
        }
        if (player.transform.position.x > startX + 10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Cannon.maxflaps++;
        flapButton.GetComponent<Image>().enabled = true;
        flapButtonText.GetComponent<Text>().enabled = true;
        Destroy(this.gameObject);
    }
}

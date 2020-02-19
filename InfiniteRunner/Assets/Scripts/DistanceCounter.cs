using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCounter : MonoBehaviour
{
    public GameObject player;
    public Text distanceText;
    public int distanceRaw;
    public int distanceMeter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        distanceRaw = Mathf.RoundToInt(player.transform.position.x);
        distanceMeter = Mathf.RoundToInt(distanceRaw / 5.0f);
        if (distanceMeter > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", distanceMeter);
        }
        if (distanceMeter == -1)
        {
            distanceMeter++;
        }
        distanceText.text = distanceMeter + "m/" + PlayerPrefs.GetInt("Highscore") + "m";
    }
}

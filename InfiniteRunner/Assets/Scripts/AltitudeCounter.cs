using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AltitudeCounter : MonoBehaviour
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
        distanceRaw = Mathf.RoundToInt(player.transform.position.y);
        distanceMeter = Mathf.RoundToInt(distanceRaw / 5.0f);
        if (distanceMeter < 0)
        {
            distanceMeter = 0;
        }
        if (!Running.running)
        {
            distanceText.text = distanceMeter + "m";
        }
        else
        {
            distanceText.text = "";
        }
    }
}

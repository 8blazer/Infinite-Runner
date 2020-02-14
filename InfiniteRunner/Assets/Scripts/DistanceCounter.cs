using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCounter : MonoBehaviour
{
    public Transform player;
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
        distanceRaw = Mathf.RoundToInt(player.position.x);
        distanceMeter = Mathf.RoundToInt(distanceRaw / 5.0f);
        distanceText.text = distanceMeter + "m";
    }
}

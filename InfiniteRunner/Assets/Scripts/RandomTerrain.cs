using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class RandomTerrain : MonoBehaviour
{
    public int height = -4;
    public GameObject player;
    int generatedX = 0;
    int tempHeight;
    int roundedX = 0;
    public Tilemap tilemap;
    public RuleTile tile;
    System.Random rnd = new System.Random();
    int i = 0;
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
            generatedX = Mathf.RoundToInt(player.transform.position.x + 13);
        }
        roundedX = Mathf.RoundToInt(player.transform.position.x);
        if (ActualRunning.running && roundedX + 13 > generatedX)
        {
            i = rnd.Next(1, 8);
            if (i != 1)
            {
                tilemap.SetTile(new Vector3Int(Mathf.RoundToInt(generatedX), height, 0), tile);
            }
            if (height > -5 && i != 1)
            {
                tempHeight = height - 1;
                while (tempHeight > -7)
                {
                    tilemap.SetTile(new Vector3Int(Mathf.RoundToInt(generatedX), tempHeight, 0), tile);
                    tempHeight--;
                }
            }
            i = rnd.Next(1, 15);
            if (i == 1)
            {
                height++;
            }
            else if (i == 2 && height > -2)
            {
                height--;
            }
            generatedX = Mathf.RoundToInt(player.transform.position.x + 13);
        }
    }
}

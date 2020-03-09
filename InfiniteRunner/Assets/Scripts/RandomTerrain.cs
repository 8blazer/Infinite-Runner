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
    int difficulty = 8;
    int difficultyCounter = 0;
    bool priorTile;
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
            generatedX = Mathf.RoundToInt(player.transform.position.x + 16);
        }
        roundedX = Mathf.RoundToInt(player.transform.position.x);
        if (ActualRunning.running && roundedX + 16 > generatedX)
        {
            i = 5;
            while (i > -7)
            {
                tilemap.SetTile(new Vector3Int(Mathf.RoundToInt(roundedX - 16), i, 0), null);
                i--;
            }
            tilemap.SetTile(new Vector3Int(Mathf.RoundToInt(roundedX - 16), height, 0), null);
            i = rnd.Next(1, difficulty);
            if (i != 1)
            {
                tilemap.SetTile(new Vector3Int(Mathf.RoundToInt(generatedX), height, 0), tile);
                priorTile = true;
            }
            else
            {
                priorTile = false;
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
            if (i == 1 && priorTile)
            {
                height++;
            }
            else if (i == 2 && height > -2 && priorTile)
            {
                height--;
            }
            generatedX = Mathf.RoundToInt(player.transform.position.x + 16);
            difficultyCounter++;
            if (difficultyCounter > 50)
            {
                difficultyCounter = 0;
                if (difficulty > 3)
                {
                    difficulty--;
                }
            }
        }
    }
}

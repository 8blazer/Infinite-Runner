using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Selection : MonoBehaviour
{
    public GameObject selection;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("Cannon") == "")
        {
            PlayerPrefs.SetString("Cannon", "Normal");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetString("Cannon") == "Normal")
        {
            selection.transform.position = new Vector3(-5.303f, 2.727f, 0);
        }
        if (PlayerPrefs.GetString("Cannon") == "Tank")
        {
            selection.transform.position = new Vector3(-1.43f, 2.727f, 0);
        }
        if (PlayerPrefs.GetString("Cannon") == "Gold")
        {
            selection.transform.position = new Vector3(-5.303f, -1.165f, 0);
        }
        if (PlayerPrefs.GetString("Cannon") == "Candy")
        {
            selection.transform.position = new Vector3(-1.43f, -1.165f, 0);
        }
    }
    public void DefaultSelect()
    {
        PlayerPrefs.SetString("Cannon", "Normal");
    }
    public void TankSelect()
    {
        if (PlayerPrefs.GetInt("Highscore") > 199)
        {
            PlayerPrefs.SetString("Cannon", "Tank");
        }
    }
    public void GoldSelect()
    {
        if (PlayerPrefs.GetInt("Highscore") > 299)
        {
            PlayerPrefs.SetString("Cannon", "Gold");
        }
    }
    public void CandySelect()
    {
        if (PlayerPrefs.GetInt("Highscore") > 399)
        {
            PlayerPrefs.SetString("Cannon", "Candy");
        }
    }
}

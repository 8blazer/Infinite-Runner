using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Selection : MonoBehaviour
{
    public Image selection;
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
            selection.rectTransform.position = new Vector3(-342.8f, 167.3f, 0);
        }
        if (PlayerPrefs.GetString("Cannon") == "Tank")
        {
            selection.rectTransform.position = new Vector3(-85.7f, 167.3f, 0);
        }
        if (PlayerPrefs.GetString("Cannon") == "Gold")
        {
            selection.rectTransform.position = new Vector3(-342.8f, -.7f, 0);
        }
        if (PlayerPrefs.GetString("Cannon") == "Candy")
        {
            selection.rectTransform.position = new Vector3(-85.7f, -.7f, 0);
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
        if (PlayerPrefs.GetInt("Highscore") > 229)
        {
            PlayerPrefs.SetString("Cannon", "Gold");
        }
    }
    public void CandySelect()
    {
        if (PlayerPrefs.GetInt("Highscore") > 249)
        {
            PlayerPrefs.SetString("Cannon", "Candy");
        }
    }
}

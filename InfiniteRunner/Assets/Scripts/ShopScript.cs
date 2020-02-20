using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopScript : MonoBehaviour
{
    public Text candyText;
    public Text tankText;
    public Text goldText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Highscore") > 249)
        {
            candyText.text = "";
            goldText.text = "";
            tankText.text = "";
        }
        else if (PlayerPrefs.GetInt("Highscore") > 229)
        {
            goldText.text = "";
            tankText.text = "";
        }
        else if (PlayerPrefs.GetInt("Highscore") > 199)
        {
            tankText.text = "";
        }
        else
        {
            candyText.text = "250m";
            goldText.text = "230m";
            tankText.text = "200m";
        }
    }
}

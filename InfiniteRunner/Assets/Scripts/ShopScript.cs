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
        if (PlayerPrefs.GetInt("Highscore") > Selection.candyCannonReq)
        {
            candyText.text = "";
            goldText.text = "";
            tankText.text = "";
        }
        else if (PlayerPrefs.GetInt("Highscore") > Selection.goldCannonReq)
        {
            goldText.text = "";
            tankText.text = "";
            candyText.text = "" + (Selection.candyCannonReq + 1) + "m";
        }
        else if (PlayerPrefs.GetInt("Highscore") > Selection.tankCannonReq)
        {
            tankText.text = "";
            candyText.text = "" + (Selection.candyCannonReq + 1) + "m";
            goldText.text = "" + (Selection.goldCannonReq + 1) + "m";
        }
        else
        {
            candyText.text = "" + (Selection.candyCannonReq + 1) + "m";
            goldText.text = "" + (Selection.goldCannonReq + 1) + "m";
            tankText.text = "" + (Selection.tankCannonReq + 1) + "m";
        }
    }
}

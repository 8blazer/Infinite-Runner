using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    public Text youSureText;
    public GameObject deleteButton;
    // Start is called before the first frame update
    void Start()
    {
        if (youSureText != null)
        {
            youSureText.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                GetComponent<Canvas>().enabled = true;
            }
            else
            {
                Time.timeScale = 1;
                GetComponent<Canvas>().enabled = false;
            }
        }
    }

    public void Resume()
    {
    Time.timeScale = 1;
    GetComponent<Canvas>().enabled = false;
    }
    
    public void LoadMainMenu()
    {
    Time.timeScale = 1;
    SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void DeleteSave()
    {
        if (youSureText.text == "Are you sure?")
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetString("Cannon", "Normal");
            youSureText.text = "";
            Destroy(deleteButton);
        }
        if (PlayerPrefs.GetInt("Highscore") != 0)
        {
            youSureText.text = "Are you sure?";
        }
    }
}
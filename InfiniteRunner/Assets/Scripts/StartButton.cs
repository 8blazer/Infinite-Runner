using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnButtonClick()
    {
        ActualRunning.running = false;
        ActualRunning.stopped = false;
        ActualRunning.grounded = false;
        Cannon.rotating = true;
        Cannon.power = false;
        SceneManager.LoadScene("Game");
    }
}

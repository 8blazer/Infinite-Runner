using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Buttons : MonoBehaviour
{
    public Button fireButton;
    public GameObject player;
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
    }

    public void StopButton()
    {
        Cannon.rotating = false;
        Cannon.power = true;
        CannonTest.rotating = false;
        CannonTest.power = true;
        Destroy(this.gameObject);
        fireButton.GetComponent<Image>().enabled = true;
    }
    public void PowerButton()
    {
        Cannon.power = false;
        Running.timerGoing = true;
        CannonTest.power = false;
        Running.timerGoing = true;
        Destroy(this.gameObject);
    }
    public void JumpButton()
    {
        if (ActualRunning.grounded)
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500));
            ActualRunning.grounded = false;
        }
    }
}

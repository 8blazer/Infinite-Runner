﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ActualRunning : MonoBehaviour
{
    bool timerGoing = true;
    float timer = 0;
    static public bool running = false;

    static public bool grounded = false;
    static public bool stopped = false;
    public GameObject jumpButton;
    public GameObject jumpButtonText;
    public bool groundCheck;
    float oldX;
    public RuntimeAnimatorController runningAnimator;
    // Start is called before the first frame update
    void Start()
    {
        running = false;
        grounded = false;
        stopped = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpButton == null)
        {
            jumpButton = GameObject.Find("JumpButton");
            jumpButtonText = GameObject.Find("JumpText");
        }
        if (running)
        {
            if (jumpButton != null)
            {
                jumpButton.GetComponent<Image>().enabled = true;
                jumpButtonText.GetComponent<Text>().enabled = true;
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(10, GetComponent<Rigidbody2D>().velocity.y);
            if (transform.position.x <= oldX && timer > .05f)
            {
                stopped = true;
            }
            else if (transform.position.x > oldX)
            {
                stopped = false;
            }
        }
        if (timerGoing)
        {
            timer += Time.deltaTime;
            if (timer > 1 && running == false)
            {
                GetComponent<BoxCollider2D>().enabled = true;
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                if (timer > 3)
                {
                    running = true;
                    GetComponent<Animator>().runtimeAnimatorController = runningAnimator;
                    timer = 0;
                    oldX = transform.position.x - 1;
                }
            }
            else if (running == true && timer > .1f)
            {
                oldX = transform.position.x;
                timer = 0;
            }
        }
        groundCheck = grounded;
        if (transform.position.y < -5.45f)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        grounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "LoseWall")
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}

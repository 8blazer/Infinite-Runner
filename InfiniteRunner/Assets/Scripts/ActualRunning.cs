using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActualRunning : MonoBehaviour
{
    bool timerGoing = true;
    float timer = 0;
    static public bool running = false;
    static public bool grounded = false;
    public bool groundCheck;
    public RuntimeAnimatorController runningAnimator;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerGoing)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                running = true;
                timerGoing = false;
                GetComponent<BoxCollider2D>().enabled = true;
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
        if (running)
        {
            GetComponent<Animator>().runtimeAnimatorController = runningAnimator;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(5,0));
        }
        groundCheck = grounded;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        grounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false;
    }
}

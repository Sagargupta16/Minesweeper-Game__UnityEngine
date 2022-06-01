using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Text Timer;
    private float timer = 0.0f;
    public bool isTimer = true;
    public bool timeReset = false;
    private float z;
    public bool timeZero = false;
    // Start is called before the first frame update
    void Start()
    {
        if (DifficultyScript.a)
        {
            z = 20f;
        }
        else if (DifficultyScript.b)
        {
            z = 40f;
        }
        else if (DifficultyScript.c)
        {
            z = 60f;
        }
        timer = z;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeReset)
        {
            timer = z+1f;
            timeReset = false;
        }
        if(isTimer)
        {
            timer = timer - Time.deltaTime;
            DisplayTime();
        }

    }

    void DisplayTime()
    {

        int seconds = Mathf.FloorToInt(timer);
        if (seconds == 0)
        {
            timeZero = true;
            isTimer = false;
        }
        Timer.text = string.Format("{0:000}", seconds);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private int lastTime;
    
    private float holdSecs; // stores values of deltaTime
    private float timer; 

    // Start is called before the first frame update
    void Start()
    {
        ResetTime();
        lastTime = 1;
        timer = -1; // So 0 can appear on log
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // Checks if a full second has passed by comparing it with "lastTime"
        if (lastTime != (int)Time.time) // Compare only when Time.time is converted to an int.
        {
            Debug.Log((int)Time.time); // Conversion to int to display as an integer second values
            lastTime = (int)Time.time; // Updates "lastTime" so it does not continously output the same number
        }
        */

        holdSecs += Time.deltaTime;
        if (holdSecs >= 1) // Checks if the temp seconds is greater than 1
        {
            timer++; // Increases the timer
            Debug.Log(timer); // Outputs the timer
            holdSecs = 0; // Resets the deltaTime holder so when timer is paused, it will not output
        }


        // Pause timeScale
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spacebar pressed");
            if (Time.timeScale == 1.0f)
            {
                Time.timeScale = 0.0f;         
            }
            else
            {
                Time.timeScale = 1.0f;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ResetTime();
        }
        

    }

    private void ResetTime()
    {
        timer = 0.0f; 
    }

}

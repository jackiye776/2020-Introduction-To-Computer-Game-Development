using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    private static float speedModifier = 1.0f;
    public static float SpeedModifider { // Property to get private variable
        get { 
            return speedModifier;
        }
    }
    
    enum GameSpeed { Slow = 1, Fast = 3 };
    private static GameSpeed currentSpeedState = GameSpeed.Slow;

    public static float CurrentSpeedState
    {
        get {
            return (float)currentSpeedState;
        }
        set
        {
            currentSpeedState = currentSpeedState == GameSpeed.Slow ? currentSpeedState = GameSpeed.Fast : currentSpeedState = GameSpeed.Slow;
            speedModifier = currentSpeedState == GameSpeed.Slow ?  speedModifier = (float)GameSpeed.Fast : speedModifier = (float)GameSpeed.Slow;
            //Debug.Log("Current Speed State: " + currentSpeedState + " Speed Modifier: " + speedModifier);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

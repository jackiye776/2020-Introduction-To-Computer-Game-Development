using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameManager : MonoBehaviour
{
  //  const string speedKey = "Speed";

    // Start is called before the first frame update
    void Start()
    {
        LoadSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveSpeed()
    {
        PlayerPrefs.SetFloat("speedKey", SpeedManager.CurrentSpeedState);
        PlayerPrefs.Save();
        Debug.Log("Saving: " + PlayerPrefs.GetFloat("speedKey"));
    }

    public void LoadSpeed()
    {
        SpeedManager.CurrentSpeedState = PlayerPrefs.GetFloat("speedKey");
        Debug.Log("Load Speed: " + PlayerPrefs.GetFloat("speedKey"));
    }
}

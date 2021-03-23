using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PrintAndHide : MonoBehaviour
{
    int i = 0;
    int num;

    public Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        num = Random.Range(200, 251);
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.tag.Equals("Red") && i == 100)
        {
            gameObject.SetActive(false);
            Debug.Log(gameObject.name + " has been deactivated at number: " + i); // Checks if gameObject has been deactivated at 100
        }       
        
        if (gameObject.tag.Equals("Blue") && i == num)
        {

            rend.enabled = false;
            Debug.Log("Render of " + gameObject.name + " has been disabled at number: " + num); // Checks what the random number is & if render of gameObject has been disabled
        }
        
        Debug.Log(gameObject.name + ": " + i++);
    }
}

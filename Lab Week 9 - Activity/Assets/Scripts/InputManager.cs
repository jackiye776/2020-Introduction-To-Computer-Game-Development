using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    //[SerializeField]
    GameObject otherObject;
    Animator animator;

    float x;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            SpeedManager.CurrentSpeedState = 0;
            gameObject.GetComponent<SaveGameManager>().SaveSpeed();
            
            //Debug.Log("Spacebar Pressed");

        }


        if (GameManager.currentGameState == GameManager.GameState.Start && Input.GetKeyDown(KeyCode.Return))
        {
            Destroy(gameObject.GetComponent<Tweener>()); // Destory as Tweener is only for sphere
            SceneManager.LoadScene(0);
        }

    }
}

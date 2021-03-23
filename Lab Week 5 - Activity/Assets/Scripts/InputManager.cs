using UnityEngine;
using UnityEngine.UIElements;

public class InputManager : MonoBehaviour
{
    private Transform[] transArray;

   // public GameObject BluePrefab;
   // public GameObject RedPrefab;

    // Start is called before the first frame update
    void Start()
    {
        transArray = new Transform[2];

        // Find GO with tag (calls GO) --> get Transform component & then store it into array
        transArray[0] = GameObject.FindWithTag("Red").transform; // GetComponent<Transform>();
        transArray[1] = GameObject.FindWithTag("Blue").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            //Rotate on Z-axis 
            transArray[0].transform.Rotate(0.0f, 0.0f, 45.0f);
            transArray[1].transform.Rotate(0.0f, 0.0f, -45.0f);
        }

        /*
        if (Input.GetKeyDown("e"))
        {
            if (transArray[0].GetComponentInChildren<PrintAndHide>() && transArray[1].GetComponentInChildren<PrintAndHide>())
            {
                Destroy(transArray[0].GetComponent<PrintAndHide>());
                Destroy(transArray[1].GetComponent<PrintAndHide>());
                Debug.Log("Component has been destroyed");
            }
            else
            {
                transArray[0].gameObject.AddComponent<PrintAndHide>();
                transArray[1].gameObject.AddComponent<PrintAndHide>();
            }
        }
        */

        if (Input.GetButtonDown("Fire1")) // press "q" to swap
        {
            Swap(transArray[0].position.y, transArray[1].position.y);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            float randRange = Random.Range(51.0f, 256.0f);
            transArray[0].transform.GetComponentInChildren<Renderer>().material.color = new Color(randRange, 0, 0);
            transArray[1].transform.GetComponentInChildren<Renderer>().material.color = new Color(0, 0, randRange);

            Debug.Log("Red: " + transArray[0].GetComponentInChildren<Renderer>().material.color);
            Debug.Log("Blue: " + transArray[1].GetComponentInChildren<Renderer>().material.color);
        }
    }

    void Swap(float getRedY, float getBlueY)
    { 
        // Fix later
        Vector3 temp = new Vector3(transArray[1].position.x, getRedY, transArray[1].position.z);
        transArray[0].position = new Vector3(transArray[0].position.x, getBlueY, transArray[0].position.z);
        transArray[1].transform.position = temp;
    }
}

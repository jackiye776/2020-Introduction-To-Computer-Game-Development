using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private GameObject item;
    private Tweener tweener;
    private List<GameObject> itemList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
        itemList.Add(item);
    }

    // Update is called once per frame
    void Update()
    {
        // Loops through each instantiated object and calls AddTween. Break so it does not go through each IF statements after.
        foreach(GameObject item in itemList) {
            if (Input.GetKeyDown("a"))
            {
                if (tweener.AddTween(item.transform, item.transform.position, new Vector3(-2.0f, 0.5f, 0.0f), 1.5f) == true) break;
            }
            if (Input.GetKeyDown("d"))
            {
                if (tweener.AddTween(item.transform, item.transform.position, new Vector3(2.0f, 0.5f, 0.0f), 1.5f) == true) break;
            }
            if (Input.GetKeyDown("s"))
            {
                if (tweener.AddTween(item.transform, item.transform.position, new Vector3(0.0f, 0.5f, -2.0f), 0.5f) == true) break;
            }
            if (Input.GetKeyDown("w"))
            {
                if (tweener.AddTween(item.transform, item.transform.position, new Vector3(0.0f, 0.5f, 2.0f), 0.5f) == true) break;
            }
        }

        // Clone box & add it to the list
        if (Input.GetKeyDown("space"))
        {
            itemList.Add(Instantiate(item, new Vector3(0f, 0.5f, 0f), Quaternion.identity));
        }
    }

}

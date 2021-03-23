using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour
{
    private Vector3 target = new Vector3(-3, 1, 0);
    private float duration = 1.5f;

    public Tweener tween;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!tween.TweenExists(transform))
        {
            if(target.x == -3) { target.x = 3; }
            else if(target.x == 3) { target.x = -3; }
        }
        tween.AddTween(gameObject.transform, gameObject.transform.position, target, duration / SpeedManager.SpeedModifider);

    }
}

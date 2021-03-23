using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    //private Tween activeTween;
    private List<Tween> activeTweens = new List<Tween>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //foreach (Tween activeTween in activeTweens) { ... I'm unsure about how to remove from temporary list ...}
        for(int i = 0; i < activeTweens.Count; i++) {
            Tween activeTween = activeTweens[i];

            float time = (Time.time - activeTween.StartTime) / activeTween.Duration;
            float timeFraction = time * time * time;

            float dist = Vector3.Distance(activeTween.Target.position, activeTween.EndPos);

            if (dist > 0.1f)
            {
                activeTween.Target.transform.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, Time.deltaTime);
            }
            if (dist < 0.1f)
            {
                activeTween.Target.position = activeTween.EndPos;
                activeTweens.RemoveAt(i);
            } 
        }

        // 80% & 90% Mark \\
        /* if (activeTween != null)
        {
            // Linear interpolation
            //float timeFraction = (Time.time - activeTween.StartTime) / activeTween.Duration;

            // Cubic easing-in interpolation
            float time = (Time.time - activeTween.StartTime) / activeTween.Duration;
            float timeFraction =  time * time * time;

            // Distance between current object's position and the EndPos not "StartPos"
            float dist = Vector3.Distance(activeTween.Target.position, activeTween.EndPos);

            if (dist > 0.1f)
            {
                activeTween.Target.transform.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, timeFraction);
            }
            if (dist < 0.1f)
            {
                activeTween.Target.position = activeTween.EndPos;
                activeTween = null;
            }
            Debug.Log("Distance is: " + dist); // Debug - Checking if statement of distance
        } */
    }

    // 60% Mark \\
    /* public void AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        if(activeTween == null) { activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration); }
    } */

    public bool AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        if(!(TweenExists(targetObject)))
        {
            activeTweens.Add(new Tween(targetObject, startPos, endPos, Time.time, duration));
            return true;
        }
        return false;
    }

    public bool TweenExists(Transform target)
    {
        foreach (Tween tween in activeTweens) { 
            if (tween.Target  == target)
            {
                return true;
            }
        }
        return false;
    }

}

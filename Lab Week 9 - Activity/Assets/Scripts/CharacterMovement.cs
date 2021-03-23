using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {    
    public Animator moveAnimator;

    private Vector3 movement;
    private float movementSqrMagnitude; 
    
	
	void Update () {
        GetMovementInput();
        CharacterRotation();
        WalkingAnimation();
	}
    //  SpeedManager.SpeedModifider

    void GetMovementInput() {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
        movement = Vector3.ClampMagnitude(movement, 1.0f); 
        movementSqrMagnitude = movement.sqrMagnitude;
        Debug.Log("Movement: " + movement + "Speed modifier " + SpeedManager.SpeedModifider + "MovementSqr: " + movementSqrMagnitude);
    }


    void CharacterRotation() {
        if (movement != Vector3.zero) {
            transform.rotation = Quaternion.LookRotation(movement, Vector3.up);
        }
    }

    void WalkingAnimation() { 
        if((Input.GetButton("Horizontal") || Input.GetButton("Vertical")) == true)
        {
            moveAnimator.SetFloat("MoveSpeed", SpeedManager.SpeedModifider); // IF axis are down, use speedmodifier
        }
        else { // IF axis released, use movementSqrMagnitude so PlayerIdle can work properly
            moveAnimator.SetFloat("MoveSpeed", movementSqrMagnitude); 
        }
    }
}

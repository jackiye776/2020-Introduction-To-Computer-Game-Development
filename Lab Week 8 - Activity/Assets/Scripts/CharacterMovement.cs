using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Animator animator;
    public AudioSource footstepSource;
    public AudioClip [] footstepClips;
    public AudioSource backgroundMusic;

    public float walkSpeed = 1.5f;

    private Vector3 movement;
    private float movementSqrMagnitude;

    // Update is called once per frame
    void Update()
    {
        GetMovementInput();
        if (!RaycastCheck()) // Stops position, audio & animation if raycast hits something
        {
            CharacterPosition();
            WalkingAnimation();
            FootstepAudio();
        }
        CharacterRotation();
    }

    void GetMovementInput()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        movement = Vector3.ClampMagnitude(movement, 1.0f);
        movementSqrMagnitude = movement.sqrMagnitude;
        //Debug.Log(movement);
    }

    void CharacterPosition()
    {
        transform.Translate(movement * Time.deltaTime * walkSpeed, Space.World);
    }

    void CharacterRotation()
    {
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }
    }

    void WalkingAnimation()
    {
        animator.SetFloat("MoveSpeed", movementSqrMagnitude);
    }

    void FootstepAudio()
    {
        if(movementSqrMagnitude > 0.3f && !footstepSource.isPlaying)
        {
            if (footstepSource.clip == footstepClips[0])
            {
                footstepSource.clip = footstepClips[1];
            }
            else if (footstepSource.clip == footstepClips[1])
            {
                footstepSource.clip = footstepClips[0];
            }
            footstepSource.volume = movementSqrMagnitude;
            footstepSource.Play();

            backgroundMusic.volume = 0.5f;
        } 
        else if (movementSqrMagnitude <= 0.3f && footstepSource.isPlaying)
        {
            footstepSource.Stop();
            backgroundMusic.volume = 1.0f;
        }
    }

    private void OnTriggerExit(Collider other) // Trigger
    {
        Debug.Log("Trigger Exit: " + other.name + " : " + other.transform.position);
    }

    private void OnCollisionEnter(Collision collision) // Rigidbody Collider
    {
        Debug.Log("Collision Enter: " + collision.gameObject.name + " : " + collision.contacts[0].point);
    }

    private void OnCollisionStay(Collision collision) // Static Collider
    {
        if (collision.gameObject.tag == "Impassable")
        {
            Debug.Log("Collision Stay: " + collision.gameObject.name);
        }
    }

    private bool RaycastCheck() // Raycasting
    {
        RaycastHit hitInfo; // Player's position & direction, & maxDistance of 5.0f;
        bool hit = Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), transform.forward, out hitInfo, 5.0f);
        if(hit)
        {
            Debug.Log("Raycast Hit: " + hitInfo.collider.name);
            if(hitInfo.collider.gameObject.tag == "Freeze")
            {
                return true;
            }
        }
        return false;
    }

}

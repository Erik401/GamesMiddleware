using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovementScript : MonoBehaviour
{
    Animator charAnimator;
    Transform charPosition;
    float playerHor, playerVert;
    // Start is called before the first frame update
    void Start()
    {
        charAnimator = GetComponent<Animator>();
        charPosition = GetComponent<Transform>();


    }

    // Update is called once per frame
    void Update()
    {

        playerHor = Input.GetAxis("Horizontal");
        playerVert = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3 (playerHor, 0, playerVert) * 2f *Time.deltaTime;

        movement = charPosition.TransformDirection(movement);
        /*
        if (Input.GetKey(KeyCode.W)) {
            charAnimator.SetBool("isRunningForward", true);
            charPosition.position += transform.forward * 5f * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            charAnimator.SetBool("isRunningForward", false);
        }


        if (Input.GetKey(KeyCode.S))
        {
            charAnimator.SetBool("isRunningBackward", true);
            charPosition.position -= transform.forward * 5f * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            charAnimator.SetBool("isRunningBackward", false);
        }


        if (Input.GetKey(KeyCode.A))
        {
            charAnimator.SetBool("isRunningLeft", true);
            charPosition.position -= transform.right * 5f * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            charAnimator.SetBool("isRunningLeft", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            charAnimator.SetBool("isRunningRight", true);
            charPosition.position += transform.right * 5f * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            charAnimator.SetBool("isRunningRight", false);
        }
        */


        charAnimator.SetFloat("vel z", Input.GetAxis("Horizontal"), 0.08f,Time.deltaTime );
        charAnimator.SetFloat("vel x", Input.GetAxis("Vertical"), 0.08f, Time.deltaTime);


        charPosition.position += movement;

    }
}

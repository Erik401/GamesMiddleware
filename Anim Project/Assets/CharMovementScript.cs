using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharMovementScript : MonoBehaviour
{
    Animator charAnimator;
    Transform charPosition;
    float playerHor, playerVert, lookX, runSpeed;
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        charAnimator = GetComponent<Animator>();
        charPosition = GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
        runSpeed = 1f;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) { 
        Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetMouseButtonDown(0)) {
            charAnimator.SetBool("isAttack", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            charAnimator.SetBool("isAttack", false);
        }

        playerHor = Input.GetAxisRaw("Horizontal");
        playerVert = Input.GetAxisRaw("Vertical");
        lookX = Input.GetAxis("Mouse X");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement = new Vector3(playerHor, 0, playerVert) * (runSpeed * 2f) * Time.deltaTime;
        }
        else {
            movement = new Vector3(playerHor, 0, playerVert) * runSpeed * Time.deltaTime;
            playerHor = playerHor / 2;
            playerVert = playerVert / 2;
        }

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





        charAnimator.SetFloat("vel z", playerHor, 0.1f, Time.deltaTime);
        charAnimator.SetFloat("vel x", playerVert, 0.1f, Time.deltaTime);


        charPosition.position += movement;
        charPosition.Rotate(new Vector3(0f, lookX, 0f));

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{

    Transform camTransform, playerTransform;
    Vector3 camOffset;
    // Start is called before the first frame update
    void Start()
    {
        camTransform = gameObject.GetComponent<Transform>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        camOffset = camTransform.position - playerTransform.position;
        
    }

    // Update is called once per frame
    void Update()
    {

        camTransform.RotateAround(playerTransform.position, transform.right,  - Input.GetAxis("Mouse Y"));
        camOffset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 4f, Vector3.up) * camOffset;
        transform.position =  Vector3.Lerp(transform.position, (playerTransform.position + camOffset), 20f * Time.deltaTime);

        
    }
}

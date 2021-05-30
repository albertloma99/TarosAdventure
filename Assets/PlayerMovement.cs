using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform camera;
    public Rigidbody rb;
    public float force;
    public float jumpForce;
    private CameraMatrixBaseChanger cameraMatrixBaseChanger;
    public bool isGrounded;
    private void Start()
    {
        cameraMatrixBaseChanger = GetComponent<CameraMatrixBaseChanger>();
        
    }

    void Update()
    {
        if(isGrounded)
            rb.AddForce(cameraMatrixBaseChanger.GetMovement() * force);

        if (Input.GetKeyDown(KeyCode.Space)) //Yo desisto :(
        {
            if(isGrounded)
                rb.AddForce(Vector3.up*jumpForce , ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        isGrounded = true;
    }

    private void OnCollisionStay(Collision other)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision other)
    {
        isGrounded = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonMove : MonoBehaviour
{
    private CharacterController controller;
    private GameObject mainCamera;
    private Rigidbody rb;

    private Vector2 move;

    [SerializeField] private float moveSpeed = 6.0f;
    [SerializeField] private float jumpForce = 5.0f;

    private float targetRotation = 0.0f;
    private Vector3 targetDir;


    void Start()
    {
        if(mainCamera == null)
        {
            mainCamera = GameObject.FindGameObjectWithTag( "MainCamera" );
        }

        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(move != Vector2.zero)
        {
            Vector3 inputDir = new Vector3( move.x,0.0f,move.y ).normalized;
            targetRotation = Mathf.Atan2( inputDir.x,inputDir.z ) * Mathf.Rad2Deg + mainCamera.transform.eulerAngles.y;
            targetDir = Quaternion.Euler( 0.0f,targetRotation,0.0f ) * Vector3.forward;

            //controller.Move(targetDir.normalized * moveSpeed * Time.deltaTime);
            rb.velocity = new Vector3( moveSpeed * targetDir.x,rb.velocity.y,moveSpeed * targetDir.z );
        }
    }

    void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        rb.velocity = new Vector3( rb.velocity.x,jumpForce,rb.velocity.z );
    }
}

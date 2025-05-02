using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float speed = 5.0f;
    public Vector3 direction = Vector3.forward;
    private Vector3 worldDirection;
    private Rigidbody affectedRb;
    private Vector3 ConveyorVelocity;

    void Start()
    {
        worldDirection = transform.TransformDirection(direction).normalized;
    }

    void OnCollisionStay(Collision collision)
    {
        affectedRb = collision.collider.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (affectedRb != null)
        {
            ConveyorVelocity = worldDirection * speed;
            affectedRb.velocity += ConveyorVelocity;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        affectedRb = null;
    }
}

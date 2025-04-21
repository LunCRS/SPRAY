using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Rigidbody rb;
    private Transform trans;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed = 114f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();

        direction = trans.forward;

        rb.velocity = new Vector3(direction.x * speed, direction.y * speed, direction.z * speed);
        //rb.velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

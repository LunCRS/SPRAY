using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMachine : MonoBehaviour
{
    private Renderer rend;

    public Vector3 movement;
    public float distance = 1f;
    public float speed = 0.1f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private bool movingToTarget = true;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = transform.position + movement * distance;

        rend = GetComponent<Renderer>();

        rend.material.color = Color.black;
    }

    public void move()
    {
        isMoving = true;
        movingToTarget = true;
    }

    void Update()
    {
        if (!isMoving) return;

        Vector3 destination = movingToTarget ? targetPosition : startPosition;

        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        if (transform.position == destination)
        {
            if (movingToTarget)
            {
                movingToTarget = false;
            }
            else
            {
                isMoving = false;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWall : MonoBehaviour
{
    public Transform Player_Left;
    public Transform Player_Right;
    public Vector3 moveDirection = Vector3.forward;
    public float baseSpeed = 1.5f;
    public float speedMultiplier = 0.3f;
    public Transform birthPlace;
    private Vector3 initialPosition;
    public bool isMoving = true;

    void Start()
    {
        initialPosition = transform.position;
    }
    void Update()
    {
        if (isMoving && Player_Left != null && Player_Right != null)
        {
            float distanceToLeft = Vector3.Distance(transform.position, Player_Left.position);
            float distanceToRight = Vector3.Distance(transform.position, Player_Right.position);
            
            Transform closestPlayer = distanceToLeft < distanceToRight ? Player_Left : Player_Right;

            Vector3 player_position = closestPlayer.position;
            float distanceToPlayer = Vector3.Dot(player_position - transform.position, moveDirection);
            float currentSpeed = baseSpeed + (distanceToPlayer * speedMultiplier);
            transform.Translate(moveDirection * currentSpeed * Time.deltaTime);
        }
    }

    public void ResetWallPosition()
    {
        if (birthPlace != null)
        {
            transform.position = birthPlace.position;
        }
        else
        {
            transform.position = initialPosition;
        }
    }
}
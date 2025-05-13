using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWall : MonoBehaviour
{
    public Transform Player_Left;
    public Transform Player_Right;
    public Vector3 moveDirection = Vector3.forward;
    public float baseSpeed = 2f;
    public float speedMultiplier = 0.5f;

    void Update()
    {
        if (Player_Left != null && Player_Right != null)
        {
            Vector3 player_position = (Player_Left.position + Player_Right.position) / 2f;
            float distanceToPlayer = Vector3.Dot(player_position - transform.position, moveDirection);
            float currentSpeed = baseSpeed + (distanceToPlayer * speedMultiplier);
            transform.Translate(moveDirection * currentSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerControl player = other.GetComponentInParent<PlayerControl>();
            if (player != null)
            {
                player.isDead = true;
            }
        }
    }
}
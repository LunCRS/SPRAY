using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannotJump : MonoBehaviour
{
    private float originalJumpForce;
    private Rigidbody affectedRb;
    void OnCollisionStay(Collision collision)
    {
        affectedRb = collision.collider.GetComponent<Rigidbody>();
        PlayerControl player = collision.collider.GetComponent<PlayerControl>();

        if (player != null)
        {
            if (player.jumpForce != 0)
            {
                originalJumpForce = player.jumpForce;
            }
            player.jumpForce = 0;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        PlayerControl player = collision.collider.GetComponent<PlayerControl>();
        if (player != null)
        {
            player.jumpForce = originalJumpForce;
        }
    }
}

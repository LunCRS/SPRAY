using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialDead : MonoBehaviour
{
    public PlayerControl Player_Left;
    public PlayerControl Player_Right;
    public FireWall FireWall;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player_Left.isDead = true;
            Player_Right.isDead = true;
            FireWall.ResetWallPosition();
        }
    }
}
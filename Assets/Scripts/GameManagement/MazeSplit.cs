using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSplit : MonoBehaviour
{
    void OnTriggerEnter ( Collider other )
    {
        if( other.CompareTag( "Player" ) )
        {
            PlayerControl player = other.GetComponentInParent<PlayerControl>();
            if( player != null )
            {
                if(player.playerID == 2)
                    player.isDead = true;
            }
        }
    }
}

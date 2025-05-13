using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    void OnTriggerEnter ( Collider other )
    {
        if( other.CompareTag( "Player" ) )
        {
            PlayerControl player = other.GetComponentInParent<PlayerControl>();
            if( player != null )
            {
                player.isDead = true;
            }
        }
        else if( other.CompareTag( "ColorBlock" ) )
        {
            BlockReset block = other.GetComponent<BlockReset>();
            if( block != null )
            {
                block.Reset();
            }
        }
    }
}

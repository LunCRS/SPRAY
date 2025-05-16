using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public int DeadZoneType;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerControl player = other.GetComponentInParent<PlayerControl>();
            if (DeadZoneType == 1)
            {
                if (player.player_type == 1)
                {
                    player.isDead = true;
                }
            }
            else if (DeadZoneType == 2)
            {
                if (player.player_type == 2)
                {
                    player.isDead = true;
                }
            }
            else if (DeadZoneType == 0)
            {
                player.isDead = true;
            }

        }
        else if (other.CompareTag("ColorBlock"))
        {
            BlockReset block = other.GetComponent<BlockReset>();
            if (block != null)
            {
                block.Reset();
            }
        }
    }
}

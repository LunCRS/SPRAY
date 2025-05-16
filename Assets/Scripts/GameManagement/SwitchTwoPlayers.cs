using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTwoPlayers : MonoBehaviour
{
    [SerializeField] private Transform place_L, place_R;
    void OnTriggerEnter ( Collider other )
    {
        if( other.CompareTag( "Player" ) )
        {
            PlayerControl player = other.GetComponent<PlayerControl>();
            if( player != null )
            {
                if( player.playerID == 1 )
                    player.birthPlace = place_L;
                else
                    player.birthPlace = place_R;
            }
        }
    }
}

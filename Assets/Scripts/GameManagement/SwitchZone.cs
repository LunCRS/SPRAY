using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchZone : MonoBehaviour
{
    [SerializeField] private Transform place;
    void OnTriggerEnter ( Collider other )
    {
        if( other.CompareTag( "Player" ) )
        {
            PlayerControl player = other.GetComponentInParent<PlayerControl>();
            if( player != null )
            {
                player.birthPlace = place;
            }
        }
    }
}

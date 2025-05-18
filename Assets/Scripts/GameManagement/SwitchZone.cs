using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchZone : MonoBehaviour
{
    [SerializeField] private Transform place_R;
    [SerializeField] private Transform place_L;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerControl player = other.GetComponent<PlayerControl>();
            if (player.player_type == 1)
            {
                player.birthPlace = place_R;
            }
            else if (player.player_type == 2)
            {
                player.birthPlace = place_L;
            }
        }
    }
}

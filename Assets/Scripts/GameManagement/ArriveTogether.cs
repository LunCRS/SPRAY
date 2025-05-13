using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArriveTogether : MonoBehaviour
{
    [SerializeField] private GameObject moveMachine;
    private bool lArrive = false, rArrive = false;

    private void Update ()
    {
        if( lArrive && rArrive )
        {
            moveMachine.GetComponent<MoveMachine>().move();
        }
    }


    void OnTriggerEnter ( Collider other )
    {
        if( other.CompareTag( "Player" ) )
        {
            PlayerControl player = other.GetComponentInParent<PlayerControl>();
            if( player != null )
            {
                if(player.playerID == 1 )
                {
                    lArrive = true;
                }
                if(player.playerID == 2 )
                {
                    rArrive = true;
                }
            }
        }
    }


}

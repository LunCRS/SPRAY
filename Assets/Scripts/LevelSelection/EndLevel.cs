using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    private bool lArrive = false, rArrive = false;


    void Update ()
    {
        if( lArrive && rArrive )
        {
            SceneManager.LoadScene( "LevelSelection" );
        }
    }


    private void OnTriggerEnter ( Collider other )
    {
        if(other.CompareTag("Player"))
        {
            PlayerControl player = other.GetComponent<PlayerControl>();
            if(player != null)
            {
                if( player.playerID == 1 )
                    lArrive = true;
                else
                    rArrive = true;
            }
        }
    }

    private void OnTriggerExit ( Collider other )
    {
        if( other.CompareTag( "Player" ) )
        {
            PlayerControl player = other.GetComponent<PlayerControl>();
            if( player != null )
            {
                if( player.playerID == 1 )
                    lArrive = false;
                else
                    rArrive = false;
            }
        }
    }
}

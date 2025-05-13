using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpeedControl : MonoBehaviour
{
    [SerializeField] private GameObject adjustObj;
    [SerializeField] private float deltaSpeed = 10f;
    [SerializeField] private float adjustTime = 2f;
    private float adjustTimer = 0f;
    private float adjustSpeed;
    private PlayerControl player;
    private bool change = false;

    private void Start ()
    {
        player = adjustObj.GetComponent<PlayerControl>();
        adjustSpeed = deltaSpeed / adjustTime;
    }

    private void Update ()
    {
        if(change)
        {
            if( adjustTimer <= adjustTime )
            {
                player.ChangeMoveSpeed( adjustSpeed * Time.deltaTime );
                adjustTimer += Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter ( Collider other )
    {
        if( other.CompareTag( "Player" ) )
        {
            PlayerControl player = other.GetComponent<PlayerControl>();
            if( player != null )
            {
                change = true;
            }

        }
    }

}

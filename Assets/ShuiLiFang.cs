using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuiLiFang : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    private PlayerControl playerControl1;
    private PlayerControl playerControl2;


    void Start()
    {
        playerControl1 = player1.GetComponent<PlayerControl>();
        playerControl2 = player2.GetComponent<PlayerControl>();

    }

    // Update is called once per frame
    void Update()
    {



        }

    void OnTriggerEnter ( Collider other )
    {   
        if (other.CompareTag( "Player" ) )
        {
            playerControl1.isDead = true;
            playerControl2.isDead = true;
        }

        
        }
    }



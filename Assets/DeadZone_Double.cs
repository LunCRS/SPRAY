using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone_Double : MonoBehaviour
{
    public int DeadZoneType;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    PlayerControl playerControl1;
    PlayerControl playerControl2;

    void Start()
    {
        playerControl1 = player1.GetComponent<PlayerControl>();
        playerControl2 = player2.GetComponent<PlayerControl>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerControl1.isDead = true;
            playerControl2.isDead = true;



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


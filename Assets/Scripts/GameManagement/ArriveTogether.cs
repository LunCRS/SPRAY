using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArriveTogether : MonoBehaviour
{
    [SerializeField] private GameObject Player_L;
    [SerializeField] private GameObject Player_R;
    [SerializeField] private Transform Birth_L;
    [SerializeField] private Transform Birth_R;
    private PlayerControl lPlayer, rPlayer;
    private bool lArrive = false, rArrive = false;

    void Start()
    {
        lPlayer = Player_L.GetComponent<PlayerControl>();
        rPlayer = Player_R.GetComponent<PlayerControl>();
    }

    private void Update()
    {
        if (lArrive && rArrive)
        {
            lPlayer.birthPlace = Birth_L;
            rPlayer.birthPlace = Birth_R;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerControl player = other.GetComponentInParent<PlayerControl>();
            if (player != null)
            {
                if (player.playerID == 1)
                {
                    lArrive = true;
                }
                if (player.playerID == 2)
                {
                    rArrive = true;
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerControl player = other.GetComponentInParent<PlayerControl>();
            if (player != null)
            {
                if (player.playerID == 1)
                {
                    lArrive = false;
                }
                if (player.playerID == 2)
                {
                    rArrive = false;
                }
            }
        }
    }


}

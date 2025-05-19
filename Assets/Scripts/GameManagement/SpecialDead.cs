using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialDead : MonoBehaviour
{
    public GameObject Player_L, Player_R;
    private PlayerControl control_L, control_R;
    public FireWall FireWall;
    [SerializeField] private GameObject reset;
    ResetManager_2 resetManager;

    private void Start ()
    {
        control_L = Player_L.GetComponent<PlayerControl>();
        control_R = Player_R.GetComponent<PlayerControl>();

        resetManager = reset.GetComponent<ResetManager_2>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            resetManager.ResetAll();
            Player_L.transform.position = control_L.birthPlace.position;
            Player_R.transform.position = control_R.birthPlace.position;
            FireWall.ResetWallPosition();
        }
    }
}
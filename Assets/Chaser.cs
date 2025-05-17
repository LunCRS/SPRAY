using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 initialPosition;
    public GameObject Player_L;
    public GameObject Player_R;
    public GameObject ResetControl;

    private PlayerControl player_L; // 声明为成员变量
    private PlayerControl player_R; // 声明为成员变量
    private ResetMoveMachine ResetMoveMachine;
    private ResetMovePlate ResetMovePlate;
    private ResetColorBlocks ResetColorblock;
    void Start()
    {
        // ResetManager.Instance.Register(this);
        initialPosition = transform.position;
        player_L = Player_L.GetComponent<PlayerControl>();
        player_R = Player_R.GetComponent<PlayerControl>();
        ResetMoveMachine = ResetControl.GetComponent<ResetMoveMachine>();
        ResetMovePlate = ResetControl.GetComponent<ResetMovePlate>();
        ResetColorblock = ResetControl.GetComponent<ResetColorBlocks>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player_L.IsChaser() || player_R.IsChaser())
        {
            Debug.Log("Chaser_die");

            player_L.isDead = true;
            player_R.isDead = true;
            ResetMoveMachine.ResetAllMachines();
            ResetMovePlate.ResetAllMachines_MovePlate();
            ResetColorblock.ResetAllBlocks();


            //     if (ResetManager.Instance != null)
            //     {
            //         ResetManager.Instance.ResetAll();
            //     }
            // }
        }

        // public void OnReset()
        // {
        //     transform.position = initialPosition;

        // }


    }
}

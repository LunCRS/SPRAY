using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    private Renderer rend;
    public GameObject launcher;

    [Tooltip("0 means the stage changes the color of bullet / 1 means the stage changes the color of player / 2 means shoot machine / 3 means move machine ")]
    public int stageType;
    [SerializeField] private Color selfColor;
    private MachineController machine_controller;
    private bool isPlayerOnStage = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = selfColor;

        machine_controller = FindObjectOfType<MachineController>();
        if (machine_controller != null)
        {
            machine_controller.RegisterButtonLauncherPair(gameObject, launcher);
        }
    }

    void Update()
    {
        if (isPlayerOnStage && stageType == 5)
        {
            GameObject moveplate = machine_controller.GetLauncherForButton(gameObject);
            if (moveplate != null)
            {
                moveplate.GetComponent<MovePlate>().Move();

            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (stageType == 0)
            {
                other.GetComponentInParent<PlayerControl>().SetBulletColor(selfColor);
            }
            else if (stageType == 1)
            {
                other.GetComponentInParent<PlayerControl>().SetPlayerColor(selfColor);
            }
            else if (stageType == 2)
            {
                GameObject shoot_machine = machine_controller.GetLauncherForButton(gameObject);
                shoot_machine.GetComponent<ShootMachine>().shoot();
            }
            else if (stageType == 3)
            {
                GameObject move_machine = machine_controller.GetLauncherForButton(gameObject);
                move_machine.GetComponent<MoveMachine>().move();
            }
            else if (stageType == 4)
            {
                GameObject lens = machine_controller.GetLauncherForButton(gameObject);
                lens.GetComponent<lensrotation>().changerotation(1);
            }
            else if (stageType == 5)
            {
                isPlayerOnStage = true;

            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && stageType == 5)
        {
            isPlayerOnStage = false;

            // 可选：通知 MovePlate 停止移动
            GameObject moveplate = machine_controller.GetLauncherForButton(gameObject);
            if (moveplate != null)
            {
                moveplate.GetComponent<MovePlate>().Stop();
            }
        }
    }
}

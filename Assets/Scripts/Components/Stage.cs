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
        }
    }
}

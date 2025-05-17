using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laaserreviever : MonoBehaviour
{

    [SerializeField] private Material activatedMaterial;
    private MachineController machine_controller;
    public GameObject launcher;

    private Renderer rend;
    private bool isActive = false;

    void Start()
    {
        rend = GetComponent<Renderer>();

        machine_controller = FindObjectOfType<MachineController>();
        if (machine_controller != null)
        {
            machine_controller.RegisterButtonLauncherPair(gameObject, launcher);
        }
    }

    public void Activate()
    {
        if (!isActive)
        {
            Debug.Log("Receiver Activated!");
            GameObject move_machine = machine_controller.GetLauncherForButton(gameObject);
            move_machine.GetComponent<MoveMachine>().move();

            isActive = true;
        }
    }
}


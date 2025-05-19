using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_partner : MonoBehaviour
{
    private Renderer rend;
    public GameObject launcher;
    [SerializeField] private Color selfColor;
    private MachineController machine_controller;
    private bool isPlayerOnStage = false;

    public int stage_number;
    public GameObject Partner;
    public bool isPlayerOnStage_Partner = false;
    private Stage_partner partner;
    public int stage_type;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = selfColor;
        machine_controller = FindObjectOfType<MachineController>();
        partner = Partner.GetComponent<Stage_partner>();
        if (stage_number == 0)
        {
            machine_controller.RegisterButtonLauncherPair(gameObject, launcher);
        }
    }

    // Update is called once per frame
    void Update()
    {
        isPlayerOnStage_Partner = Partner.GetComponent<Stage_partner>().isPlayerOnStage;
        if (stage_number == 0)
        {
            ActivateStage();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        PlayerControl player = other.GetComponent<PlayerControl>();
        if (stage_number == 0)
        {
            if (other.CompareTag("Player") && player.player_type == 2)
            {
                isPlayerOnStage = true;
            }
        }
        else if (stage_number == 1)
        {
            if (other.CompareTag("Player") && player.player_type == 1)
            {
                isPlayerOnStage = true;
            }
        }

    }

    void OnTriggerExit(Collider other)
    {
        isPlayerOnStage = false;
    }

    void ActivateStage()
    {
        if (isPlayerOnStage && isPlayerOnStage_Partner)
        {
            if (stage_type == 0)
            {
                GameObject move_machine = machine_controller.GetLauncherForButton(gameObject);
                move_machine.GetComponent<MoveMachine>().move();
            }
            else if (stage_type == 1)
            {
                GameObject move_machine = machine_controller.GetLauncherForButton(gameObject);
                move_machine.GetComponent<MoveMachine>().stop();
            }
            else if (stage_type == 2)
            {
                GameObject targetObject = machine_controller.GetLauncherForButton(gameObject);
                targetObject.SetActive(false);
            }
            else if (stage_type == 3)
            {
                GameObject targetObject = machine_controller.GetLauncherForButton(gameObject);
                targetObject.SetActive(true);
            }

        }
    }
}

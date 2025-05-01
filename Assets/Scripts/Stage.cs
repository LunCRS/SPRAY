using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    private Renderer rend;
    public GameObject launcher;

    [Tooltip("0 means the stage changes the color of bullet / 1 means the stage changes the color of player. ")]
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
                Debug.Log("Stage 2");
                GameObject shoot_machine = machine_controller.GetLauncherForButton(gameObject);
                shoot_machine.GetComponent<shoot_machine>().shoot();
            }
            else if (stageType == 3)
            {
                Debug.Log("Stage 3");
                GameObject move_machine = machine_controller.GetLauncherForButton(gameObject);
                move_machine.GetComponent<move_machine>().move();
            }
        }
    }
}

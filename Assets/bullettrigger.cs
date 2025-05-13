using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullettrigger : MonoBehaviour
{
    private Renderer rend;
    private MachineController machine_controller;
    public GameObject launcher;

    public Color selfcolor;
    public Color bulletcolor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = selfcolor;

        machine_controller = FindObjectOfType<MachineController>();
        if (machine_controller != null)
        {
            machine_controller.RegisterButtonLauncherPair(gameObject, launcher);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.GetComponent<Bullet>();
        bulletcolor = bullet.selfColor;
        if (bullet != null)
        {
            // if (bullet.selfColor == Color.red || (bullet.selfColor == selfcolor && selfcolor == Color.white))
            // {
            //     TriggerRedEffect();
            // }
            // else if (bullet.selfColor == Color.blue || (bullet.selfColor == selfcolor && selfcolor == Color.white))
            // {
            //     TriggerBlueEffect();
            // }
            GameObject lens = machine_controller.GetLauncherForButton(gameObject);
            lens.GetComponent<LensEmitter>().objectRenderer.material.color = bulletcolor;
        }
    }
    //     private void TriggerRedEffect()
    //     {
    //         GameObject lens = machine_controller.GetLauncherForButton(gameObject);
    //         lens.GetComponent<lensrotation>().changerotation(1);
    //     }

    //     private void TriggerBlueEffect()
    //     {
    //         GameObject lens = machine_controller.GetLauncherForButton(gameObject);
    //         lens.GetComponent<lensrotation>().changerotation(-1);
    //     }
}

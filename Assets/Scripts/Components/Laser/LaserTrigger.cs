using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LaserTrigger : MonoBehaviour
{
    [SerializeField] private Material originalMaterial;
    [SerializeField] private Material activatedMaterial;

    public GameObject launcher;
    public Color initialColor = Color.white;
    public int triggerType;
    private MachineController machine_controller;

    public Color hitcolor1 = Color.white;
    public Color hitcolor2 = Color.white;
    public Color lastColor = Color.white;


    public Color requiredColor = Color.red;

    private Renderer rend;
    private bool hasActivated = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (originalMaterial == null)
            originalMaterial = rend.material;

        rend.material.color = initialColor;

        machine_controller = FindObjectOfType<MachineController>();
        if (machine_controller != null)
        {
            machine_controller.RegisterButtonLauncherPair(gameObject, launcher);
        }
    }

    public void Activate(Color laserColor)
    {
        if (triggerType == 3)
        {
            if (activatedMaterial != null)
            {

                rend.material = activatedMaterial;
                rend.material.color = hitcolor1;



                GameObject colorblockmachine = machine_controller.GetLauncherForButton(gameObject);
                colorblockmachine.GetComponent<colorblockmachine>().Activate(lastColor);
            }
        }
        if (laserColor == requiredColor && !hasActivated)
        {
            if (activatedMaterial != null)
            {
                rend.material = activatedMaterial;
                rend.material.color = requiredColor;

                if (triggerType == 0)
                {
                    GameObject shoot_machine = machine_controller.GetLauncherForButton(gameObject);
                    shoot_machine.GetComponent<ShootMachine>().shoot();
                }
                else if (triggerType == 1)
                {
                    GameObject move_machine = machine_controller.GetLauncherForButton(gameObject);
                    move_machine.GetComponent<MoveMachine>().move();
                }
                else if (triggerType == 4)
                {
                    GameObject targetObject = machine_controller.GetLauncherForButton(gameObject);
                    if (targetObject != null)
                    {
                        targetObject.SetActive(!targetObject.activeSelf);
                    }
                }


                hasActivated = true;
            }
            else if (laserColor != requiredColor)
            {
                hasActivated = false;
            }
        }
    }

    public void ResetHitColor()
    {
        hitcolor1 = Color.white;
    }

    public void hit(Color color)
    {
        if (hitcolor1 == Color.white)
        {
            hitcolor1 = color;
            lastColor = hitcolor1;
        }

        else if (hitcolor1 != Color.white && hitcolor1 != color)
            hitcolor2 = color;
    }

    private void selfcheck()
    {
        if (hitcolor1 == hitcolor2)
        {
            hitcolor2 = Color.white;
        }

    }
}
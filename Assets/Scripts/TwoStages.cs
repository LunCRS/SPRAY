using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoStages : MonoBehaviour
{
    private MoveMachine moveMachine;
    public bool red, blue;

    private void Update ()
    {
        if(red && blue)
        {
            moveMachine = GetComponent<MoveMachine>();
            if( moveMachine != null )
            {
                moveMachine.move();
            }
        }
    }
}

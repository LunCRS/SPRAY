using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMoveMachine : MonoBehaviour
{
    public List<GameObject> moveMachines = new List<GameObject>();
    private Dictionary<GameObject, MachineInitialState> machineInitialStates = new Dictionary<GameObject, MachineInitialState>();
    private struct MachineInitialState
    {
        public Vector3 position;
        public bool isActive;
        public bool isMoving;
        public bool movingToTarget;
        public Vector3 velocity;
    }
    void Start()
    {
        foreach (var machine in moveMachines)
        {
            if (machine != null)
            {
                Rigidbody rb = machine.GetComponent<Rigidbody>();
                MoveMachine moveMachine = machine.GetComponent<MoveMachine>();

                machineInitialStates[machine] = new MachineInitialState
                {
                    position = machine.transform.position,
                    isActive = machine.activeSelf,
                    isMoving = moveMachine != null ? moveMachine.isMoving : false,
                    movingToTarget = moveMachine != null ? moveMachine.movingToTarget : true,
                    velocity = rb != null ? rb.velocity : Vector3.zero,
                };
            }
        }
    }
    public void ResetAllMachines()
    {
        foreach (var pair in machineInitialStates)
        {
            GameObject machine = pair.Key;
            MachineInitialState state = pair.Value;

            if (machine != null)
            {
                Rigidbody rb = machine.GetComponent<Rigidbody>();
                MoveMachine moveMachine = machine.GetComponent<MoveMachine>();

                machine.transform.position = state.position;
                machine.SetActive(state.isActive);

                if (rb != null)
                {
                    rb.velocity = state.velocity;
                }

                if (moveMachine != null)
                {
                    moveMachine.isMoving = state.isMoving;
                    moveMachine.movingToTarget = state.movingToTarget;
                }
            }
        }
    }
}

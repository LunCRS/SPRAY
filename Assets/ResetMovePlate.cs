using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMovePlate : MonoBehaviour
{
    public List<GameObject> moveMachines = new List<GameObject>();
    private Dictionary<GameObject, MachineInitialState_MovePlate> machineInitialStates = new Dictionary<GameObject, MachineInitialState_MovePlate>();
    private struct MachineInitialState_MovePlate
    {
        public Vector3 position;
        public bool isMoving;
        public bool movingForward;
        public float currentDistance;
    }
    void Start()
    {
        foreach (var machine in moveMachines)
        {
            if (machine != null)
            {
                Rigidbody rb = machine.GetComponent<Rigidbody>();
                MovePlate moveMachine = machine.GetComponent<MovePlate>();

                machineInitialStates[machine] = new MachineInitialState_MovePlate
                {
                    position = machine.transform.position,
                    isMoving = moveMachine != null ? moveMachine.isMoving : false,
                    movingForward = moveMachine != null ? moveMachine.movingForward : true,
                    currentDistance = 0f,
                };
            }
        }
    }
    public void ResetAllMachines_MovePlate()
    {
        foreach (var pair in machineInitialStates)
        {
            GameObject machine = pair.Key;
            MachineInitialState_MovePlate state = pair.Value;

            if (machine != null)
            {
                MovePlate moveMachine = machine.GetComponent<MovePlate>();

                machine.transform.position = state.position;

                if (moveMachine != null)
                {
                    moveMachine.isMoving = state.isMoving;
                    moveMachine.movingForward = state.movingForward;
                    moveMachine.currentDistance = state.currentDistance;
                }
            }
        }
    }
}

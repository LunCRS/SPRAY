using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    [SerializeField] private GameObject exitMachine;
    [SerializeField] private GameObject[] keys;

    private MoveMachine exit;
    private bool keysGet = false;
    
    void Start()
    {
        exit = exitMachine.GetComponent<MoveMachine>();
    }

    
    void Update()
    {
        if(keysGet)
        {
            exit.move();

        }
    }

    public void CheckKeys()
    {
        foreach(var key in keys)
        {
            if(key.activeSelf)
                return;
        }
        keysGet = true;
    }
}

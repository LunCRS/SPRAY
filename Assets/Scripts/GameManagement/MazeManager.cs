using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MazeManager : MonoBehaviour
{
    [SerializeField] private GameObject exitMachine;
    [SerializeField] private GameObject[] keys;
    [SerializeField] private TextMeshPro goalText;
    private int keysNum;
    private int keysGet = 0;

    private MoveMachine exit;
    private bool getAllKeys = false;

    void Start()
    {
        exit = exitMachine.GetComponent<MoveMachine>();
        keysNum = keys.Length;
    }


    void Update()
    {
        // Debug.Log(keys.Length);
        if (getAllKeys && exit != null)
        {
            exit.move();
        }

        goalText.text = "Goal " + keysGet + "/" + keysNum;
    }

    public void CheckKeys()
    {
        foreach (var key in keys)
        {
            if (key.activeSelf)
                return;
        }
        getAllKeys = true;
    }

    public void GetKey()
    {
        keysGet++;
        CheckKeys();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipLevel: MonoBehaviour
{
    [SerializeField] private GameObject wall;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
            wall.SetActive(!wall.activeSelf );
    }
}

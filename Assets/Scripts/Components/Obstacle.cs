using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Renderer rend;

    void Start()
    {
        rend = GetComponentInChildren<Renderer>();

        rend.material.color = Color.black;
    }

    void Update()
    {
        
    }
}

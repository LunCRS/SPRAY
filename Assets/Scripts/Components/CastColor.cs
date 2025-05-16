using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastColor : MonoBehaviour
{
    private Renderer rend;
    [SerializeField] private Color color = Color.black;
    void Start()
    {
        rend = GetComponent<Renderer>();

    }

    void Update()
    {
        rend.material.color = color;
        
    }
}

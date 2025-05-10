using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFix : MonoBehaviour
{
    private Renderer rend;
    [SerializeField] private Color color = Color.black;
    void Start()
    {
        rend = GetComponent<Renderer>();

        rend.material.color = color;
    }

    void Update()
    {
        
    }
}

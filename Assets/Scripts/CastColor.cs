using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastColor : MonoBehaviour
{
    private Renderer rend;
    [SerializeField] private Color color = Color.black;
    void Update()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = color;
    }
}

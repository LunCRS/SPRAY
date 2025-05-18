using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed = 0.5f;
    private Renderer rend;
    private Vector2 offset;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        offset = new Vector2(0, Time.time * speed);
        rend.material.mainTextureOffset = offset;
    }
}

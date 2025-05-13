using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastColor : MonoBehaviour
{
    private Renderer rend;
    [SerializeField] private Color color = Color.black;
<<<<<<< HEAD
=======
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = color;

    }

>>>>>>> origin/FullBasicComponents
    void Update()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = color;
    }
}

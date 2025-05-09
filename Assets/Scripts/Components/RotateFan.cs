using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFan : MonoBehaviour
{
    [SerializeField] private Transform transA, transB;
    [SerializeField] private float rotSpeed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transA.Rotate( -rotSpeed * Time.deltaTime,0,0 );
        transB.Rotate( -rotSpeed * Time.deltaTime,0,0 );
    }

}

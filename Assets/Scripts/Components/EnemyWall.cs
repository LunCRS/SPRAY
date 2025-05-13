using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWall : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject wall;
    private MoveMachine moveWall;

    void Start()
    {
        moveWall = wall.GetComponent<MoveMachine>();
    }

    void Update()
    {
        foreach(var enemy in enemies)
        {
            if( enemy.activeSelf )
                return;
        }
        moveWall.move();
    }
}

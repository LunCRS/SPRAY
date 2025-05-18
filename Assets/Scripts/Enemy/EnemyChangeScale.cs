using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChangeScale : MonoBehaviour
{
    private Renderer rend;

    private void Start ()
    {
        rend = GetComponent<Renderer>();

        rend.material.color = GetComponentInParent<EnemyControl>().enemyColor;
    }
}

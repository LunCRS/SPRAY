using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class no_GetEnemy : MonoBehaviour
{

    [SerializeField] private GameObject[] enemies;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var enemy in enemies)
            {
                enemy.SetActive(false);
            }
        }
    }
}

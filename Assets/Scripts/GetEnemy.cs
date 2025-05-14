using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    private bool actived = false;

    private void OnTriggerEnter ( Collider other )
    {
        if(other.CompareTag("Player") && !actived)
        {
            actived = true;
            foreach(var enemy in enemies)
            {
                enemy.SetActive( true );
            }
        }
    }
}

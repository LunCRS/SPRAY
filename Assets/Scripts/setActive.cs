using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setActive : MonoBehaviour
{
    [SerializeField] private GameObject[] objs;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var obj in objs)
            {
                obj.SetActive(true);
            }
        }
    }
}
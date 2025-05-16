using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private GameObject[] objs;
    private bool isPlayerOnButton = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {

            if (other.CompareTag("Player"))
            {
                isPlayerOnButton = true;
                ShowObjects();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null)
        {

            if (other.CompareTag("Player"))
            {
                isPlayerOnButton = false;
                HideObjects();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other == null)
        {

            if (other.CompareTag("Player") && !isPlayerOnButton)
            {
                isPlayerOnButton = true;
                ShowObjects();
            }
        }
    }

    private void ShowObjects()
    {
        foreach (var obj in objs)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }

    private void HideObjects()
    {
        foreach (var obj in objs)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }
}
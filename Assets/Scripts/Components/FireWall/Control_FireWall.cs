using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_FireWall : MonoBehaviour
{
    [SerializeField] private GameObject[] objs;
    public bool isActive = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var obj in objs)
            {
                if (obj != null)
                {
                    FireWall fireWall = obj.GetComponent<FireWall>();
                    if (fireWall != null)
                    {
                        fireWall.isMoving = isActive;
                    }
                }
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockReset : MonoBehaviour
{
    [SerializeField] private Transform pos;
    public float resetHeight = -20f;

    private void Update ()
    {
        if( transform.position.y < resetHeight )
        {
            Reset();
        }
    }

    public void Reset ()
    {
        transform.position = pos.position;
        transform.rotation = pos.rotation;
    }
}

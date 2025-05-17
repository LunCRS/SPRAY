using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lensrotation : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    public bool allowed = true;


    public void changerotation(int dir)
    {

        transform.Rotate(45f * x * dir, 45f * y * dir, 45f * z * dir);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private GameObject[] actGroup;
    [SerializeField] private GameObject[] negGroup;

    public void SetActive()
    {
        foreach( var obj in actGroup )
        {
            obj.SetActive( true );
        }
        foreach(var obj in negGroup )
        {
            obj.SetActive( false );
        }
    }
}

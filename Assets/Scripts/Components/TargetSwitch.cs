using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSwitch : MonoBehaviour
{
    [SerializeField] private GameObject[] group1;
    [SerializeField] private GameObject[] group2;
    private int activeGroup = 1;

    private void SetGroup1Active ( bool active )
    {
        foreach( var obj in group1 )
        {
            obj.SetActive( active );
        }
    }

    private void SetGroup2Active ( bool active )
    {
        foreach( var obj in group2 )
        {
            obj.SetActive( active );
        }
    }

    private void Start ()
    {
        SetGroup1Active( true );
        SetGroup2Active( false );
    }

    public void ChangeActive()
    {
        if( activeGroup == 1 )
        {
            SetGroup1Active( false );
            SetGroup2Active( true );
            activeGroup = 2;
        }
        else
        {
            SetGroup1Active( true );
            SetGroup2Active( false );
            activeGroup = 1;
        }
    }

}

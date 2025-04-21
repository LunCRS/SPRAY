using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Renderer rend;


    void Start()
    {
        rend = GetComponentInChildren<Renderer>();
    }

    void Update()
    {
        

    }

    public void ChangeColor(Color color)
    {
        rend.material.color = color;
        if( color == Color.white )
            gameObject.layer = LayerMask.NameToLayer( "Default" );
        else if( color == Color.red )
            gameObject.layer = LayerMask.NameToLayer( "Red Layer" );
        else if( color == Color.green )
            gameObject.layer = LayerMask.NameToLayer( "Green Layer" );
        else if( color == Color.blue )
            gameObject.layer = LayerMask.NameToLayer( "Blue Layer" );
    }


}

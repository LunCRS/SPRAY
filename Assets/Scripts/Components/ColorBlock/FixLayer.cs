using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixLayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.layer = LayerMask.NameToLayer( "Ground" );
    }
}

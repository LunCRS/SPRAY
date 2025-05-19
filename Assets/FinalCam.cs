using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCam : MonoBehaviour
{
    [SerializeField] private Transform lookRoot;
    [SerializeField] private Vector3 offSet;
    
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3( lookRoot.position.x,lookRoot.position.y + offSet.y,lookRoot.position.z + offSet.z );
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonDirectionFollow : MonoBehaviour
{
    private GameObject mainCamera;
    [SerializeField] private float turnSpeed;
    [SerializeField] private int playerID;
    void Start()
    {
        if( playerID == 1 )
            mainCamera = GameObject.FindGameObjectWithTag( "Cam1" );
        else
            mainCamera = GameObject.FindGameObjectWithTag( "Cam2" );
    }

    void Update()
    {
        float camRotation = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Lerp( transform.rotation,Quaternion.Euler( 0,camRotation,0 ),turnSpeed * Time.deltaTime );
    }
}

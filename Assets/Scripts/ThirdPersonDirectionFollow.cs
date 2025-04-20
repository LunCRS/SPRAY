using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonDirectionFollow : MonoBehaviour
{
    Camera mainCamera;
    [SerializeField] private float turnSpeed;
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        float camRotation = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp( transform.rotation,Quaternion.Euler( 0,camRotation,0 ),turnSpeed * Time.deltaTime );
    }
}

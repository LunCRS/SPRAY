using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjustment : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private float originalCameraDistance = 7f;
    [SerializeField] private float cameraDistance = 20f;
    [SerializeField] private float originalCameraOffset = 2f;
    [SerializeField] private float cameraOffset = 7f;
    private float deltaDistance;
    private float deltaOffset;
    [SerializeField] private float cameraAdjustTime = 2f;
    private float adjustTimer = 0f;
    private float disAdjustSpeed;
    private float offsetAdjustSpeed;
    private bool change = false;

    private void Start ()
    {
        deltaDistance = cameraDistance - originalCameraDistance;
        deltaOffset = cameraOffset - originalCameraOffset;

        disAdjustSpeed = deltaDistance / cameraAdjustTime;
        offsetAdjustSpeed = deltaOffset / cameraAdjustTime;
    }

    private void Update ()
    {
        if(change && adjustTimer <= cameraAdjustTime)
        {
            SetCameraDistance(disAdjustSpeed * Time.deltaTime);
            SetYShoulderOffset(offsetAdjustSpeed * Time.deltaTime);
            adjustTimer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter ( Collider other )
    {
        if( other.CompareTag( "Player" ) )
        {
            PlayerControl player = other.GetComponent<PlayerControl>();
            if( player != null )
            {
                change = true;
            }
            
        }
    }


    public void SetCameraDistance ( float distance )
    {
        if( virtualCamera != null )
        {
            var thirdPerson = virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
            if( thirdPerson != null )
            {
                thirdPerson.CameraDistance = distance + thirdPerson.CameraDistance;
            }
        }
    }

    public void SetYShoulderOffset ( float yOffset )
    {
        if( virtualCamera != null )
        {
            var thirdPerson = virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
            if( thirdPerson != null )
            {
                thirdPerson.ShoulderOffset.y += yOffset;
            }
        }
    }
}

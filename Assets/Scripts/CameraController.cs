using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using static UnityEngine.InputSystem.Controls.AxisControl;

public class CameraController : MonoBehaviour
{
    [Header( "Camera references" )]
    public Camera leftCam;
    public Camera rightCam;

    [Header( "Cinemachine virtual cameras" )]
    public CinemachineVirtualCamera leftVcam;
    public CinemachineVirtualCamera rightVcam;
    private CinemachineBrain leftBrain;
    private CinemachineBrain rightBrain;

    [Header( "Viewport Settings" )]
    public Rect leftCameraViewport = new Rect( 0,0,0.5f,1 );
    public Rect rightCameraViewport = new Rect( 0.5f,0,0.5f,1 );


    private VirtualCameraToCamera _driver1;
    private VirtualCameraToCamera _driver2;


    void Start()
    {
        CameraInitialize();
        // 为每个虚拟相机创建驱动
        _driver1 = gameObject.AddComponent<VirtualCameraToCamera>();
        _driver1.vcam = leftVcam;
        _driver1.targetCamera = leftCam;

        _driver2 = gameObject.AddComponent<VirtualCameraToCamera>();
        _driver2.vcam = rightVcam;
        _driver2.targetCamera = rightCam;

    }

    private void CameraInitialize ()
    {
        leftCam.rect = leftCameraViewport;
        rightCam.rect = rightCameraViewport;

        //leftBrain = leftCam.GetComponent<CinemachineBrain>();
        //rightBrain = rightCam.GetComponent<CinemachineBrain>();

        leftVcam.Priority = 10;
        rightVcam.Priority = 10;
    }

    void LateUpdate ()
    {
        leftCam.transform.position = leftVcam.transform.position;
        leftCam.transform.rotation = leftVcam.transform.rotation;

        rightCam.transform.position = rightVcam.transform.position;
        rightCam.transform.rotation = rightVcam.transform.rotation;
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCamera : MonoBehaviour
{
    private GameObject mainCamera;
    [Header("Cinemachine")]
    [Tooltip("Follow target")]
    public GameObject cameraTarget;

    [Tooltip("Maximum angle of rotate up")]
    public float topClamp = 70.0f;

    [Tooltip("Maximum angle of rotate down")]
    public float bottomClamp = -30.0f;

    private const float threshold = 0.01f;
    private float cinemachineTargetYaw;
    private float cinemachineTargetPitch;
    public bool invertYAxis = false;
    public float sensitivity = 1f;

    private void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }

        cinemachineTargetYaw = cameraTarget.transform.rotation.eulerAngles.y;
    }
    private void Update()
    {
        if (look.sqrMagnitude >= threshold)
        {
            if (!invertYAxis)
            {
                cinemachineTargetYaw += sensitivity * look.x;
                cinemachineTargetPitch += sensitivity * look.y;
            }
            if (invertYAxis)
            {
                cinemachineTargetYaw += sensitivity * look.x;
                cinemachineTargetPitch -= sensitivity * look.y;
            }

        }

        cinemachineTargetYaw = ClampAngle(cinemachineTargetYaw, float.MinValue, float.MaxValue);
        cinemachineTargetPitch = ClampAngle(cinemachineTargetPitch, bottomClamp, topClamp);

        cameraTarget.transform.rotation = Quaternion.Euler(-cinemachineTargetPitch, cinemachineTargetYaw, 0.0f);
    }

    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f)
            lfAngle += 360f;
        if (lfAngle > 360f)
            lfAngle -= 360f;

        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }

    private Vector2 look;
    public void OnLook(InputValue value)
    {
        look = value.Get<Vector2>();
    }

    public void setsensitivity(float value)
    {
        sensitivity = value;

    }
}

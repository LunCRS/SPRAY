using System;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyController : MonoBehaviour
{
    public Transform cameraTransform; // The camera transform
    public GameObject playerBody; 
    public float angleThreshold = 45f; // The angle threshold for transparency
    public string transparencyLayerName; // The name of the transparency layer


    void Start()
    {

    }

    void Update()
    {
        // Calculate the angle between the camera's forward direction and the up direction
        float angle = Vector3.Angle(cameraTransform.forward, Vector3.up);

        // Check if the angle is less than the threshold
        if (angle < angleThreshold)
        {
            // Set the layer of playerBody
            playerBody.layer = LayerMask.NameToLayer(transparencyLayerName);

        }
        else
        {
            // Reset the layer of playerBody
            playerBody.layer = LayerMask.NameToLayer("Default");
        }
    }

}
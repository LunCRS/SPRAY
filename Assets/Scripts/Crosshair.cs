using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform player;
    [SerializeField] private Transform cam;
    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] private RectTransform crosshair;
    [SerializeField] private Vector2 screenEdgeOffset;
    [SerializeField] private float moveScale = 5.0f;

    void Start ()
    {
        StartCoroutine( LateStart( 1.0f ) );
    }

    void Update ()
    {
        UpdateCrosshairPosition();


        Vector3 currentOffset = player.InverseTransformDirection( cam.position - player.position ) - cameraOffset;
        
        crosshair.anchoredPosition = new Vector2( currentOffset.x,currentOffset.y ) * moveScale + crosshair.anchoredPosition;
    }

    void UpdateCrosshairPosition ()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        Vector2 viewportPos = screenEdgeOffset;

        Vector2 screenPos = new Vector2(viewportPos.x * screenWidth - screenWidth / 2,viewportPos.y * screenHeight - screenHeight / 2);

        crosshair.anchoredPosition = screenPos;
    }

    public IEnumerator LateStart ( float _seconds )
    {

        yield return new WaitForSeconds( _seconds );

        UpdateCrosshairPosition();

        cameraOffset = cam.position - player.position;
        cameraOffset = player.InverseTransformDirection( cameraOffset );
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private RectTransform crosshair;
    [SerializeField] private Vector2 screenEdgeOffset;

    void Start ()
    {
        UpdateCrosshairPosition();
    }

    void Update ()
    {
        UpdateCrosshairPosition();
    }


    void UpdateCrosshairPosition ()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        Vector2 viewportPos = screenEdgeOffset;

        Vector2 screenPos = new Vector2(viewportPos.x * screenWidth - screenWidth / 2,viewportPos.y * screenHeight - screenHeight / 2);

        crosshair.anchoredPosition = screenPos;
    }
}

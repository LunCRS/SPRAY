using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeImage : MonoBehaviour
{
    [Header( "位置设置" )]
    [Tooltip( "距离顶部的百分比(0-1)" )]
    public float topMarginPercent = 0.2f;
    [Tooltip( "图片宽度占屏幕宽度百分比(0-1)" )]
    public float widthPercent = 0.8f;

    private RectTransform rectTransform;
    private Canvas canvas;

    void Start ()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        UpdatePosition();
    }

    void UpdatePosition ()
    {
        // 设置锚点为顶部居中
        rectTransform.anchorMin = new Vector2( 0.5f,1f );
        rectTransform.anchorMax = new Vector2( 0.5f,1f );

        // 计算尺寸
        float screenHeight = Screen.height;
        float screenWidth = Screen.width;

        float imageWidth = screenWidth * widthPercent;
        float imageHeight = rectTransform.rect.height * ( imageWidth / rectTransform.rect.width );

        // 应用尺寸
        rectTransform.sizeDelta = new Vector2( imageWidth,imageHeight );

        // 设置位置(从顶部向下偏移)
        float offsetY = screenHeight * topMarginPercent;
        rectTransform.anchoredPosition = new Vector2( 0,-offsetY );
    }
}

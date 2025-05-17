using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public Sprite[] themeImages;  // 四个主题图
    public string[] themeNames;   // 主题名称
    public string[] levelScenes;  // 对应的关卡场景名

    public Image themeDisplay;    // 显示主题图的Image组件
    public Text themeNameText;    // 显示主题名称的Text
    public Button enterButton;    // 进入关卡按钮

    private int currentIndex = 0; // 当前显示的主题索引

    void Start ()
    {
        // 初始化显示第一个主题
        UpdateThemeDisplay();

        // 如果只有一个主题，禁用箭头按钮
        if( themeImages.Length <= 1 )
        {
            GameObject.Find( "LeftButton" ).GetComponent<Button>().interactable = false;
            GameObject.Find( "RightButton" ).GetComponent<Button>().interactable = false;
        }
    }

    // 更新主题显示
    void UpdateThemeDisplay ()
    {
        themeDisplay.sprite = themeImages[currentIndex];

        if( themeNameText != null )
        {
            themeNameText.text = themeNames[currentIndex];
        }
    }

    // 切换到下一个主题
    public void NextTheme ()
    {
        currentIndex = ( currentIndex + 1 ) % themeImages.Length;
        UpdateThemeDisplay();
    }

    // 切换到上一个主题
    public void PreviousTheme ()
    {
        currentIndex = ( currentIndex - 1 + themeImages.Length ) % themeImages.Length;
        UpdateThemeDisplay();
    }

    // 进入当前选中的关卡
    public void EnterSelectedLevel ()
    {
        if( levelScenes.Length > currentIndex && !string.IsNullOrEmpty( levelScenes[currentIndex] ) )
        {
            SceneManager.LoadScene( levelScenes[currentIndex] );
        }
        else
        {
            Debug.LogError( "场景名称未设置或无效" );
        }
    }
}

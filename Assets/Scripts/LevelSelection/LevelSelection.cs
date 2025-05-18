using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public Sprite[] themeImages;
    public string[] themeNames;
    public string[] levelScenes;

    public Image themeDisplay;
    public Text themeNameText;
    public Button enterButton;

    private int currentIndex = 0;

    void Start ()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        UpdateThemeDisplay();

        if( themeImages.Length <= 1 )
        {
            GameObject.Find( "LeftButton" ).GetComponent<Button>().interactable = false;
            GameObject.Find( "RightButton" ).GetComponent<Button>().interactable = false;
        }
    }

    void UpdateThemeDisplay ()
    {
        themeDisplay.sprite = themeImages[currentIndex];

        if( themeNameText != null )
        {
            themeNameText.text = themeNames[currentIndex];
        }
    }

    public void NextTheme ()
    {
        currentIndex = ( currentIndex + 1 ) % themeImages.Length;
        UpdateThemeDisplay();
    }

    public void PreviousTheme ()
    {
        currentIndex = ( currentIndex - 1 + themeImages.Length ) % themeImages.Length;
        UpdateThemeDisplay();
    }

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

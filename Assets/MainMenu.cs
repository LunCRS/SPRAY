using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject mainMenuPanel; // 主菜单面板
    public GameObject settingsPanel; // 设置面板（需在 Inspector 中赋值）
    public GameObject LevelSelection;  
    public Button startButton;       // 开始按钮
    public Button settingsButton;    // 设置按钮
    public Button quitButton;        // 退出按钮
    public Button backButton1;        // 返回主菜单按钮（在 SettingsPanel 中）
    public Button backButton2;

    // private void Awake()
    // {
    //     // 确保只有一个主菜单存在
    //     int menuCount = FindObjectsOfType<MainMenu>().Length;
    //     if (menuCount > 1)
    //     {
    //         Destroy(gameObject);
    //         return;
    //     }

    //     DontDestroyOnLoad(gameObject);
    // }

    void Start()
    {
        // 初始化按钮事件
        if (startButton != null)
            startButton.onClick.AddListener(StartGame);

        if (settingsButton != null)
            settingsButton.onClick.AddListener(OpenSettings);

        if (quitButton != null)
            quitButton.onClick.AddListener(QuitGame);

        if (backButton1 != null)
            backButton1.onClick.AddListener(BackToMainMenu1);

        if (backButton2 != null)
            backButton2.onClick.AddListener( BackToMainMenu2 );

        // 显示主菜单
        SwitchPanel(mainMenuPanel, settingsPanel);
    }

    public void StartGame()
    {
        Debug.Log("Starting Game...");
        // 加载第一个场景（根据你的实际场景名修改）
        SwitchPanel( LevelSelection,mainMenuPanel ); // 或者使用具体的场景名称：SceneManager.LoadScene("GameScene");
    }

    public void OpenSettings()
    {
        Debug.Log("Opening Settings...");
        SwitchPanel(settingsPanel, mainMenuPanel);
    }

    public void BackToMainMenu1()
    {
        Debug.Log("Returning to Main Menu...");
        SwitchPanel(mainMenuPanel, settingsPanel);
    }

    public void BackToMainMenu2 ()
    {
        Debug.Log( "Returning to Main Menu..." );
        SwitchPanel( mainMenuPanel,LevelSelection );
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        // 在编辑器中停止运行
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 构建版本中退出应用
        Application.Quit();
#endif
    }
    private void SwitchPanel(GameObject activePanel, GameObject inactivePanel)
    {
        if (activePanel != null) activePanel.SetActive(true);
        if (inactivePanel != null) inactivePanel.SetActive(false);
    }
}

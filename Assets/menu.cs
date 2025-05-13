using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class menu : MonoBehaviour
{
    [Header("UI绑定")]
    public GameObject pausePanel;  // 暂停菜单面板
    public Button resumeButton;    // 继续按钮
    public GameObject Player_Left;
    public GameObject Player_Right;

    private PlayerControl playerScript1;
    private ThirdPersonDirectionFollow directionFollow1;
    private ThirdPersonCamera cameraScript1;

    private PlayerControl playerScript2;
    private ThirdPersonDirectionFollow directionFollow2;
    private ThirdPersonCamera cameraScript2;



    private bool isPaused = false;

    void Start()
    {
        // 初始隐藏暂停菜单
        pausePanel.SetActive(false);

        // 绑定按钮点击事件
        resumeButton.onClick.AddListener(TogglePause);

        playerScript1 = Player_Left.GetComponent<PlayerControl>();
        directionFollow1 = Player_Left.GetComponent<ThirdPersonDirectionFollow>();
        cameraScript1 = Player_Left.GetComponent<ThirdPersonCamera>();
        playerScript2 = Player_Right.GetComponent<PlayerControl>();
        directionFollow2 = Player_Right.GetComponent<ThirdPersonDirectionFollow>();
        cameraScript2 = Player_Right.GetComponent<ThirdPersonCamera>();

    }

    void Update()
    {
        // 监听ESC按键
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        // 控制时间流速
        Time.timeScale = isPaused ? 0 : 1;

        // 显示/隐藏菜单
        pausePanel.SetActive(isPaused);

        // 控制玩家1的脚本
        if (playerScript1 != null)
            playerScript1.enabled = !isPaused;

        if (directionFollow1 != null)
            directionFollow1.enabled = !isPaused;

        if (cameraScript1 != null)
            cameraScript1.enabled = !isPaused;

        // 控制玩家2的脚本
        if (playerScript2 != null)
            playerScript2.enabled = !isPaused;

        if (directionFollow2 != null)
            directionFollow2.enabled = !isPaused;

        if (cameraScript2 != null)
            cameraScript2.enabled = !isPaused;


        // 控制鼠标状态
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isPaused;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;


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
    private PlayerInput inputScript1;
    private PlayerInput inputScript2;

    private PlayerControl playerScript2;
    private ThirdPersonDirectionFollow directionFollow2;
    private ThirdPersonCamera cameraScript2;

    [Header("音量控制")]
    public Slider volumeSlider;
    public TextMeshProUGUI volumeText;

    private float currentVolume = 1.0f;

    private bool isPaused = false;

    [Header("控制设置")]
    public float sensitivity = 1f; // 灵敏度
    public Slider sensitivitySlider;
    public TextMeshProUGUI sensitivityText;

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
        inputScript1 = Player_Left.GetComponent<PlayerInput>();
        inputScript2 = Player_Right.GetComponent<PlayerInput>();
        volumeSlider.value = currentVolume;
        UpdateVolumeText();
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        sensitivitySlider.value = sensitivity;
        sensitivitySlider.onValueChanged.AddListener(OnSensitivityChanged);
        UpdateSemsitivityText();






    }

    void Update()
    {
        // 监听ESC按键
        // if (Input.GetKeyDown(KeyCode.Escape))
        // {
        //     TogglePause();
        // }
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

        if (inputScript1 != null)
            inputScript1.enabled = !isPaused;

        if (inputScript2 != null)
            inputScript2.enabled = !isPaused;


        // 控制鼠标状态
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isPaused;
    }

    public void ChangeVolume(float volume)
    {
        currentVolume = volume;
        AudioListener.volume = currentVolume;  // 改变全局音量
        UpdateVolumeText();
    }

    private void UpdateVolumeText()
    {
        if (volumeText != null)
            volumeText.text = "Volume: " + Mathf.Round(currentVolume * 100) + "%";
    }

    private void OnSensitivityChanged(float newValue)
    {
        sensitivity = newValue;

        if (cameraScript1 != null)
            cameraScript1.setsensitivity(sensitivity);

        // 更新玩家2的摄像机灵敏度
        if (cameraScript2 != null)
            cameraScript2.setsensitivity(sensitivity);

        UpdateSemsitivityText();
    }
    private void UpdateSemsitivityText()
    {
        if (sensitivityText != null)
            sensitivityText.text = "Sensitivity: " + sensitivity.ToString("F2");
    }
}

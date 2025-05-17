using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    void StartGame()
    {
        Debug.Log("Starting Game...");
        // 加载第一个场景（根据你的实际场景名修改）
        SceneManager.LoadScene("Level_1"); // 或者使用具体的场景名称：SceneManager.LoadScene("GameScene");
    }
}

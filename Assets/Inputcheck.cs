using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputcheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CheckJoystickConnection();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CheckJoystickConnection()
    {
        Debug.Log("开始检查手柄连接...");
        string[] joystickNames = Input.GetJoystickNames();

        if (joystickNames.Length > 0)
        {
            Debug.Log("已连接的手柄数量: " + joystickNames.Length);
            for (int i = 0; i < joystickNames.Length; i++)
            {
                Debug.Log("手柄 " + (i + 1) + ": " + joystickNames[i]);
            }
        }
        else
        {
            Debug.Log("没有检测到手柄");
        }
    }
}
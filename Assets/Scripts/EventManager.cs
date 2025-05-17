using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventManager : MonoBehaviour
{
    public menu mainMenu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (mainMenu != null)
            {
                mainMenu.TogglePause();
            }
        }
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            // 当前正在操作 UI 元素（如 Slider）
            // 可以选择不执行任何逻辑
            return;
        }
    }
}

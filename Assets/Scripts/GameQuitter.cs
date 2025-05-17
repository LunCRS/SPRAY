using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameQuitter : MonoBehaviour
{
    // 公共方法供按钮调用
    public void QuitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // 编辑器模式下停止运行
#else
        Application.Quit(); // 正式构建后退出应用
#endif
    }
}

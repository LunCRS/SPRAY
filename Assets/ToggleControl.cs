using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Toggle toggle;

    [Header("设置项")]
    public bool invertYAxis;
    public GameObject Player_Left;
    public GameObject Player_Right;
    private ThirdPersonCamera ThirdPersonCamera1;


    void Start()
    {
        // 初始化状态
        toggle.isOn = invertYAxis;

        // 添加监听
        toggle.onValueChanged.AddListener(OnToggleChanged);
        ThirdPersonCamera1 = Player_Left.GetComponent<ThirdPersonCamera>();

    }

    void OnToggleChanged(bool isOn)
    {
        invertYAxis = isOn;
        if (invertYAxis)
        {
            ThirdPersonCamera1.invertYAxis = true;

        }
        else
        {
            ThirdPersonCamera1.invertYAxis = false;

        }
    }
}
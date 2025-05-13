using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasertrigger_long : MonoBehaviour
{
    public Color requiredColor = Color.red;
    private Renderer rend;
    public bool _isActivated = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = requiredColor * 0.5f; // 暗色表示未激活
    }

    public void Activate(Color hitColor)
    {
        if (hitColor == requiredColor)
        {
            rend.material.color = requiredColor;
            _isActivated = true;
        }
        else
        {
            _isActivated = false;
            rend.material.color = requiredColor * 0.5f;
        }
    }

    public bool isActivated
    {
        get { return _isActivated; }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorblockmachine : MonoBehaviour
{
    [Header("初始设置")]
    public Color initialColor = Color.white;

    [Header("激活后设置")]
    public Color activatedColor = Color.green;

    private Renderer rend;

    void Start()
    {
        rend = GetComponentInChildren<Renderer>();

        rend.material.color = initialColor;

        if (initialColor == Color.white)
            gameObject.layer = LayerMask.NameToLayer("Default");
        else if (initialColor == Color.red)
            gameObject.layer = LayerMask.NameToLayer("Red Layer");
        else if (initialColor == Color.green)
            gameObject.layer = LayerMask.NameToLayer("Green Layer");
        else if (initialColor == Color.blue)
            gameObject.layer = LayerMask.NameToLayer("Blue Layer");
    }


    public void Activate(Color hitcolor)
    {
        rend = GetComponentInChildren<Renderer>();

        rend.material.color = hitcolor;

        if (hitcolor == Color.white)
            gameObject.layer = LayerMask.NameToLayer("Default");
        else if (hitcolor == Color.red)
            gameObject.layer = LayerMask.NameToLayer("Red Layer");
        else if (hitcolor == Color.green)
            gameObject.layer = LayerMask.NameToLayer("Green Layer");
        else if (hitcolor == Color.blue)
            gameObject.layer = LayerMask.NameToLayer("Blue Layer");
    }


}

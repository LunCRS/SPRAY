using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlock : MonoBehaviour
{
    private Renderer rend;
    public Color originColor;


    void Start()
    {
        rend = GetComponentInChildren<Renderer>();

        rend.material.color = originColor;

        if (originColor == Color.white)
            gameObject.layer = LayerMask.NameToLayer("Default");
        else if (originColor == Color.red)
            gameObject.layer = LayerMask.NameToLayer("Red Layer");
        else if (originColor == Color.green)
            gameObject.layer = LayerMask.NameToLayer("Green Layer");
        else if (originColor == Color.blue)
            gameObject.layer = LayerMask.NameToLayer("Blue Layer");
    }

    public void ChangeColor(Color color)
    {
        rend.material.color = color;
        if (color == Color.white)
            gameObject.layer = LayerMask.NameToLayer("Default");
        else if (color == Color.red)
            gameObject.layer = LayerMask.NameToLayer("Red Layer");
        else if (color == Color.green)
            gameObject.layer = LayerMask.NameToLayer("Green Layer");
        else if (color == Color.blue)
            gameObject.layer = LayerMask.NameToLayer("Blue Layer");
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlock : MonoBehaviour
{
    public Renderer rend;
    public GameObject partner;
    [SerializeField] private bool colorFixBack = false;
    public Color originColor = Color.blue;
    [SerializeField] private bool canBeChanged = true;
    [SerializeField] private float fixBackTime = 3.0f;

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

        if (!canBeChanged)
            gameObject.tag = "Untagged";
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

        if (partner != null)
        {
            ColorBlock partnerColorBlock = partner.GetComponent<ColorBlock>();
            if (partnerColorBlock != null)
            {
                partnerColorBlock.rend.material.color = color;
                if (color == Color.white)
                    partner.layer = LayerMask.NameToLayer("Default");
                else if (color == Color.red)
                    partner.layer = LayerMask.NameToLayer("Red Layer");
                else if (color == Color.green)
                    partner.layer = LayerMask.NameToLayer("Green Layer");
                else if (color == Color.blue)
                    partner.layer = LayerMask.NameToLayer("Blue Layer");
            }
        }

        if (colorFixBack)
        {
            ColorFix colorFix = GetComponent<ColorFix>();
            if (colorFix != null)
            {
                StartCoroutine(colorFix.Fix(fixBackTime, originColor));
            }
        }

    }


}

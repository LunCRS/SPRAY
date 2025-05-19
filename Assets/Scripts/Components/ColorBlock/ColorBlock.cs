using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlock : MonoBehaviour
{
    public Renderer rend;
    public GameObject partner;
    public Color originColor = Color.blue;
    public bool colorFixBack = false;
    public bool canBeChanged = true;
    [SerializeField] private float fixBackTime = 3.0f;
    private Material[] mats;

    void Start()
    {
        rend = GetComponentInChildren<Renderer>();
        mats = rend.materials;

        if( !canBeChanged && (originColor == Color.red || originColor == Color.blue))
            rend.material = mats[1];

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

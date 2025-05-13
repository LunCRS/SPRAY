using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class ColorFix : MonoBehaviour
{
    [SerializeField] private GameObject fixObj;

    public IEnumerator Fix ( float _seconds,Color color )
    {

        yield return new WaitForSeconds( _seconds );

        ColorBlock colorBlock = fixObj.GetComponent<ColorBlock>();
        if( colorBlock != null )
        {
            colorBlock.rend.material.color = color;
            if( color == Color.white )
                fixObj.layer = LayerMask.NameToLayer( "Default" );
            else if( color == Color.red )
                fixObj.layer = LayerMask.NameToLayer( "Red Layer" );
            else if( color == Color.green )
                fixObj.layer = LayerMask.NameToLayer( "Green Layer" );
            else if( color == Color.blue )
                fixObj.layer = LayerMask.NameToLayer( "Blue Layer" );

            if(colorBlock.partner != null)
            {
                ColorBlock partnerColorBlock = colorBlock.partner.GetComponent<ColorBlock>();
                if( partnerColorBlock != null )
                {
                    partnerColorBlock.rend.material.color = color;
                    if( color == Color.white )
                        colorBlock.partner.layer = LayerMask.NameToLayer( "Default" );
                    else if( color == Color.red )
                        colorBlock.partner.layer = LayerMask.NameToLayer( "Red Layer" );
                    else if( color == Color.green )
                        colorBlock.partner.layer = LayerMask.NameToLayer( "Green Layer" );
                    else if( color == Color.blue )
                        colorBlock.partner.layer = LayerMask.NameToLayer( "Blue Layer" );
                }
            }
        }
    }
}

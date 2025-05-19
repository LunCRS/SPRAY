using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMazeControl : MonoBehaviour
{
    [SerializeField] private GameObject[] colorBlocks;
    [SerializeField] private Color color;

    private void OnTriggerEnter ( Collider other )
    {
        if( other.CompareTag( "Player" ) )
        {
            PlayerControl player = GetComponent<PlayerControl>();
            if( player != null )
            {
                foreach(var colorBlock in colorBlocks)
                {
                    ColorBlock block = colorBlock.GetComponent<ColorBlock>();
                    if( block != null )
                    {
                        block.colorFixBack = false;
                        block.ChangeColor( color );
                    }
                }
            }
        }
    }

}

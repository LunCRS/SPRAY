using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField] private GameObject text;
    void OnTriggerEnter ( Collider other )
    {
        if( other.CompareTag( "Player" ) )
        {
            PlayerControl player = other.GetComponentInParent<PlayerControl>();
            if( player != null )
            {
                text.SetActive( true );
            }
        }
        
    }
}

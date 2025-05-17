using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchZone_Level_2 : MonoBehaviour
{
    public PlayerControl Player_Left;
    public PlayerControl Player_Right;
    public FireWall FireWall;
    [SerializeField] private Transform BirthPlace_Left; 
    [SerializeField] private Transform BirthPlace_Right;
    [SerializeField] private Transform BirthPlace_FireWall;
    void OnTriggerEnter ( Collider other )
    {
        if( other.CompareTag( "Player" ) )
        {
            Player_Left.birthPlace = BirthPlace_Left;
            Player_Right.birthPlace = BirthPlace_Right;
            FireWall.birthPlace = BirthPlace_FireWall;
        }
    }
}

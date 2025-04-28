using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    private Renderer rend;

    [Tooltip("0 means the stage changes the color of bullet / 1 means the stage changes the color of player. ")]
    public int stageType;
    [SerializeField] private Color selfColor;
    

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = selfColor;
    }

    void Update()
    {
        
    }

    void OnTriggerEnter ( Collider other )
    {
        if( other.CompareTag( "Player" ) )
        {
            if( stageType == 0 )
            {
                other.GetComponentInParent<PlayerControl>().SetBulletColor( selfColor );
            }
            else if(stageType == 1)
            {
                other.GetComponentInParent<PlayerControl>().SetPlayerColor( selfColor );
            }
        }
    }
}

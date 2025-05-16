using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorStage : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private Color color;
    private TwoStages twoStages;
    private Renderer rend;


    void Start()
    {
        twoStages = wall.GetComponent<TwoStages>();
        rend = GetComponent<Renderer>();

        rend.material.color = color;
    }

    private void OnTriggerEnter ( Collider other )
    {
        if( other.CompareTag( "Player" ) )
        {
            PlayerControl player = other.GetComponent<PlayerControl>();
            if( player != null )
            {
                if( player.playerID == 1 )
                    twoStages.red = true;
                else
                    twoStages.blue = true;
            }
        }
    }

}

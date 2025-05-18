using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorStage : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private Color color;
    [SerializeField] private GameObject onModel, offModel;
    [SerializeField] private int playerID;
    private TwoStages twoStages;
    private Renderer rend;
    private bool active;


    void Start()
    {
        twoStages = wall.GetComponent<TwoStages>();
        rend = GetComponent<Renderer>();

        rend.material.color = color;
        onModel.SetActive( false );
        offModel.SetActive( true );
    }

    private void Update ()
    {
        
    }

    private void OnTriggerEnter ( Collider other )
    {
        if( other.CompareTag( "Player" ) )
        {

            PlayerControl player = other.GetComponent<PlayerControl>();
            if( player != null )
            {
                if(player.playerID == playerID)
                {
                    onModel.SetActive ( true );
                    offModel.SetActive( false );
                }
                if( player.playerID == 1 )
                    twoStages.red = true;
                else
                    twoStages.blue = true;
            }
        }
    }

    private void OnTriggerExit ( Collider other )
    {
        if( other.CompareTag( "Player" ) )
        {
            PlayerControl player = other.GetComponent<PlayerControl>();
            if( player != null )
            {
                if( player.playerID == playerID )
                {
                    onModel.SetActive( false );
                    offModel.SetActive( true );
                }
                if( player.playerID == 1 )
                    twoStages.red = false;
                else
                    twoStages.blue = false;
            }
        }
    }

}

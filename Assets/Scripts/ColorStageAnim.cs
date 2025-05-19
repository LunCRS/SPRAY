using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorStageAnim : MonoBehaviour
{
    [SerializeField] private GameObject offModel, onModel;

    private AudioSource audioSource;
    [SerializeField] private AudioClip onAudio, offAudio;
    [SerializeField] private int targetID;

    private void Start ()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter ( Collider other )
    {
        if( other.CompareTag( "Player" ) )
        {
            PlayerControl player = other.GetComponent<PlayerControl>();
            if(player.playerID ==  targetID )
            {
                audioSource.clip = onAudio;
                audioSource.Play();
                offModel.SetActive( false );
                onModel.SetActive( true );
                onModel.SetActive( true );
            }
        }
    }

    private void OnTriggerExit ( Collider other )
    {
        if( other.CompareTag( "Player" ))
        {
            PlayerControl player = other.GetComponent<PlayerControl>();
            if(player.playerID == targetID )
            {
                audioSource.clip = offAudio;
                audioSource.Play();
                offModel.SetActive( true );
                onModel.SetActive( false );
            }
        }
    }
}

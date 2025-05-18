using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageAnimAudio : MonoBehaviour
{
    [SerializeField] private bool activeOnce = false;
    [SerializeField] private GameObject offModel, onModel;

    private AudioSource audioSource;
    [SerializeField] private AudioClip onAudio, offAudio;

    private void Start ()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter ( Collider other )
    {
        if( other.CompareTag( "Player" ) )
        {
            audioSource.clip = onAudio;
            audioSource.Play();
            offModel.SetActive( false );
            onModel.SetActive( true );
        }
    }

    private void OnTriggerExit ( Collider other )
    {
        if( other.CompareTag( "Player" ) && !activeOnce)
        {
            audioSource.clip = offAudio;
            audioSource.Play();
            offModel.SetActive( true );
            onModel.SetActive( false );
        }
    }


}

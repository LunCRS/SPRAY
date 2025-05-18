using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip bulletHitSound;
    [SerializeField] private AudioClip[] audioClips;

    void Start()
    {
        bulletHitSound = audioClips[UnityEngine.Random.Range( 0,audioClips.Length )];
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = bulletHitSound;
        audioSource.Play();
        Destroy( gameObject,bulletHitSound.length );
    }
}

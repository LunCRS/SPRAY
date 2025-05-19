using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip sound;

    void Start ()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = sound;
        audioSource.Play();
        Destroy( gameObject,sound.length );
    }
}

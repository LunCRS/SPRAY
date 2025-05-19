using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private float rotSpeed = 60f;
    [SerializeField] private GameObject mazeManager;
    [SerializeField] private GameObject audioPlayer;
    private AudioSource audioSource;
    private MazeManager manager;
    void Start()
    {
        manager = mazeManager.GetComponent<MazeManager>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Rotate( Vector3.up * rotSpeed * Time.deltaTime,Space.World );
    }

    private void OnTriggerEnter ( Collider other )
    {
        if( other.CompareTag( "Player" ) )
        {
            GameObject audio = Instantiate( audioPlayer,transform.position,Quaternion.identity );
            gameObject.SetActive( false );
            manager.GetKey();
            
        }
    }
}

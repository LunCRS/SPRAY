using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private float rotSpeed = 60f;
    [SerializeField] private GameObject mazeManager;
    private MazeManager manager;
    void Start()
    {
        manager = mazeManager.GetComponent<MazeManager>();
    }

    void Update()
    {
        transform.Rotate( Vector3.up * rotSpeed * Time.deltaTime,Space.World );
    }

    private void OnTriggerEnter ( Collider other )
    {
        if( other.CompareTag( "Player" ) )
        {
            gameObject.SetActive( false );
            manager.CheckKeys();
        }
    }
}

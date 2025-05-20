using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWall : MonoBehaviour
{
    [SerializeField] private float speed = 0.05f;
    [SerializeField] private GameObject cam;
    [SerializeField] private Transform startPos;
    [SerializeField] private Transform end;
    [SerializeField] private GameObject fireWall;
    private bool camMove = false;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3( transform.position.x,transform.position.y,transform.position.z + speed );

        if(transform.position.z > startPos.position.z )
        {
            camMove = true;
        }

        if(camMove)
        {
            cam.transform.position = new Vector3( cam.transform.position.x,cam.transform.position.y,cam.transform.position.z + speed );
        }

        if(transform.position.z > end.position.z )
        {
            fireWall.SetActive( true );
            cam.SetActive(false);
            speed = 0;
        }
    }

    


}

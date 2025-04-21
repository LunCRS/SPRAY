using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private GameObject mainCamera;

    [SerializeField] private Color bulletColor = Color.red;

    void Start()
    {
        if(mainCamera == null)
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }
    }

    void Update()
    {
        
    }

    void OnFire(InputValue value)
    {
        Transform transform = GetComponent<Transform>();
        CreateBullet( transform );

    }

    private void CreateBullet ( Transform transform )
    {
        GameObject bullet = Instantiate( prefabBullet,transform.position,mainCamera.transform.rotation );
        if( bulletColor == Color.white )
            bullet.layer = LayerMask.NameToLayer( "Default" );
        else if( bulletColor == Color.red )
            bullet.layer = LayerMask.NameToLayer( "Red Layer" );
        else if(bulletColor == Color.green)
            bullet.layer = LayerMask.NameToLayer( "Green Layer" );
        else if( bulletColor == Color.blue )
            bullet.layer = LayerMask.NameToLayer( "Blue Layer" );
    }
}

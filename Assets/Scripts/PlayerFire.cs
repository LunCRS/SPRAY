using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{
    public GameObject prefabBullet;
    public GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        if(mainCamera == null)
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnFire(InputValue value)
    {
        Transform transform = GetComponent<Transform>();
        GameObject bullet_ = Instantiate(prefabBullet, transform.position, mainCamera.transform.rotation);
        //Debug.Log(bullet_.transform.position);
        //Debug.Log(bullet_.transform.rotation);
        Debug.Log("Fire!");
    }
}

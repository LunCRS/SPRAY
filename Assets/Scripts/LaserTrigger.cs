using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrigger : MonoBehaviour
{
    // Start is called before the first frame update public GameObject targetObject; 
    public Material activatedMaterial; //

    private Material originalMaterial;
    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        originalMaterial = renderer.material;
    }

    public void Activate()
    {
        // 
        // if (targetObject != null) {
        //     targetObject.SetActive(false); // 
        //
        // }

        // 
        if (activatedMaterial != null)
        {
            renderer.material = activatedMaterial;
        }
    }
}

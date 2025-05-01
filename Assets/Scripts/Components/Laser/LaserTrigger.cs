using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrigger : MonoBehaviour
{
    [SerializeField] private Material originalMaterial;
    [SerializeField] private Material activatedMaterial;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalMaterial = rend.material;
    }

    public void Activate()
    {
        if (activatedMaterial != null)
        {
            rend.material = activatedMaterial;
        }
    }
}

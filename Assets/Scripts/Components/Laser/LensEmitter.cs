using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensEmitter : MonoBehaviour
{

    public float maxDistance = 20f;
    public LayerMask combinedLayers;
    public LineRenderer lineRenderer;
    public ParticleSystem hitEffect;
    public Color defaultColor = Color.red;
    [SerializeField] private bool ishit_lens = false;
    public bool isMainHit = false;
    private Renderer objectRenderer;
    public Color currentColor;

    public bool GetIsHitLen()
    {
        return ishit_lens;
    }

    public void SetIsHitLen(bool isHit)
    {
        ishit_lens = isHit;
    }

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }
    void Update()
    {

        RaycastHit mainHit;
        isMainHit = Physics.Raycast(
            transform.position,
            transform.forward,
            out mainHit,
            maxDistance,
            combinedLayers
        );

        UpdateBaseLaser(isMainHit, mainHit);



        HandleTriggerAndEffects(isMainHit, mainHit);
    }

    void UpdateBaseLaser(bool isHit, RaycastHit hit)
    {


        if (ishit_lens)
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, isHit ? hit.point : transform.position + transform.forward * maxDistance);

        }

        if (!ishit_lens)
        {
            lineRenderer.positionCount = 0;
        }

        currentColor = objectRenderer.material.color;
        lineRenderer.startColor = currentColor;
        lineRenderer.endColor = currentColor;
    }

    void HandleTriggerAndEffects(bool isHit, RaycastHit hit)
    {
        if (ishit_lens && isHit && hit.collider.CompareTag("LaserTrigger"))
        {
            hit.collider.GetComponent<LaserTrigger>().Activate();
        }

        if (ishit_lens && isHit && hit.collider.CompareTag("lens"))
        {
            hit.collider.GetComponent<LensEmitter>().SetIsHitLen(true);
        }
        if (ishit_lens && isHit && hit.collider.CompareTag("mirror"))
        {
            Vector3 reflectionDirection = Vector3.Reflect(transform.forward, hit.normal);
            hit.collider.GetComponent<MirrorEmitter>().SetIsHitMirror(true);
            hit.collider.GetComponent<MirrorEmitter>().reflection = reflectionDirection;
            hit.collider.GetComponent<MirrorEmitter>().currentColor = defaultColor;
            hit.collider.GetComponent<MirrorEmitter>().reflectionhitPoint = hit.point;

        }


        if (hitEffect != null)
        {
            if (isHit)
            {
                hitEffect.transform.position = hit.point;
                if (!hitEffect.isPlaying) hitEffect.Play();
            }
            else
            {
                if (hitEffect.isPlaying) hitEffect.Stop();
            }
        }
    }
}

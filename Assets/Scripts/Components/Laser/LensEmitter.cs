using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensEmitter : MonoBehaviour
{

    public float maxDistance = 20f;
    public LayerMask combinedLayers;
    public LineRenderer lineRenderer;
    public ParticleSystem hitEffect;
    public bool ishit = false;
    public bool isMainHit = false;
    public Renderer objectRenderer;
    public Color currentColor;
    public Color hitColor;
    public GameObject last_hitObject = null;

    public bool GetIsHitLen()
    {
        return ishit;
    }

    public void SetIsHitLen(bool isHit)
    {
        ishit = isHit;
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


        if (ishit)
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, isHit ? hit.point : transform.position + transform.forward * maxDistance);

        }

        if (!ishit)
        {
            lineRenderer.positionCount = 0;
        }
        currentColor = objectRenderer.material.color;
        if (currentColor == Color.white)
        {
            lineRenderer.startColor = hitColor;
            lineRenderer.endColor = hitColor;
        }
        else
        {
            lineRenderer.startColor = currentColor;
            lineRenderer.endColor = currentColor;
        }

    }

    void HandleTriggerAndEffects(bool isHit, RaycastHit hit)
    {
        if (ishit && isHit && hit.collider.CompareTag("LaserTrigger"))
        {
            hit.collider.GetComponent<LaserTrigger>().Activate(currentColor);
            if (currentColor == Color.white)
                hit.collider.GetComponent<LaserTrigger>().hitcolor = hitColor;
            else
                hit.collider.GetComponent<LaserTrigger>().hitcolor = currentColor;
            last_hitObject = hit.collider.gameObject;
        }

        if (ishit && isHit && hit.collider.CompareTag("lens"))
        {
            hit.collider.GetComponent<LensEmitter>().SetIsHitLen(true);
            if (currentColor == Color.white)
                hit.collider.GetComponent<LensEmitter>().hitColor = hitColor;
            else
                hit.collider.GetComponent<LensEmitter>().hitColor = currentColor;
            last_hitObject = hit.collider.gameObject;
        }
        if (ishit && isHit && hit.collider.CompareTag("mirror"))
        {
            Vector3 reflectionDirection = Vector3.Reflect(transform.forward, hit.normal);
            hit.collider.GetComponent<MirrorEmitter>().SetIsHitMirror(true);
            hit.collider.GetComponent<MirrorEmitter>().reflection = reflectionDirection;
            if (currentColor == Color.white)
                hit.collider.GetComponent<MirrorEmitter>().currentColor = hitColor;
            else
                hit.collider.GetComponent<MirrorEmitter>().currentColor = currentColor;

            hit.collider.GetComponent<MirrorEmitter>().reflectionhitPoint = hit.point;
            last_hitObject = hit.collider.gameObject;

        }
        if (ishit && isHit && hit.collider.CompareTag("trigger_long"))
        {
            if (currentColor == Color.white)
                hit.collider.GetComponent<lasertrigger_long>().Activate(hitColor);
            else
                hit.collider.GetComponent<lasertrigger_long>().Activate(currentColor);

            last_hitObject = hit.collider.gameObject;
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

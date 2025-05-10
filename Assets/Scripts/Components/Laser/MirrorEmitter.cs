using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorEmitter : MonoBehaviour
{

    public float maxDistance = 20f;
    public LayerMask combinedLayers;
    public LineRenderer lineRenderer;
    public ParticleSystem hitEffect;
    public Color defaultColor = Color.red;
    public bool ishit_mirror = false;
    public bool isMainHit = false;
    private Renderer objectRenderer;
    public Vector3 reflection;
    public Color currentColor;
    public Vector3 reflectionhitPoint;

    public bool GetIsHitMirror()
    {
        return ishit_mirror;
    }

    public void SetIsHitMirror(bool isHit)
    {
        ishit_mirror = isHit;
    }


    void Start()
    {
        currentColor = defaultColor;
    }
    void Update()
    {

        RaycastHit mainHit;
        isMainHit = Physics.Raycast(
            reflectionhitPoint,
            reflection,
            out mainHit,
            maxDistance,
            combinedLayers
        );

        UpdateBaseLaser_mirror(isMainHit, mainHit);



        HandleTriggerAndEffects_mirror(isMainHit, mainHit);
    }

    void UpdateBaseLaser_mirror(bool isHit, RaycastHit hit)
    {
        if (ishit_mirror)
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, reflectionhitPoint);
            lineRenderer.SetPosition(1, isHit ? hit.point : transform.position + reflection * maxDistance);

        }

        if (!ishit_mirror)
        {
            lineRenderer.positionCount = 0;
        }
        // 设置基础颜色
        lineRenderer.startColor = currentColor;
        lineRenderer.endColor = currentColor;
    }

    void HandleTriggerAndEffects_mirror(bool isHit, RaycastHit hit)
    {
        if (ishit_mirror && isHit && hit.collider.CompareTag("LaserTrigger"))
        {
            hit.collider.GetComponent<LaserTrigger>().Activate();
        }

        if (ishit_mirror && isHit && hit.collider.CompareTag("lens"))
        {
            hit.collider.GetComponent<LensEmitter>().SetIsHitLen(true);
        }
        if (ishit_mirror && isHit && hit.collider.CompareTag("mirror"))
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

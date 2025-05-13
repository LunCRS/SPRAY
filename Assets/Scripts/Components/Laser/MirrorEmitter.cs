using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorEmitter : MonoBehaviour
{

    public float maxDistance = 20f;
    public LayerMask combinedLayers;
    public LineRenderer lineRenderer;
    public ParticleSystem hitEffect;
    public Color defaultColor;
    public bool ishit = false;
    public bool isMainHit = false;
    private Renderer objectRenderer;
    public Vector3 reflection;
    public Color currentColor;
    public Vector3 reflectionhitPoint;
    public GameObject last_hitobject;

    public bool GetIsHitMirror()
    {
        return ishit;
    }

    public void SetIsHitMirror(bool isHit)
    {
        ishit = isHit;
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
        if (ishit)
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, reflectionhitPoint);
            lineRenderer.SetPosition(1, isHit ? hit.point : transform.position + reflection * maxDistance);

        }

        if (!ishit)
        {
            lineRenderer.positionCount = 0;
        }
        // 设置基础颜色
        lineRenderer.startColor = currentColor;
        lineRenderer.endColor = currentColor;
    }

    void HandleTriggerAndEffects_mirror(bool isHit, RaycastHit hit)
    {
        if (ishit && isHit && hit.collider.CompareTag("LaserTrigger"))
        {
            hit.collider.GetComponent<LaserTrigger>().Activate(currentColor);
            hit.collider.GetComponent<LaserTrigger>().hitcolor = currentColor;
            last_hitobject = hit.collider.gameObject;
        }

        if (ishit && isHit && hit.collider.CompareTag("lens"))
        {
            hit.collider.GetComponent<LensEmitter>().SetIsHitLen(true);
            hit.collider.GetComponent<LensEmitter>().hitColor = currentColor;
            last_hitobject = hit.collider.gameObject;
        }
        if (ishit && isHit && hit.collider.CompareTag("mirror"))
        {
            Vector3 reflectionDirection = Vector3.Reflect(transform.forward, hit.normal);
            hit.collider.GetComponent<MirrorEmitter>().SetIsHitMirror(true);
            hit.collider.GetComponent<MirrorEmitter>().reflection = reflectionDirection;
            hit.collider.GetComponent<MirrorEmitter>().currentColor = currentColor;
            hit.collider.GetComponent<MirrorEmitter>().reflectionhitPoint = hit.point;
            last_hitobject = hit.collider.gameObject;

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

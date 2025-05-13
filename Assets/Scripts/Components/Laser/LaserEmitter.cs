using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LaserEmitter : MonoBehaviour
{
    public float maxDistance = 10f;
    public LayerMask combinedLayers;
    public LineRenderer lineRenderer;
    public ParticleSystem hitEffect;
    public Color defaultColor = Color.red;
    void Update()
    {
        // ResetHit_lens();
        // ResetHit_mirror();
        // 主射线检测（同时检测触发器和透镜）
        RaycastHit mainHit;
        bool isMainHit = Physics.Raycast(
            transform.position,
            transform.forward,
            out mainHit,
            maxDistance,
            combinedLayers
        );


        UpdateBaseLaser(isMainHit, mainHit);



        HandleTriggerAndEffects(isMainHit, mainHit);


    }

    // void ResetHit_lens()
    // {
    //     // 获取所有带有"lens"标签的collider，并将ishit_lens设置为false
    //     Collider[] lenses = GameObject.FindGameObjectsWithTag("lens").Select(go => go.GetComponent<Collider>()).ToArray();
    //     foreach (var lens in lenses)
    //     {
    //         lens.GetComponent<lens>().SetIsHitLen(false);
    //     }
    // }
    // void ResetHit_mirror()
    // {
    //     // 获取所有带有"mirror"标签的collider，并将ishit_mirror设置为false
    //     Collider[] mirrors = GameObject.FindGameObjectsWithTag("mirror").Select(go => go.GetComponent<Collider>()).ToArray();
    //     foreach (var mirror in mirrors)
    //     {
    //         mirror.GetComponent<mirror>().SetIsHitMirror(false);
    //     }
    // }
    void UpdateBaseLaser(bool isHit, RaycastHit hit)
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, isHit ? hit.point : transform.position + transform.forward * maxDistance);

        // 设置基础颜色
        lineRenderer.startColor = defaultColor;
        lineRenderer.endColor = defaultColor;
    }


    void HandleTriggerAndEffects(bool isHit, RaycastHit hit)
    {
        if (isHit && hit.collider.CompareTag("LaserTrigger"))
        {
            hit.collider.GetComponent<LaserTrigger>().Activate(defaultColor);
            hit.collider.GetComponent<LaserTrigger>().hitcolor = defaultColor;
        }

        if (isHit && hit.collider.CompareTag("lens"))
        {
            hit.collider.GetComponent<LensEmitter>().SetIsHitLen(true);
            hit.collider.GetComponent<LensEmitter>().hitColor = defaultColor;
        }
        if (isHit && hit.collider.CompareTag("mirror"))
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EmitterController : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetHit_lens()
    {
        Debug.Log("[EmitterController] lens reset");
        Collider[] lenses = GameObject.FindGameObjectsWithTag("lens")
            .Select(go => go.GetComponent<Collider>()).ToArray();

        foreach (var lens in lenses)
        {
            if (lens == null) continue;

            LensEmitter emitter = lens.GetComponent<LensEmitter>();
            if (emitter != null)
            {
                emitter.SetIsHitLen(false);
            }
            else
            {
                Debug.LogWarning($"[EmitterController] 找到 tag=lens 的物体 {lens.name}，但上面没有 LensEmitter 组件");
            }
        }
    }
    public void ResetHit_mirror()
    {
        Collider[] mirrors = GameObject.FindGameObjectsWithTag("mirror")
            .Select(go => go.GetComponent<Collider>()).ToArray();

        foreach (var mirror in mirrors)
        {
            if (mirror == null) continue;

            MirrorEmitter emitter = mirror.GetComponent<MirrorEmitter>();
            if (emitter != null)
            {
                emitter.SetIsHitMirror(false);
            }
            else
            {
                Debug.LogWarning($"[EmitterController] 找到 tag=mirror 的物体 {mirror.name}，但上面没有 MirrorEmitter 组件");
            }
        }
    }
    public void ResetHit_trigger()
    {
        Collider[] triggers = GameObject.FindGameObjectsWithTag("LaserTrigger")
            .Select(go => go.GetComponent<Collider>()).ToArray();

        foreach (var trigger in triggers)
        {
            if (trigger == null) continue;

            LaserTrigger emitter = trigger.GetComponent<LaserTrigger>();
            if (emitter != null)
            {
                emitter.ResetHitColor();
            }
            else
            {
                Debug.LogWarning($"[EmitterController] 找到 tag=trigger 的物体 {trigger.name}，但上面没有 MirrorEmitter 组件");
            }
        }
    }
}
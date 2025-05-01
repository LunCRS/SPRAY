using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EmitterController : MonoBehaviour
{
    float resetTimer = 0f;
    public float resetInterval = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        resetTimer += Time.deltaTime;
        if (resetTimer >= resetInterval)
        {
            ResetHit_lens();
            ResetHit_mirror();
            resetTimer = 0f;
        }
    }

    void ResetHit_lens()
    {
        // 获取所有带有"lens"标签的collider，并将ishit_lens设置为false
        Collider[] lenses = GameObject.FindGameObjectsWithTag("lens").Select(go => go.GetComponent<Collider>()).ToArray();
        foreach (var lens in lenses)
        {
            lens.GetComponent<lens>().SetIsHitLen(false);
        }
    }
    void ResetHit_mirror()
    {
        // 获取所有带有"mirror"标签的collider，并将ishit_mirror设置为false
        Collider[] mirrors = GameObject.FindGameObjectsWithTag("mirror").Select(go => go.GetComponent<Collider>()).ToArray();
        foreach (var mirror in mirrors)
        {
            mirror.GetComponent<mirror>().SetIsHitMirror(false);
        }
    }
}

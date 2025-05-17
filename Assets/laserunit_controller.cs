using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserunit_controller : MonoBehaviour
{
    public List<lasertrigger_long> triggerUnits = new List<lasertrigger_long>();
    public laaserreviever receiver; // 响应器对象

    [Tooltip("每个触发器需要被连续照射的时间（秒）")]
    public float requiredDuration = 2f;

    private float[] lastHitTimes;
    private bool allActive = false;
    private float resetTimer = 0f;

    void Start()
    {
        lastHitTimes = new float[triggerUnits.Count];

    }

    void Update()
    {
        resetTimer += Time.deltaTime;


        if (resetTimer >= 1f)
        {
            ResetAllTriggers();
            resetTimer = 0f;
        }
        bool allHit = true;

        for (int i = 0; i < triggerUnits.Count; i++)
        {
            if (triggerUnits[i].isActivated)
            {
                lastHitTimes[i] += Time.deltaTime;
            }
            else
            {
                lastHitTimes[i] = 0f;
                allHit = false;
            }
        }

        if (allHit && !allActive)
        {
            bool durationMet = true;
            foreach (float t in lastHitTimes)
            {
                if (t < requiredDuration)
                {
                    durationMet = false;
                    break;
                }
            }

            if (durationMet)
            {
                Debug.Log("laserunit_controller");
                allActive = true;
                receiver.Activate();
            }
        }
        else if (!allHit)
        {
            allActive = false;
        }
    }
    private void ResetAllTriggers()
    {
        for (int i = 0; i < triggerUnits.Count; i++)
        {
            triggerUnits[i]._isActivated = false;
            if (triggerUnits[i].rend != null)
            {
                triggerUnits[i].rend.material.color = triggerUnits[i].requiredColor * 0.5f;
            }
        }
    }
}


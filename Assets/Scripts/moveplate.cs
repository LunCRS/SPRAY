using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    public Vector3 direction = Vector3.forward; // 移动方向
    public float speed = 2f;                   // 移动速度
    public float maxDistance = 5f;             // 最大移动距离
    public bool isMoving = false;             // 是否正在移动
    private Vector3 startPosition;             // 起始位置
    public float currentDistance = 0f;        // 当前已移动距离
    public bool movingForward = true;         // 当前是向前还是返回
    private float lastcheckDistance = 0f;

    public List<LensEmitter> lensEmittersToReset = new List<LensEmitter>();
    public List<MirrorEmitter> mirrorEmittersToReset = new List<MirrorEmitter>();

    void Start()
    {
        startPosition = transform.position;
    }

    public void Move()
    {
        isMoving = true;
    }

    public void Stop()
    {
        isMoving = false;
    }

    void Update()
    {
        if (!isMoving) return;

        // 计算本次帧移动的距离
        float moveStep = speed * Time.deltaTime;

        if (movingForward)
        {
            // 向前移动
            transform.Translate(direction * moveStep, Space.World);
            currentDistance += moveStep;
            if (currentDistance >= maxDistance)
            {
                // 已到达最大距离，调整方向
                transform.position = startPosition + direction.normalized * maxDistance;
                movingForward = false;
            }
        }
        else
        {
            // 返回原点
            Vector3 targetPosition = startPosition;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveStep);

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                // 回到原点，可选择停止或重置继续移动
                transform.position = targetPosition;
                movingForward = true;
                currentDistance = 0f;
                lastcheckDistance = 0f;
                // isMoving = false; // 如果不想循环，取消注释这行
            }
        }
        if (currentDistance - lastcheckDistance > 0.1)
        {
            foreach (var emitter in lensEmittersToReset)
            {
                emitter?.SetIsHitLen(false);
            }

            foreach (var emitter in mirrorEmittersToReset)
            {
                emitter?.SetIsHitMirror(false);
            }

            lastcheckDistance = currentDistance;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMachine_Type2 : MonoBehaviour
{
    public Transform moveObject; // 要移动的物体，比如移动平台
    public Vector3 moveDirection = Vector3.down; // 移动方向，默认向下
    public float moveSpeed = 2f; // 移动速度
    public float maxDistance = 5f; // 最大移动距离

    private Vector3 initialPosition;
    private bool isMovingDown = false;
    private bool isReturning = false;
    public List<LensEmitter> lensEmittersToReset = new List<LensEmitter>();
    public List<MirrorEmitter> mirrorEmittersToReset = new List<MirrorEmitter>();
    private float currentDistance;
    private float lastcheckDistance;

    void Start()
    {
        if (moveObject == null)
            moveObject = transform; // 如果未指定，默认移动自身

        initialPosition = moveObject.position;
    }

    void Update()
    {
        currentDistance = Vector3.Distance(initialPosition, moveObject.position);
        if (isMovingDown)
        {

            // 向下移动，直到达到最大距离
            Vector3 targetPosition = initialPosition + moveDirection.normalized * maxDistance;
            if (Vector3.Distance(moveObject.position, targetPosition) > 0.01f)
            {
                moveObject.position = Vector3.MoveTowards(moveObject.position, targetPosition, moveSpeed * Time.deltaTime);
            }
            else
            {
                isMovingDown = false;
            }
        }
        else if (isReturning)
        {
            // 返回初始位置
            if (Vector3.Distance(moveObject.position, initialPosition) > 0.01f)
            {
                moveObject.position = Vector3.MoveTowards(moveObject.position, initialPosition, moveSpeed * Time.deltaTime);
            }
            else
            {
                isReturning = false;
            }
        }
        if (currentDistance - lastcheckDistance > 0.2f || currentDistance - lastcheckDistance < -0.2f)
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

    public void Move()
    {
        isMovingDown = true;
        isReturning = false;
    }

    public void Stop()
    {
        isReturning = true;
        isMovingDown = false;
    }
}

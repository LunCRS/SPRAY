using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_machine : MonoBehaviour
{
    public Vector3 movement;
    public float distance = 1f;
    public float speed = 0.1f; // 移动速度

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private bool movingToTarget = true; // 控制当前是去目标还是回起点

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        targetPosition = transform.position + movement * distance;
    }

    // 被外部调用以触发移动
    public void move()
    {
        isMoving = true;
        movingToTarget = true; // 默认先移动到目标
    }

    void Update()
    {
        if (!isMoving) return;

        Vector3 destination = movingToTarget ? targetPosition : startPosition;

        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        if (transform.position == destination)
        {
            if (movingToTarget)
            {
                // 到达目标后，改为返回起点状态
                movingToTarget = false;
            }
            else
            {
                // 返回起点后，停止移动
                isMoving = false;
            }
        }
    }
}
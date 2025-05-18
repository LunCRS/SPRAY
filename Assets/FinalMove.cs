using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float fallSpeedLimit = 2f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // 沿世界坐标 Z 轴正方向移动（世界“前方”）
        Vector3 worldForward = Vector3.forward;
        rb.velocity = new Vector3(0, rb.velocity.y, moveSpeed);
        if (rb.velocity.y < -fallSpeedLimit)
        {
            rb.velocity = new Vector3(rb.velocity.x, -fallSpeedLimit, moveSpeed);
        }
    }
}

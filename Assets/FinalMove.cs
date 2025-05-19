using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float fallSpeedLimit = 2f;
    public float jumpForce = 5f;
    public float jumpTriggerDistance = 10f;
    private Rigidbody rb;
    private float distanceTraveled = 0f;
    private bool hasJumped = false;
    private Transform trans;
    private PlayerControl playerControl;
    // Start is called before the first frame update
    public float movetime = 16f;
    private float movetimer = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();
        playerControl = GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        // 沿世界坐标 Z 轴正方向移动（世界“前方”）
        playerControl.enabled = false;
        trans.forward = Vector3.forward;
        Vector3 worldForward = Vector3.forward;
        movetimer += Time.deltaTime;
        if (movetimer <= movetime )
        {
            float distanceThisFrame = moveSpeed * Time.deltaTime;
            distanceTraveled += distanceThisFrame;
            rb.velocity = new Vector3( 0,rb.velocity.y,moveSpeed );
            if( rb.velocity.y < -fallSpeedLimit )
            {
                rb.velocity = new Vector3( rb.velocity.x,-fallSpeedLimit,moveSpeed );
            }
            if( distanceTraveled >= jumpTriggerDistance && !hasJumped )
            {
                rb.velocity = new Vector3( rb.velocity.x,jumpForce,moveSpeed );
                hasJumped = true;


            }
        }

    }
}

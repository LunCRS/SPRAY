using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlate : MonoBehaviour
{
    public float new_speed;
    public float new_angle_down;
    public float new_angle_top;
    private PlayerControl playerControl;
    private ThirdPersonCamera thirdPersonCamera;
    public int type;
    public GameObject ShuiLiFang;


    private void OnTriggerEnter(Collider other)
    {
        // 确保是玩家角色进入触发器
        playerControl = other.GetComponent<PlayerControl>();
        thirdPersonCamera = other.GetComponent<ThirdPersonCamera>();

        if (playerControl.hasReset) return;

        if (playerControl != null && thirdPersonCamera != null)
        {
            // 修改玩家速度
            playerControl.moveSpeed *= new_speed;

            // 修改摄像机角度（pitch）
            thirdPersonCamera.topClamp = new_angle_top;
            thirdPersonCamera.bottomClamp = new_angle_down;

            playerControl.hasReset = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerControl = other.GetComponent<PlayerControl>();
        if (playerControl.hasReset)
        {
            playerControl.hasReset = false;
        }
        if (type == 0)
            ShuiLiFang.SetActive(true);
        else if (type == 1)
            ShuiLiFang.SetActive(false);

    }
}

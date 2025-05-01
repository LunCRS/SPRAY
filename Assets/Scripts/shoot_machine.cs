using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot_machine : MonoBehaviour
{
    [SerializeField] private GameObject prefabBullet; // 子弹预制体
    private Transform firePoint; // 发射点
    [SerializeField] private Color bulletColor;

    void Start()
    {
        firePoint = transform;
    }

    void Update()
    {

    }

    public void shoot()
    {
        if (prefabBullet != null && firePoint != null)
        {
            Debug.Log("shoot");
            CreateBullet(transform);
        }
    }

    private void CreateBullet(Transform transform)
    {
        GameObject bullet = Instantiate(prefabBullet, transform.position, transform.rotation);
        SetBulletColor(GetComponent<Renderer>().material.color);
        if (bulletColor == Color.white)
            bullet.layer = LayerMask.NameToLayer("Default");
        else if (bulletColor == Color.red)
            bullet.layer = LayerMask.NameToLayer("Red Layer");
        else if (bulletColor == Color.green)
            bullet.layer = LayerMask.NameToLayer("Green Layer");
        else if (bulletColor == Color.blue)
            bullet.layer = LayerMask.NameToLayer("Blue Layer");
    }
    private void SetBulletColor(Color color)
    {
        bulletColor = color;
    }

}

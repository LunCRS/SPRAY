using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMachine : MonoBehaviour
{

    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private Color bulletColor;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float bulletSpeed = 114f;
    [SerializeField] private bool bulletGravity = true;
    [SerializeField] private bool haveStage = false;
    private float fireTimer = 0f;

    private Transform firePoint;

    void Start()
    {
        firePoint = transform;
    }

    void Update()
    {
        if(!haveStage)
            CheckForShoot();
    }

    public void CheckForShoot ()
    {
        fireTimer += Time.deltaTime;
        if( fireTimer >= 0 )
        {
            shoot();
            fireTimer = -fireRate;
        }
    }

    public void shoot()
    {
        if (prefabBullet != null && firePoint != null)
        {
            CreateBullet(transform);
        }
    }

    private void CreateBullet(Transform transform)
    {
        GameObject bullet = Instantiate(prefabBullet, transform.position, transform.rotation);

        Bullet bul = bullet.GetComponent<Bullet>();
        bul.speed = bulletSpeed;
        bul.useGravity = bulletGravity;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMachine : MonoBehaviour
{
    [SerializeField] private GameObject prefabBullet;
    private Transform firePoint; 
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

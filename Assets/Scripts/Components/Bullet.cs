using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Color selfColor;

    private Rigidbody rb;
    private Transform trans;
    private Renderer rend;

    private float lifeTimer = 0f;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed = 114f;
    [SerializeField] private float lifeTime = 5f;

    private bool isDestroyed = false;
    public int bullet_type;
    public int bullet_color;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();
        rend = GetComponentInChildren<Renderer>();

        direction = trans.forward;

        rb.velocity = new Vector3(direction.x * speed, direction.y * speed, direction.z * speed);

        SetBulletColor();
    }

    void Update()
    {
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= lifeTime)
            isDestroyed = true;

        if (isDestroyed)
            DestroyImmediate(gameObject);
    }

    private void SetBulletColor()
    {

        if (gameObject.layer == LayerMask.NameToLayer("Default"))
            selfColor = Color.white;
        else if (gameObject.layer == LayerMask.NameToLayer("Red Layer"))
            selfColor = Color.red;
        else if (gameObject.layer == LayerMask.NameToLayer("Green Layer"))
            selfColor = Color.green;
        else if (gameObject.layer == LayerMask.NameToLayer("Blue Layer"))
            selfColor = Color.blue;

        rend.material.color = selfColor;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("ColorBlock") || collider.CompareTag("lens"))
        {
            ColorBlock colorBlock = collider.GetComponent<ColorBlock>();
            if (colorBlock != null)
            {
                colorBlock.ChangeColor(selfColor);
                isDestroyed = true;
            }
        }
        else if(collider.CompareTag("Ground"))
            isDestroyed = true;

    }
}
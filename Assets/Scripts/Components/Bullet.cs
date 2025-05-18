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

    [Header("Setting info")]
    private float lifeTimer = 0f;
    public Vector3 bulletDirection;
    public float speed = 114f;
    public bool useGravity = true;
    public float lifeTime = 5f;

    [Header("Audio info")]
    [SerializeField] private GameObject audioPlayer;

    private bool isDestroyed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();
        rend = GetComponentInChildren<Renderer>();
        
        

        bulletDirection = trans.forward;

        rb.velocity = new Vector3(bulletDirection.x * speed, bulletDirection.y * speed, bulletDirection.z * speed);

        SetBulletColor();

        rb.useGravity = useGravity;
    }

    void Update()
    {
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= lifeTime)
            isDestroyed = true;

        if (isDestroyed && lifeTimer < lifeTime)
        {
            GameObject audio = Instantiate( audioPlayer,transform.position,Quaternion.identity );
            DestroyImmediate(gameObject);
        }
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
        if (collider.CompareTag("ColorBlock"))
        {
            ColorBlock colorBlock = collider.GetComponent<ColorBlock>();
            if (colorBlock != null)
            {
                colorBlock.ChangeColor(selfColor);
                isDestroyed = true;
            }
        }
        else if (collider.CompareTag("Bullettrigger"))
        {
            isDestroyed = true;
        }
        else if (collider.CompareTag("lens") || collider.CompareTag("mirror"))
        {
            lensrotation lensRotation = collider.GetComponent<lensrotation>();
            EmitterController controller = GameObject.FindObjectOfType<EmitterController>();
            bool allowed = lensRotation.allowed;

            if (allowed && rend.material.color == Color.blue)
            {
                int direction = 1;
                lensRotation.changerotation(direction);
                controller.ResetHit_lens();
                controller.ResetHit_mirror();
                controller.ResetHit_trigger();
            }
            else if (allowed && rend.material.color == Color.red)
            {
                int direction = -1;
                lensRotation.changerotation(direction);
                controller.ResetHit_lens();
                controller.ResetHit_mirror();
                controller.ResetHit_trigger();
            }
            isDestroyed = true;
        }
        else if (collider.CompareTag("Bullettrigger"))
        {
            isDestroyed = true;
        }
        else if (collider.CompareTag("Ground"))
            isDestroyed = true;
        else if (collider.CompareTag("Target"))
        {
            Target target = collider.GetComponent<Target>();
            if (target != null)
            {
                target.SetActive();
                isDestroyed = true;
            }
        }
    }
}
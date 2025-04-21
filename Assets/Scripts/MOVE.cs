using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVE : MonoBehaviour
{
    public float speed = 10.0f;
    public Color color = Color.red;
    public Color bulletColor = Color.white;
    void Start()
    {
        Renderer bulletRenderer = GetComponent<Renderer>();
        if (bulletRenderer != null)
        {
            bulletRenderer.material.color = bulletColor;
        }
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Renderer wallRenderer = collision.gameObject.GetComponent<Renderer>();
            Renderer bulletRenderer = GetComponent<Renderer>();

            if (wallRenderer != null && bulletRenderer != null)
            {
                if (wallRenderer.material.color == bulletRenderer.material.color)
                {
                    // 子弹与墙颜色相同，子弹穿过墙
                    Debug.Log("子弹与墙颜色相同，子弹穿过墙");
                }
                else
                {
                    // 子弹与墙颜色不同，子弹消失，墙变成子弹的颜色
                    Debug.Log("子弹与墙颜色不同，子弹消失，墙变成子弹的颜色");
                    wallRenderer.material.color = bulletRenderer.material.color;
                    Destroy(gameObject);
                }
            }
        }
    }
}
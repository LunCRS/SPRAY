using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    #region Components
    private GameObject mainCamera;
    private Rigidbody rb;
    private Renderer rend;
    #endregion


    [Header("Shoot info")]
    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private Color bulletColor;
    [SerializeField] private Color selfColor;

    [Header("Move info")]
    [SerializeField] private float moveSpeed = 6.0f;
    [SerializeField] private float jumpForce = 5.0f;
    private Vector2 move;
    private Vector3 targetDir;
    private float targetRotation = 0.0f;


    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }

        rb = GetComponent<Rigidbody>();
        rend = GetComponentInChildren<Renderer>();
    }

    void FixedUpdate()
    {
        if (move != Vector2.zero)
        {
            Vector3 inputDir = new Vector3(move.x, 0.0f, move.y).normalized;
            targetRotation = Mathf.Atan2(inputDir.x, inputDir.z) * Mathf.Rad2Deg + mainCamera.transform.eulerAngles.y;
            targetDir = Quaternion.Euler(0.0f, targetRotation, 0.0f) * Vector3.forward;

            rb.velocity = new Vector3(moveSpeed * targetDir.x, rb.velocity.y, moveSpeed * targetDir.z);
        }
    }

    void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (rb.velocity.y == 0)
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    void OnFire(InputValue value)
    {
        Transform transform = GetComponent<Transform>();
        CreateBullet(transform);
    }

    private void CreateBullet(Transform transform)
    {
        GameObject bullet = Instantiate(prefabBullet, transform.position, mainCamera.transform.rotation);
        if (bulletColor == Color.white)
            bullet.layer = LayerMask.NameToLayer("Default");
        else if (bulletColor == Color.red)
            bullet.layer = LayerMask.NameToLayer("Red Layer");
        else if (bulletColor == Color.green)
            bullet.layer = LayerMask.NameToLayer("Green Layer");
        else if (bulletColor == Color.blue)
            bullet.layer = LayerMask.NameToLayer("Blue Layer");
    }

    public void SetPlayerColor(Color color)
    {
        selfColor = color;

        // ��ȡ�Ӷ���
        Transform child = transform.Find("Body"); // �滻Ϊ�Ӷ��������

        if (child != null)
        {
            // ��ȡ�Ӷ���� Renderer ���
            Renderer renderer = child.GetComponent<Renderer>();

            if (renderer != null)
            {
                // ������ɫ
                renderer.material.color = selfColor;
            }
        }

        if (selfColor == Color.white)
            gameObject.layer = LayerMask.NameToLayer("Default");
        else if (selfColor == Color.red)
            gameObject.layer = LayerMask.NameToLayer("Red Layer");
        else if (selfColor == Color.green)
            gameObject.layer = LayerMask.NameToLayer("Green Layer");
        else if (selfColor == Color.blue)
            gameObject.layer = LayerMask.NameToLayer("Blue Layer");

    }

    public void SetBulletColor(Color color)
    {
        bulletColor = color;
    }

}

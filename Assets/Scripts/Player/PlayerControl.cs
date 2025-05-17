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
    private InputActionAsset inputActionAsset;
    #endregion

    public int playerID;

    [Header("Shoot info")]
    public Color selfColor;
    [SerializeField] private Color bulletColor;
    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private float fireRate = 0.5f;
    private float fireTimer = 0f;
    private InputAction fireAction;
    private bool isPerformingFire = false;
    

    [Header("Move info")]
    public float moveSpeed = 6.0f;
    private Vector2 move;
    private Vector3 targetDir;
    private float targetRotation = 0.0f;

    [Header("Jump info")]
    public float jumpForce = 5.0f;
    [SerializeField]
    private float groundCheckDis = .1f;
    [SerializeField] private float chaserCheckis = .1f;
    [SerializeField] private float coyoteTime = .2f;
    [SerializeField] private float maxYVelocity = 10f;
    private float coyoteTimer;
    private bool canJump = true;
    private float jumpInterTimer = 0f;

    [Header("Dead info")]
    public Transform birthPlace;
    public bool isDead = false;
    private Transform standOnDetect;
    public int player_type;
    public bool hasReset = false;

    void Start()
    {

        if (playerID == 1)
            mainCamera = GameObject.FindGameObjectWithTag("Cam1");
        else
            mainCamera = GameObject.FindGameObjectWithTag("Cam2");

        rb = GetComponent<Rigidbody>();
        rend = GetComponentInChildren<Renderer>();
        inputActionAsset = GetComponent<PlayerInput>().actions;
        fireAction = inputActionAsset.FindAction("Fire");
        coyoteTimer = coyoteTime;

        //rend.material.color = selfColor;

        fireAction.started += ctx => isPerformingFire = true;
        fireAction.canceled += ctx => isPerformingFire = false;
    }

    void Update()
    {
        if (IsGrounded())
        {
            // Debug.Log("Grounded");
        }

        if (isDead)
        {
            rb.velocity = Vector3.zero;
        }

        if (move != Vector2.zero)
        {
            Vector3 inputDir = new Vector3(move.x, 0.0f, move.y).normalized;
            targetRotation = Mathf.Atan2(inputDir.x, inputDir.z) * Mathf.Rad2Deg + mainCamera.transform.eulerAngles.y;
            targetDir = Quaternion.Euler(0.0f, targetRotation, 0.0f) * Vector3.forward;

            rb.velocity = new Vector3(moveSpeed * targetDir.x, rb.velocity.y, moveSpeed * targetDir.z);
        }
        else
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }
        
        if(rb.velocity.y <= -maxYVelocity )
            rb.velocity = new Vector3( rb.velocity.x,-maxYVelocity,rb.velocity.z );

        JumpCheck();
        FireUpdate();
    }


    void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckDis, transform.position.z));

    }
    public bool IsGrounded ()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDis))
        {
            // Debug.Log(gameObject.layer);
            return hit.collider.gameObject.layer != gameObject.layer;
        }

        return false;
    }

    public bool IsChaser()
    {
        RaycastHit hit_Chaser;

        if (Physics.Raycast(transform.position, Vector3.down, out hit_Chaser, chaserCheckis))
        {
            // Debug.Log(gameObject.layer);
            return hit_Chaser.collider.gameObject.layer == LayerMask.NameToLayer("Chaser_die"); ;
        }

        return false;
    }


    private void JumpCheck()
    {
        if (IsGrounded())
        {
            coyoteTimer = coyoteTime;
            canJump = true;
        }
        else
        {
            coyoteTimer -= Time.deltaTime;
            if (coyoteTimer <= 0)
                canJump = false;
        }
        jumpInterTimer += Time.deltaTime;
    }
    void OnJump(InputValue value)
    {
        if (playerID == 1)
        {
            if (canJump && jumpInterTimer >= coyoteTime + 0.05f)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
                jumpInterTimer = 0f;
            }
        }
        else
        {
            if (IsGrounded())
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            }
        }
    }

    void OnFire(InputValue value)
    {
        fireTimer = -fireRate;
        Transform trans = transform.Find("FirePoint");
        CreateBullet(trans);
    }
    private void FireUpdate()
    {
        fireTimer += Time.deltaTime;
        if (isPerformingFire && fireTimer >= 0)
        {
            Transform trans = transform.Find("FirePoint");
            CreateBullet(trans);
            fireTimer = -fireRate;
        }
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

        Transform child = transform.Find("Body");

        if (child != null)
        {
            Renderer renderer = child.GetComponent<Renderer>();

            if (renderer != null)
            {
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

    public void PositionLock()
    {
        rb.velocity = Vector3.zero;
    }

    public void ChangeMoveSpeed(float speed)
    {
        moveSpeed += speed;
    }
}

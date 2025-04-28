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

    public int playerID;

    [Header( "Shoot info")]
    public Color selfColor;
    [SerializeField] private Color bulletColor;
    [SerializeField] private GameObject prefabBullet;

    [Header("Move info")]
    [SerializeField] private float moveSpeed = 6.0f;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float groundCheckDis = 0.1f;
    [SerializeField] private LayerMask whatIsGround;
    private Vector2 move;
    private Vector3 targetDir;
    private float targetRotation = 0.0f;


    void Start()
    {
        //if(mainCamera == null)
        //{
        //    mainCamera = GameObject.FindGameObjectWithTag( "MainCamera" );
        //}

        if( playerID == 1 )
            mainCamera = GameObject.FindGameObjectWithTag( "Cam1" );
        else
            mainCamera = GameObject.FindGameObjectWithTag( "Cam2" );

        rb = GetComponent<Rigidbody>();
        rend = GetComponentInChildren<Renderer>();
    }

    void Update()
    {
        if(move != Vector2.zero)
        {
            Vector3 inputDir = new Vector3( move.x,0.0f,move.y ).normalized;
            targetRotation = Mathf.Atan2( inputDir.x,inputDir.z ) * Mathf.Rad2Deg + mainCamera.transform.eulerAngles.y;
            targetDir = Quaternion.Euler( 0.0f,targetRotation,0.0f ) * Vector3.forward;

            rb.velocity = new Vector3( moveSpeed * targetDir.x,rb.velocity.y,moveSpeed * targetDir.z );
        }
        else
        {
            rb.velocity = new Vector3(0f, rb.velocity.y,0f );
        }
    }

    void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    private void OnDrawGizmos ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine( transform.position,new Vector3(transform.position.x, transform.position.y - groundCheckDis, transform.position.z) );
    }
    private bool IsGrounded ()
    {
        RaycastHit hit;

        if( Physics.Raycast( transform.position,Vector3.down,out hit,groundCheckDis ) )
            return hit.collider.gameObject.layer != gameObject.layer;

        return false;
    }
    void OnJump(InputValue value)
    {
        if(IsGrounded())
            rb.velocity = new Vector3( rb.velocity.x,jumpForce,rb.velocity.z );
    }

    void OnFire ( InputValue value )
    {
        Transform trans = transform.Find( "FirePoint" );
        CreateBullet( trans );
    }

    private void CreateBullet ( Transform transform )
    {
        GameObject bullet = Instantiate( prefabBullet,transform.position,mainCamera.transform.rotation );
        if( bulletColor == Color.white )
            bullet.layer = LayerMask.NameToLayer( "Default" );
        else if( bulletColor == Color.red )
            bullet.layer = LayerMask.NameToLayer( "Red Layer" );
        else if( bulletColor == Color.green )
            bullet.layer = LayerMask.NameToLayer( "Green Layer" );
        else if( bulletColor == Color.blue )
            bullet.layer = LayerMask.NameToLayer( "Blue Layer" );
    }


    public void SetPlayerColor ( Color color )
    {
        selfColor = color;

        Transform child = transform.Find( "Body" );

        if( child != null )
        {
            Renderer renderer = child.GetComponent<Renderer>();

            if( renderer != null )
            {
                renderer.material.color = selfColor;
            }
        }

        if( selfColor == Color.white )
            gameObject.layer = LayerMask.NameToLayer( "Default" );
        else if( selfColor == Color.red )
            gameObject.layer = LayerMask.NameToLayer( "Red Layer" );
        else if( selfColor == Color.green )
            gameObject.layer = LayerMask.NameToLayer( "Green Layer" );
        else if( selfColor == Color.blue )
            gameObject.layer = LayerMask.NameToLayer( "Blue Layer" );

    }

    public void SetBulletColor(Color color)
    {
        bulletColor = color;
    }

}

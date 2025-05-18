using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl: MonoBehaviour
{
    public GameObject[] preferTargets;
    public Transform[] patrolPoints;
    public int patrolIndex = 0; // Index of the current patrol point
    public NavMeshAgent agent;
    public float movespeed = 3.5f;
    public float huntDistance = 10f;
    //public string enemyType;
    //public string enemyName; // Never trust this
    public int defaultVolume;  // Default volume was set with type
    public int volume;
    public int volumeToDie; // Default volume to die was set with type
    public Color enemyColor; // Default color was set with type
    public float knockbackforce = 5f; // Default knockback force was set with type
    public Renderer enemyRenderer; // Renderer component of the enemy
    private AudioSource enemyAudio;
    [SerializeField] private AudioClip[] audioClips;


    public void UpdateSize ()
    {
        // Calculate the scale based on the volume
        transform.localScale = Vector3.one * volume * 0.5f;
    }

    void Start ()
    {
        // Initialize the NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();
        enemyAudio = GetComponent<AudioSource>();

        enemyAudio.clip = audioClips[UnityEngine.Random.Range( 0,audioClips.Length )];
        enemyAudio.Play();

        agent.speed = movespeed;
        agent.autoBraking = false; // Disable auto-braking to allow continuous movement
        enemyRenderer = GetComponentInChildren<Renderer>(); // Get the Renderer component of the enemy
        enemyRenderer.material.color = enemyColor; // Set the color

        volume = defaultVolume;

        UpdateSize();

        GotoNextPoint();
    }

    void GotoNextPoint ()
    {
        // If no patrol points are set, return
        if( patrolPoints.Length == 0 )
            return;
        // Set the agent to go to the currently selected patrol point
        agent.destination = patrolPoints[patrolIndex].position;
        // Choose the next patrol point in the array
        patrolIndex = ( patrolIndex + 1 ) % patrolPoints.Length;
    }

    // Update is called once per frame
    private void Update ()
    {
        foreach( var p in preferTargets )
        {
            if( p == null )
                continue;
            PlayerControl player = p.GetComponent<PlayerControl>();
            if( player != null )
            {
                Color playerColor = player.selfColor;
                // Check if the target is within the hunt distance
                if( Vector3.Distance( transform.position,p.transform.position ) < huntDistance && playerColor != enemyColor )
                {
                    agent.destination = p.transform.position;
                    return; // Exit the method to prevent going to patrol points
                }
            }
        }

        if( !agent.pathPending && agent.remainingDistance < 0.5f )
        {
            GotoNextPoint();
        }
    }

    private void OnTriggerEnter ( Collider other )
    {
        if( other.CompareTag( "Bullet" ) )
        {
            Bullet bullet = other.GetComponent<Bullet>();
            if( bullet != null )
            {
                if( bullet.selfColor == enemyColor )
                {
                    volume++;
                    UpdateSize();
                    if( volume >= volumeToDie )
                    {
                        gameObject.SetActive( false );
                    }
                }
                else
                {
                    Vector3 knockbackDirection = bullet.bulletDirection;
                    agent.velocity = knockbackDirection * knockbackforce;
                }
                Destroy( other.gameObject );
            }
        }
        if(other.CompareTag( "Player" ))
        {
            PlayerControl player = other.GetComponent<PlayerControl>();
            if( player != null )
            {
                player.isDead = true;
            }
        }
    }

    // Scrapped
    //public void SetPreferTargets(List<string> targets)
    //{
    //    preferTargets = targets;
    //}
    //public void SetPatrolPoints(List<Vector3> points)
    //{
    //    patrolPoints = points;
    //}
    // patrol enemy
    //public Enemy(string name_, string type_, List<string> targets_, List<Vector3> points_)
    //{
    //    enemyName = name_;
    //    enemyType = type_;
    //    preferTargets = targets_;
    //    patrolPoints = points_;

    //}

    // guard enemy
    //public Enemy(string name_, string type_, List<string> targets_)
    //{
    //    enemyName = name_;
    //    enemyType = type_;
    //    preferTargets = targets_;
    //    patrolPoints = new List<Vector3>();
    //}

    //// undead patrol enemy
    //public Enemy(string name_, string type_, bool undead, List<string> points_)
    //{
    //    enemyName = name_;
    //    enemyType = type_;
    //    preferTargets = new List<string>();
    //    patrolPoints = new List<Vector3>();
    //}
}

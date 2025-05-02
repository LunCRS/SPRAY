using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject[] preferTargets;
    public Transform[] patrolPoints;
    public int patrolIndex = 0; // Index of the current patrol point
    private NavMeshAgent agent;
    public double huntDistance = 10;
    //public string enemyType;
    //public string enemyName; // Never trust this
    public int volume;  // Default volume was set with type
    public int volumeToDie; // Default volume to die was set with type

    void Start()
    {
        // Initialize the NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false; // Disable auto-braking to allow continuous movement

        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        // If no patrol points are set, return
        if (patrolPoints.Length == 0)
            return;
        // Set the agent to go to the currently selected patrol point
        agent.destination = patrolPoints[patrolIndex].position;
        // Choose the next patrol point in the array
        patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
    }

    // Update is called once per frame
    private void Update()
    {
        foreach(var p in preferTargets)
        {
            if (p == null)
                continue;
            // Check if the target is within the hunt distance
            if (Vector3.Distance(transform.position, p.transform.position) < huntDistance)
            {
                agent.destination = p.transform.position;
                return; // Exit the method to prevent going to patrol points
            }
        }

        if (!agent.pathPending && agent.remainingDistance < 0.5f) 
        {
            GotoNextPoint();
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

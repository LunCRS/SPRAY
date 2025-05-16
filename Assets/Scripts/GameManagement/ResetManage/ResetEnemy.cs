using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetEnemies : MonoBehaviour
{
    public List<GameObject> enemiesToReset = new List<GameObject>();
    private Dictionary<GameObject, EnemyInitialState> enemyInitialStates = new Dictionary<GameObject, EnemyInitialState>();
    private struct EnemyInitialState
    {
        public bool isActive;
        public Vector3 position;
        public int volume;
        public Vector3 velocity;
        public Transform patrolPoint;
    }

    void Start()
    {
        foreach (var enemy in enemiesToReset)
        {
            if (enemy != null)
            {
                Rigidbody enemyRigidbody = enemy.GetComponent<Rigidbody>();
                EnemyControl enemyControl = enemy.GetComponent<EnemyControl>();

                enemyInitialStates[enemy] = new EnemyInitialState
                {
                    isActive = enemy.activeSelf,
                    position = enemy.transform.position,
                    volume = enemyControl != null ? enemyControl.volume : 0,
                    velocity = enemyRigidbody != null ? enemyRigidbody.velocity : Vector3.zero,
                    patrolPoint = enemyControl!= null? enemyControl.patrolPoints[0] : null
                };
            }
        }
    }
    public void ResetAllEnemies()
    {
        foreach (var pair in enemyInitialStates)
        {
            GameObject enemy = pair.Key;
            EnemyInitialState state = pair.Value;

            if (enemy != null)
            {
                Rigidbody enemyRigidbody = enemy.GetComponent<Rigidbody>();
                enemy.transform.position = state.position;
                enemy.SetActive(state.isActive);

                EnemyControl enemyControl = enemy.GetComponent<EnemyControl>();
                if (enemyControl != null)
                {
                    enemyControl.volume = state.volume;
                    enemyControl.agent.destination = state.patrolPoint.position;
                    enemyControl.UpdateSize();
                }
                if (enemyRigidbody != null)
                {
                    enemyRigidbody.velocity = Vector3.zero;
                }

                Renderer enemyRenderer = enemy.GetComponent<Renderer>();
            }
        }
    }
}
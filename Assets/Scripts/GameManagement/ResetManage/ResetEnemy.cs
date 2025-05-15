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
        public Color color;
        public int volume;
    }

    void Start()
    {
        foreach (var enemy in enemiesToReset)
        {
            if (enemy != null)
            {
                Enemy enemyVolume = enemy.GetComponent<Enemy>();
                Renderer enemyRenderer = enemy.GetComponent<Renderer>();
                enemyInitialStates[enemy] = new EnemyInitialState
                {
                    isActive = enemy.activeSelf,
                    position = enemy.transform.position,
                    color = enemyVolume.enemyColor,
                    volume = enemyVolume != null ? enemyVolume.volume : 0,
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
                enemy.transform.position = state.position;
                enemy.SetActive(state.isActive);

                Enemy enemyVolume = enemy.GetComponent<Enemy>();
                if (enemyVolume != null)
                {
                    enemyVolume.volume = state.volume;
                    enemyVolume.UpdateSize();
                }

                Renderer enemyRenderer = enemy.GetComponent<Renderer>();
                if (enemyRenderer != null)
                {
                    enemyRenderer.material.color = state.color;
                }
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] getZones;
    private GetEnemy getEnemyScript;
    private Enemy enemyScript;

    public void ResetEnemy()
    {
        foreach( var enemy in enemies )
        {
            enemyScript = enemy.GetComponent<Enemy>();
            enemy.transform.position = enemyScript.patrolPoints[0].position;
            enemyScript.volume = enemyScript.defaultVolume;
            enemyScript.UpdateSize();
            enemy.SetActive( false );
        }

        foreach( var get in getZones )
        {
            getEnemyScript = get.GetComponent<GetEnemy>();
            getEnemyScript.actived = false;
        }
    }

}

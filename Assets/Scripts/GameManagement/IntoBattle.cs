using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntoBattle : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    private GameManager gameManagerScript;

    private void Start ()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    private void OnTriggerEnter ( Collider other )
    {
        if( other.CompareTag( "Player" ) )
        {
            gameManagerScript.inBattle = true;
        }
    }
}

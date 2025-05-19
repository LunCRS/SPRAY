using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBattle : MonoBehaviour
{
    public GameObject GameManager;
    private GameManager gameManager;
    private int type;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (type == 0)
        {
            if (collision.gameObject.tag == "Player")
            {
                gameManager.inBattle = true;

            }
        }
        else if (type == 1)
        {
            if (collision.gameObject.tag == "Player")
            {
                gameManager.inBattle = true;

            }
        }

    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuiLiFangManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player1;
    public GameObject Player2;
    private PlayerControl playercontrol1;
    private PlayerControl playercontrol2;
    public GameObject ShuiLiFang;
    //public GameObject GameManager;
    //private GameManager gamemanager;
    void Start()
    {
        playercontrol1 = Player1.GetComponent<PlayerControl>();
        playercontrol2 = Player2.GetComponent<PlayerControl>();
        //gamemanager = GameManager.GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playercontrol1.rb.velocity.y == 0 || playercontrol2.rb.velocity.y == 0)
        {
            playercontrol1.isDead = true;
            playercontrol2.isDead = true;
            playercontrol1.moveSpeed *= 0.8f;
            playercontrol2.moveSpeed *= 0.8f;
            ShuiLiFang.SetActive(false);
        }
        // else if (playercontrol2.rb.velocity.y == 0)
        // {
        //     playercontrol2.isDead = true;
        //     playercontrol1.isDead = true;
        //     playercontrol1.moveSpeed *= 0.8f;
        //     playercontrol2.moveSpeed *= 0.8f;
        //     ShuiLiFang.SetActive(false);


        // }
    }
}

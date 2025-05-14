using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 initialPosition;
    public GameObject Player_L;
    public GameObject Player_R;
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.tag == "Player")
        {
            PlayerControl player_L = Player_L.GetComponent<PlayerControl>();
            PlayerControl player_R = Player_R.GetComponent<PlayerControl>();
            player_L.isDead = true;
            player_R.isDead = true;
            transform.position = initialPosition;
        }
    }
}

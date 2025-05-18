using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FinalStage : MonoBehaviour
{
    private Renderer rend;
    public Transform stage_position;
    private bool isPlayerOnStage = false;
    public int stage_number;
    public GameObject Partner;
    public bool isPlayerOnStage_Partner = false;
    private FinalStage partner;
    public GameObject L_Cam_Old;
    public GameObject L_Cam_New;
    public GameObject R_Cam_Old;
    public GameObject R_Cam_New;
    public GameObject Cross_L;
    public GameObject Cross_R;
    public GameObject Player_L;
    public GameObject Player_R;
    public GameObject Airfan;
    // Start is called before the first frame update
    void Start()
    {
        partner = Partner.GetComponent<FinalStage>();
    }

    // Update is called once per frame
    void Update()
    {
        isPlayerOnStage_Partner = partner.isPlayerOnStage;
        if (stage_number == 0)
        {
            ActivateStage();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        PlayerControl player = other.GetComponent<PlayerControl>();
        ThirdPersonCamera camera = other.GetComponent<ThirdPersonCamera>();
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (stage_number == 0)
        {
            if (other.CompareTag("Player") && player.player_type == 2)
            {
                isPlayerOnStage = true;
                player.PositionLock();
                player.transform.position = stage_position.position;
                player.transform.eulerAngles = Vector3.zero;
                player.enabled = false;
                camera.enabled = false;
                L_Cam_Old.SetActive(false);
                L_Cam_New.SetActive(true);
                Cross_L.SetActive(false);
                rb.isKinematic = true;


            }
        }
        else if (stage_number == 1)
        {
            if (other.CompareTag("Player") && player.player_type == 1)
            {
                isPlayerOnStage = true;
                player.PositionLock();
                player.transform.position = stage_position.position;
                player.transform.eulerAngles = Vector3.zero;
                player.enabled = false;
                camera.enabled = false;
                R_Cam_Old.SetActive(false);
                R_Cam_New.SetActive(true);
                Cross_R.SetActive(false);
                rb.isKinematic = true;
            }
        }

    }



    void ActivateStage()
    {
        if (isPlayerOnStage && isPlayerOnStage_Partner)
        {
            Airfan.SetActive(true);
            FinalMove move1 = Player_L.GetComponent<FinalMove>();
            FinalMove move2 = Player_R.GetComponent<FinalMove>();
            Rigidbody rb1 = Player_L.GetComponent<Rigidbody>();
            Rigidbody rb2 = Player_R.GetComponent<Rigidbody>();
            rb1.isKinematic = false;
            rb2.isKinematic = false;
            move1.enabled = true;
            move2.enabled = true;
        }
    }
}

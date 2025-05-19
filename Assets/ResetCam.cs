using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCam : MonoBehaviour
{
    public GameObject L_Cam_old;
    public GameObject R_Cam_old;
    public GameObject L_Cam_new;
    public GameObject R_Cam_new;
    public GameObject Cam_all;
    public GameObject Player_L;
    public GameObject Player_R;
    private PlayerControl playerControl_L;
    private PlayerControl playerControl_R;
    public GameObject menu;
    public GameObject Stage;
    private FinalStage stage;

    void Start ()
    {
        playerControl_L = Player_L.GetComponent<PlayerControl>();
        playerControl_R = Player_R.GetComponent<PlayerControl>();
        stage = Stage.GetComponent<FinalStage>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter ( Collider other )
    {
       if( other.CompareTag( "Player" ) )
        {
            stage.isPlayerOnStage = false;
            Stage.SetActive( false );
            L_Cam_old.SetActive( false );
            R_Cam_old.SetActive( false );
            L_Cam_new.SetActive( true );
            R_Cam_new.SetActive( true );
            Cam_all.SetActive( false );
            other.GetComponent<PlayerControl>().enabled = true;
            other.GetComponent<ThirdPersonCamera>().enabled = true;
            other.GetComponent<FinalMove>().enabled = false;
            menu.SetActive( true );
        }
    }
}


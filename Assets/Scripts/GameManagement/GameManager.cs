using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Image imgL, imgR;
    private Color currentColor_L, currentColor_R;
    private PlayerControl control_L, control_R;

    [SerializeField] private GameObject Player_L, Player_R;
    [SerializeField] private GameObject Canvas_L, Canvas_R;
    [SerializeField] private GameObject battleManager;
    [SerializeField] private float rebirthTime = 1f;
    [SerializeField] private float standOnDis = 1.1f;
    private float reTimer_L, reTimer_R;
    private BattleManager battleScript;

    public bool inBattle = false;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //imgL = Canvas_L.GetComponentInChildren<Image>();
        //imgR = Canvas_R.GetComponentInChildren<Image>();
        control_L = Player_L.GetComponent<PlayerControl>();
        control_R = Player_R.GetComponent<PlayerControl>();

        reTimer_L = rebirthTime;
        reTimer_R = rebirthTime;

        if(battleManager != null)
            battleScript = battleManager.GetComponent<BattleManager>();
    }

    void Update()
    {
        if( control_L.isDead || control_R.isDead )
        {
            if(battleScript != null)
                battleScript.ResetEnemy();
        }

        if( control_L.isDead )
        {
            control_L.PositionLock();
            Player_L.transform.position = control_L.birthPlace.position;
            if(inBattle)
                Player_R.transform.position = control_R.birthPlace.position;

            control_L.isDead = false;
        }
        else if( control_R.isDead )
        {
            control_R.PositionLock();
            Player_R.transform.position = control_R.birthPlace.position;
            if(inBattle)
                Player_L.transform.position = control_L.birthPlace.position;

            control_R.isDead = false;
        }


        PlayerStandOnCheck();

    }

    private void PlayerStandOnCheck ()
    {
        RaycastHit hit;

        if( Physics.Raycast( Player_R.transform.position,Vector3.down,out hit,standOnDis ) )
        {
            if( hit.collider.CompareTag( "Player" ) )
            {
                PlayerControl playerHit = hit.collider.GetComponentInParent<PlayerControl>();
                if(playerHit.playerID == 1)
                    control_L.isDead = true;
            }
        }
    }


}

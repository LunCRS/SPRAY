using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Image imgL, imgR;
    private Color currentColor_L, currentColor_R;
    private PlayerControl control_L, control_R;
    private bool moved_L = false, moved_R = false;

    public Transform birthPlace_L, birthPlace_R;
    [SerializeField] private GameObject Player_L, Player_R;
    [SerializeField] private GameObject Canvas_L, Canvas_R;
    [SerializeField] private float rebirthTime = 1f;
    private float reTimer_L, reTimer_R;
    void Start()
    {
        imgL = Canvas_L.GetComponentInChildren<Image>();
        imgR = Canvas_R.GetComponentInChildren<Image>();
        control_L = Player_L.GetComponent<PlayerControl>();
        control_R = Player_R.GetComponent<PlayerControl>();

        reTimer_L = rebirthTime;
        reTimer_R = rebirthTime;
    }

    void Update()
    {
        if(control_L.isDead)
        {
            if(!moved_L)
            {
                if( reTimer_L <= 0 )
                {
                    Player_L.transform.position = birthPlace_L.position;
                    Player_L.transform.rotation = birthPlace_L.rotation;
                    moved_L = true;
                }

                currentColor_L = imgL.color;
                currentColor_L.a = 1 - 1 * reTimer_L / rebirthTime;
                imgL.color = currentColor_L;

                reTimer_L -= Time.deltaTime;
            }
            else
            {
                if(reTimer_L >= rebirthTime )
                {
                    control_L.isDead = false;
                    moved_L = false;
                    reTimer_L = rebirthTime;
                }

                currentColor_L = imgL.color;
                currentColor_L.a = 1 - 1 * reTimer_L / rebirthTime;
                imgL.color = currentColor_L;

                reTimer_L += Time.deltaTime;
            }
        }

        if( control_R.isDead )
        {
            if( !moved_R )
            {
                if( reTimer_R <= 0 )
                {
                    Player_R.transform.position = birthPlace_R.position;
                    Player_R.transform.rotation = birthPlace_R.rotation;
                    moved_R = true;
                }

                currentColor_R = imgR.color;
                currentColor_R.a = 1 - 1 * reTimer_R / rebirthTime;
                imgR.color = currentColor_R;

                reTimer_R -= Time.deltaTime;
            }
            else
            {
                if( reTimer_R >= rebirthTime )
                {
                    control_R.isDead = false;
                    moved_R = false;
                    reTimer_R = rebirthTime;
                }

                currentColor_R = imgR.color;
                currentColor_R.a = 1 - 1 * reTimer_R / rebirthTime;
                imgR.color = currentColor_R;

                reTimer_R += Time.deltaTime;
            }
        }
    }

    

}

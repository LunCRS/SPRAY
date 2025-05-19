using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamDark : MonoBehaviour
{
    public bool startDark = false;
    public bool endDark = false;
    public bool startLight = false;
    public bool hasdark = false;
    

    [SerializeField] private float darkTime = 1f;
    private float darkTimer = 0f;

    private Image dark;

    void Start()
    {
        dark = GetComponent<Image>();
    }

    void Update()
    {
        if(startDark)
        {
            darkTimer += Time.deltaTime;
            dark.color = new Color( 0,0,0,darkTimer );
            if( darkTimer >= darkTime )
            {
                startDark = false;
                endDark = true;
                hasdark = true;
                startLight = true;
                 

            }

        }
        if( startLight )
        {
            darkTimer -= Time.deltaTime;
            dark.color = new Color( 0,0,0,darkTimer );
            if( darkTimer <= 0 )
            {
                startLight = false;
                endDark = false;
            }
        }

    }

}

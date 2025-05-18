using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanAnim : MonoBehaviour
{
    [SerializeField] GameObject onModel, offModel;

    public void ActiveAnim()
    {
        offModel.SetActive( false );
        onModel.SetActive( true );
    }
    public void DeactiveAnim ()
    {
        offModel.SetActive( true );
        onModel.SetActive( false );
    }
}

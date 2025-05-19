using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLookRoot : MonoBehaviour
{
    [SerializeField] private GameObject L, R;
    private Transform trans;

    private void Start ()
    {
        trans = GetComponent<Transform>();
    }
    void Update()
    {
        trans.position = new Vector3((L.transform.position.x + R.transform.position.x) / 2, (L.transform.position.y + R.transform.position.y ) / 2, (L.transform.position.z + R.transform.position.z) / 2);
    }
}

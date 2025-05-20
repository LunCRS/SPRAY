using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("配置")]
    public string itemID; // 示例：Scene1_Coin1

    void Start()
    {
        // 启动时检查是否已收集
        if (CollectionManager.IsItemCollected(itemID))
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectionManager.CollectItem(itemID);
            gameObject.SetActive(false);
        }
    }
}

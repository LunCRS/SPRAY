using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretRoomManager : MonoBehaviour
{
    [System.Serializable]
    public struct PhotoDisplay
    {
        public GameObject Photo;

        public string targetPhotoID;// 对应的收藏品ID
    }
    public GameObject PhotoAll;

    [Header("照片配置")]
    public PhotoDisplay[] photoDisplays = new PhotoDisplay[5];
    void Start()
    {

    }

    void Update()
    {
        foreach (var display in photoDisplays)
        {
            bool isCollected = CollectionManager.IsItemCollected(display.targetPhotoID);

            if (isCollected)
            {
                display.Photo.SetActive(true);
            }
        }
        if (photoDisplays.Length == 5)
        {
            PhotoAll.SetActive(true);
        }
    }
}

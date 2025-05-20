using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CollectionManager
{


    private static readonly HashSet<string> CollectedItems = new();



    public static bool IsItemCollected(string itemID)
    {
        return CollectedItems.Contains(itemID);
    }

    public static void CollectItem(string itemID)
    {
        if (!CollectedItems.Contains(itemID))
        {
            CollectedItems.Add(itemID);
            // Debug.Log($"已收集物品: {itemID} (总数: {CollectedItems.Count})");
        }
    }
}





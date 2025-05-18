using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ResetManager_2 : MonoBehaviour
{
    public PlayerControl Player_Left;
    public PlayerControl Player_Right;
    public ResetColorBlocks_2 ResetColorBlocks;
    public ResetMoveMachines ResetMoveMachines;
    public ResetEnemies ResetEnemies;

    public void Update()
    {
        if (Player_Left != null && Player_Right != null && Player_Left.isDead && Player_Right.isDead && ResetColorBlocks != null && ResetMoveMachines != null && ResetEnemies != null)
        {
            ResetColorBlocks.ResetAllBlocks();
            ResetMoveMachines.ResetAllMachines();
            ResetEnemies.ResetAllEnemies();
        }
    }
}
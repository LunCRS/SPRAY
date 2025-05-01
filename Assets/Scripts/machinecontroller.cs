using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineController : MonoBehaviour
{
    public Dictionary<GameObject, GameObject> buttonToLauncherMap = new Dictionary<GameObject, GameObject>();

    public void RegisterButtonLauncherPair(GameObject button, GameObject launcher)
    {
        buttonToLauncherMap[button] = launcher;
    }

    public GameObject GetLauncherForButton(GameObject button)
    {
        if (buttonToLauncherMap.TryGetValue(button, out GameObject launcher))
        {
            return launcher;
        }
        return null;
    }
}
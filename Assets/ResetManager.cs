using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetManager : MonoBehaviour
{
    private static ResetManager _instance;
    public static ResetManager Instance => _instance;

    public List<IResettable> resettableObjects = new List<IResettable>();

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Register(IResettable obj)
    {
        if (!resettableObjects.Contains(obj))
            resettableObjects.Add(obj);
    }

    public void Unregister(IResettable obj)
    {
        if (resettableObjects.Contains(obj))
            resettableObjects.Remove(obj);
    }

    public void ResetAll()
    {
        foreach (var obj in resettableObjects)
        {
            obj.OnReset();
        }
    }
}

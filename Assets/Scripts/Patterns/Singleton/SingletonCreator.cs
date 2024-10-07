using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonCreator<T> : MonoBehaviour where T:MonoBehaviour
{

    protected static bool isQuiting;
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null && !isQuiting)
            {
                instance = FindObjectOfType(typeof(T)) as T;
                if (instance == null)
                {
                    GameObject singlegameObj = new GameObject(typeof(T).Name);
                    instance = singlegameObj.AddComponent<T>();
                }
            }
            return instance;
        }

    }
    protected virtual void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        if (HasInstance && instance!=this)
        {
            Destroy(gameObject);
        }

        instance = GetComponent<T>();
        DontDestroyOnLoad(instance);
    }

    public static bool HasInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;
            }
            return instance != null;
        }
    }

    

    protected virtual void OnApplicationQuit()
    {
        isQuiting = true;
    }

}

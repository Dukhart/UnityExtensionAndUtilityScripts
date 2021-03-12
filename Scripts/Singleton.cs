using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    static T instance;
    static public T Instance
    {
        get
        {
            if (instance == null)
            {
                // attempt to create the instance
                instance = GameObject.FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject temp = new GameObject("TempName");
                    temp.name = temp.GetType().ToString();
                    instance = temp.AddComponent<T>();
                    if (instance == null) Debug.LogError(temp.name + " is null");
                }
            }
            // return the instance
            return instance;
        }
    }
    public static bool isInitialized
    {
        get { return instance == null ? false : true; }
    }
    protected virtual void Awake()
    {
        // check for existing instance
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.LogError("[Singleton] trying to instantiat another instance.");
            return;
        }
        // assign the instance
        instance = (T)this;
    }
    protected virtual void OnDestroy()
    {
        // clear the instance
        if (instance == this)
        {
            instance = null;
        }
    }
}

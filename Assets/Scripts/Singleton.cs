using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton<T> : MonoBehaviour where T : class
{
    private static T instance;

    public static T Instance { get => GetInstance(); }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
        }
        else
        {
            Debug.Log("Found second instance of " + typeof(T) + ", destroying.");

            Destroy(gameObject);
        }
    }



    protected virtual void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
            Debug.LogWarning("Destroying Singleton for " + typeof(T));
        }
    }

    public static T GetInstance()
    {
        return instance;
    }
}

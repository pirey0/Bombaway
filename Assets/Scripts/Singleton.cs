using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;

    public static T Instance { get => GetInstance(); }

    [Header("Singleton")]
    [SerializeField] protected bool dontDestroyOnLoad = false;

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;

            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            Debug.Log("Found second instance of " + typeof(T) + ", destroying.");

            if (dontDestroyOnLoad)
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(this);
            }
        }

        UnityEngine.SceneManagement.SceneManager.activeSceneChanged += OnSceneChanged;
    }

    protected virtual void OnSceneChanged(Scene arg0, Scene arg1)
    {

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

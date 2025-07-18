﻿using System;
using UnityEngine;

public class SingleTon<T> : MonoBehaviour where T : Component
{
    public static T instance;
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                var t = FindFirstObjectByType <T>();

                if(t != null)
                {
                    instance = t;
                }
                else
                {
                    var newObj = new GameObject(typeof(T).ToString());
                    newObj.AddComponent<T>();
                    instance = newObj.GetComponent<T>();
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

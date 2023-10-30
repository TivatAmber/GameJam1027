using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour
    where T : MonoBehaviour
{
    public bool global = true;
    static T instance;
    public static T Instance
    {
        get//
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (global)
        {
            DontDestroyOnLoad(gameObject);//不会销毁对象
        }
        OnStart();
    }
    protected virtual void OnStart()
    {

    }
}
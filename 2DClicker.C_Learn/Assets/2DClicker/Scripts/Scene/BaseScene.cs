using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseScene<T> : MonoBehaviour, IAddressable, IInit where T : BaseScene<T>
{
    private static T instance;
    public static T Instance
    {
        get
        {
            return instance;
        }
    }

    public event Action<GameObject> ReleaseEvent;

    public virtual void Init()
    {
        if (instance != null)
        {
            Debug.LogError($"Instance has not been initialized : {typeof(T).Name}");
            return;
        }

        instance = this as T;

        InitGameObject();
    }

    public abstract void InitGameObject();

    protected virtual void OnDestroy()
    {
        instance = null;
        ReleaseEvent?.Invoke(gameObject);
    }
}

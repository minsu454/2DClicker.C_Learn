using Common.Assets;
using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseScene<T> : MonoBehaviour, IAddressable, IUniTaskInit where T : BaseScene<T>
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

    public virtual async UniTask Init()
    {
        if (instance != null)
        {
            Debug.LogError($"Instance has not been initialized : {typeof(T).Name}");
            return;
        }

        instance = this as T;

        await InitGameObject();
    }

    public abstract UniTask InitGameObject();

    protected virtual void OnDestroy()
    {
        instance = null;
        ReleaseEvent?.Invoke(gameObject);
    }
}

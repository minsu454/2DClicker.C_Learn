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

    public async UniTask Init()
    {
        if (instance != null)
        {
            Debug.LogError($"Instance has not been initialized : {typeof(T).Name}");
            return;
        }

        instance = this as T;

        await InitScene();
    }

    /// <summary>
    /// 씬 동적 생성 해줄 오브젝트 몰빵하는 함수
    /// </summary>
    public abstract UniTask InitScene();

    protected virtual void OnDestroy()
    {
        instance = null;
        ReleaseEvent?.Invoke(gameObject);
    }
}

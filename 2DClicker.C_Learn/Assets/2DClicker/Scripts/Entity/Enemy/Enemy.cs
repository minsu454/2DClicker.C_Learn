using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IAddressable
{
    public event Action<GameObject> ReleaseEvent;

    protected virtual void OnDestroy()
    {
        ReleaseEvent?.Invoke(gameObject);
    }
}

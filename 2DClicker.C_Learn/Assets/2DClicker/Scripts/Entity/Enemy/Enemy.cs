using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IAddressable, IInit
{
    public event Action<GameObject> ReleaseEvent;
    public event Action<EnemySO> DieEvent;

    [SerializeField] private EnemySO enemySO;

    private int curHealth;

    public void Init()
    {
        curHealth = enemySO.MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
            return;

        curHealth = Mathf.Max(curHealth - damage, 0);
        Debug.Log(curHealth);

        if (curHealth == 0)
        {
            DieEvent?.Invoke(enemySO);
            Destroy(gameObject);
        }
    }

    protected virtual void OnDestroy()
    {
        ReleaseEvent?.Invoke(gameObject);
    }
}

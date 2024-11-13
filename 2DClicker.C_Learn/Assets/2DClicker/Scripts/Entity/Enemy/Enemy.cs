using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IAddressable, IInit
{
    public event Action<GameObject> ReleaseEvent;
    public event Action<EnemySO> DieEvent;

    [SerializeField] private EnemySO enemySO;
    [SerializeField] private UIHPBar bar;

    private int curHealth;

    public void Init()
    {
        curHealth = enemySO.MaxHealth;
        bar.SetUIBar(curHealth, enemySO.MaxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
            return;

        curHealth = Mathf.Max(curHealth - damage, 0);
        bar.SetUIBar(curHealth, enemySO.MaxHealth);

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

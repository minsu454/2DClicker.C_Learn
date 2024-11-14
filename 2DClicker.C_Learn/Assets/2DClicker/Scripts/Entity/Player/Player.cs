using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour, IAddressable, IInit
{
    [SerializeField] private PlayerSO player;

    public event Action<GameObject> ReleaseEvent;

    public event Action<int> goldUIEvent;
    public event Action<int> needUpgradeGoldUIEvent;
    public event Action<int> needAutoUpgradeGoldUIEvent;

    private int damage;

    private int gold = 0;
    public int Gold
    {
        get { return gold; }
        private set
        {
            gold = value;
            goldUIEvent?.Invoke(gold);
        }
    }

    private int needUpgradeGold = 100;
    public int NeedUpgradeGold
    {
        get { return needUpgradeGold; }
        private set
        {
            needUpgradeGold = value;
            needUpgradeGoldUIEvent?.Invoke(needUpgradeGold);
        }
    }

    private int needAutoUpgradeGold = 500;
    public int NeedAutoUpgradeGold
    {
        get { return needAutoUpgradeGold; }
        private set
        {
            needAutoUpgradeGold = value;
            needAutoUpgradeGoldUIEvent?.Invoke(needAutoUpgradeGold);
        }
    }

    public void Init()
    {
        PlayerController controller = GetComponent<PlayerController>();
        controller.ClickEvent += GiveDamage;
        
    }

    private void Start()
    {
        damage = player.Damage;
        gold = player.Gold;
    }

    private void GiveDamage(Vector2 pos)
    {
        if (InGameScene.Instance.stageManager.CurEnemy == null)
            return;

        InGameScene.Instance.stageManager.CurEnemy.TakeDamage(pos, damage);
    }

    public void Upgrade()
    {
        if (Gold < NeedUpgradeGold)
            return;

        Gold = Gold - NeedUpgradeGold;
        NeedUpgradeGold = NeedUpgradeGold + 50;
        damage += damage;
    }

    public void AutoUpgrade()
    {
        if (Gold < NeedAutoUpgradeGold)
            return;

        Gold = Gold - NeedAutoUpgradeGold;
        NeedAutoUpgradeGold = NeedAutoUpgradeGold * 2;

        StartCoroutine(CoTakeDamage());
    }

    private IEnumerator CoTakeDamage()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            GiveDamage(Vector2.zero);
        }
    }

    public void GetItem(EnemySO info)
    {
        Gold += info.DropGold;
    }

    private void OnDestroy()
    {
        ReleaseEvent?.Invoke(gameObject);
    }
}

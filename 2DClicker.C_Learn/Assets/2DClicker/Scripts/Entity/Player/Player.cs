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

    private int buff = 0;

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
            gold = value;
            needUpgradeGoldUIEvent?.Invoke(gold);
        }
    }

    private int needAutoUpgradeGold = 100;
    public int NeedAutoUpgradeGold
    {
        get { return needAutoUpgradeGold; }
        private set
        {
            gold = value;
            needAutoUpgradeGoldUIEvent?.Invoke(gold);
        }
    }

    public void Init()
    {
        PlayerController controller = GetComponent<PlayerController>();
        controller.ClickEvent += GiveDamage;
    }

    private void GiveDamage()
    {
        if (InGameScene.Instance.stageManager.CurEnemy == null)
            return;

        InGameScene.Instance.stageManager.CurEnemy.TakeDamage(player.Damage + buff);
    }

    public void Upgrade()
    {
        if (Gold < NeedUpgradeGold)
            return;

        Gold = Gold - NeedUpgradeGold;
        NeedUpgradeGold = NeedUpgradeGold + (int)(NeedUpgradeGold * 0.5f);
        buff += buff;
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

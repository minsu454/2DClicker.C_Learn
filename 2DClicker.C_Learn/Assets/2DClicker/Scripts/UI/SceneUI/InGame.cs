using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGame : BaseSceneUI
{
    public TextMeshProUGUI GoldTxt;
    public TextMeshProUGUI NeedUpgradeGoldTxt;
    public TextMeshProUGUI NeedAutoUpgradeGoldTxt;

    public override void Init()
    {
        base.Init();

        InGameScene.Instance.player.goldUIEvent += OnGoldChanged;
        InGameScene.Instance.player.needUpgradeGoldUIEvent += OnNeedUpgradeGoldChanged;
        InGameScene.Instance.player.needAutoUpgradeGoldUIEvent += OnNeedAutoUpgradeGoldChanged;
    }

    private void OnGoldChanged(int gold)
    {
        GoldTxt.text = $"{gold} G";
    }

    private void OnNeedUpgradeGoldChanged(int gold)
    {
        NeedUpgradeGoldTxt.text = $"{gold} G";
    }

    private void OnNeedAutoUpgradeGoldChanged(int gold)
    {
        NeedAutoUpgradeGoldTxt.text = $"{gold} G";
    }

    public void UpgradeBtn()
    {
        InGameScene.Instance.player.Upgrade();
    }

    public void AutoUpgradeBtn()
    {
        InGameScene.Instance.player.AutoUpgrade();
    }
}

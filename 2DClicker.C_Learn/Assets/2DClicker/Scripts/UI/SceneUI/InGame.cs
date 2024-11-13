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

    public override void Init()
    {
        base.Init();

        InGameScene.Instance.player.goldUIEvent += OnGoldChanged;
        InGameScene.Instance.player.needUpgradeGoldUIEvent += OnNeedUpgradeGoldChanged;
    }

    private void OnGoldChanged(int gold)
    {
        GoldTxt.text = $"{gold.ToString()} G";
    }

    private void OnNeedUpgradeGoldChanged(int gold)
    {
        NeedUpgradeGoldTxt.text = $"{gold.ToString()} G";
    }

    public void UpgradeBtn()
    {
        InGameScene.Instance.player.Upgrade();
    }
}

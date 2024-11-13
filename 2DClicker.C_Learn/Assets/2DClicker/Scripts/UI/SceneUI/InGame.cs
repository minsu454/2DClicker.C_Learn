using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame : BaseSceneUI
{
    public override void Init()
    {
        base.Init();
    }

    private void UpgradeBtn()
    {
        InGameScene.Instance.player.Upgrade();
    }
}

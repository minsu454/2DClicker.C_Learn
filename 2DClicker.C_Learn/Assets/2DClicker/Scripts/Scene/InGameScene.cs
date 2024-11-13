using Common.Assets;
using Common.Path;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.AddressableAssets.Build;
using UnityEngine;

public class InGameScene : BaseScene<InGameScene>
{
    private const string playerName = "Player";
    public Player player { get; private set; }
    public StageManager stageManager { get; private set; }

    public override async UniTask InitGameObject()
    {
        await CreatePlayer();
        CreateStageManager();
    }

    private async UniTask CreatePlayer()
    {
        GameObject playerGo = await AddressableAssets.InstantiateAsync(AdressablePath.PlayerPath(playerName));
        Instance.player = playerGo.GetComponent<Player>();

        Instance.player.Init();
    }

    private void CreateStageManager()
    {
        GameObject go = new GameObject("StageManager");
        Instance.stageManager = go.AddComponent<StageManager>();

        stageManager.Init();
    }
}

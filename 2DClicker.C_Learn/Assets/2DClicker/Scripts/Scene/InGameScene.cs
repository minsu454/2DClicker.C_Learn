using Common.Assets;
using Common.Path;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.AddressableAssets.Build;
using UnityEngine;

public class InGameScene : BaseScene<InGameScene>
{
    private const string playerName = "Player";
    public Player player { get; private set; }

    public override void InitGameObject()
    {
        CreatePlayer();
    }

    private async void CreatePlayer()
    {
        GameObject playerGo = await AddressableAssets.InstantiateAsync(AdressablePath.PlayerPath(playerName));
        player = playerGo.GetComponent<Player>();
    }
}

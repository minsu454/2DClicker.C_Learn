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
    public GameObject damagePrefab;
    private readonly Queue<GameObject> ObjectPool = new Queue<GameObject>();

    public override async UniTask InitGameObject()
    {
        await CreatePlayer();
        CreateStageManager();
        Pooling();
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
    
    private void Pooling()
    {
        for (int i = 0; i < 10; i++)
        {
            ObjectPool.Enqueue(Instantiate(damagePrefab));
        }
    }

    public GameObject Pop()
    {
        GameObject go = ObjectPool.Dequeue();
        ObjectPool.Enqueue(go);

        return go;
    }
}

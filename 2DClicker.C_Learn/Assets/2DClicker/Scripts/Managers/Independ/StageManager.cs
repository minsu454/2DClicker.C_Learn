using Common.Assets;
using Common.Path;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class StageManager : MonoBehaviour, IUniTaskInit
{
    private Enemy curEnemy;
    public Enemy CurEnemy
    {
        get { return curEnemy; }
        set
        {
            curEnemy = value;
            CurEnemy.Init();
            CurEnemy.DieEvent += DieEnemy;
        }
    }
    public EnemyType enemyType;

    public async UniTask Init()
    {
        enemyType = EnemyType.YellowBird;

        await CreateEnemy();
    }

    public async UniTask CreateEnemy()
    {
        GameObject enemyGo = await AddressableAssets.InstantiateAsync(AdressablePath.EnemyPath(enemyType.ToString()));
        CurEnemy = enemyGo.GetComponent<Enemy>();
    }

    public void StageUp()
    {
        enemyType++;
    }

    public void DieEnemy(EnemySO info)
    {
        InGameScene.Instance.player.GetItem(info);
    }
}

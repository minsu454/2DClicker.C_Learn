using Common.Assets;
using Common.Path;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class StageManager : MonoBehaviour, IInit
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

    public void Init()
    {
        enemyType = EnemyType.YellowBird;

        CreateEnemy();
    }

    public void StageUp()
    {
        enemyType++;
    }

    public async void CreateEnemy()
    {
        GameObject enemyGo = await AddressableAssets.InstantiateAsync(AdressablePath.EnemyPath(enemyType.ToString()));
        CurEnemy = enemyGo.GetComponent<Enemy>();
    }

    public void DieEnemy(EnemySO info)
    {
        InGameScene.Instance.player.GetItem(info);
        CreateEnemy();
    }

    
}

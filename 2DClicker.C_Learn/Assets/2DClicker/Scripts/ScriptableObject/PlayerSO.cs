using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "ScriptableObject/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    public int Damage;
    [field: SerializeField] public int Gold { get; private set; }

}

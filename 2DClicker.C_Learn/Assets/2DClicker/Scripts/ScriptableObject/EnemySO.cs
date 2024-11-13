using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "ScriptableObject/EnemySO")]
public class EnemySO : ScriptableObject
{
    [field: SerializeField] public int MaxHealth { get; private set; }
    [field: SerializeField] public int DropGold { get; private set; }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour, IAddressable
{
    public event Action<GameObject> ReleaseEvent;

    [SerializeField] private PlayerSO player;

    private int gold;
    private int score;

    private void Awake()
    {
        PlayerController controller = GetComponent<PlayerController>();
        controller.ClickEvent += GiveDamage;
    }

    private void GiveDamage()
    {
        
    }

    public void Upgrade()
    {

    }

    private void OnDestroy()
    {
        ReleaseEvent?.Invoke(gameObject);
    }
}

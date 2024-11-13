using System;
using UnityEngine;

public interface IAddressable
{
    public event Action<GameObject> ReleaseEvent;
}

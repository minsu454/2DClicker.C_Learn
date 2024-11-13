using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public event Action ClickEvent;

    private bool isPointerOverGameObject;

    private void Update()
    {
        isPointerOverGameObject = EventSystem.current.IsPointerOverGameObject();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && !isPointerOverGameObject)
        {
            ClickEvent?.Invoke();
        }
    }
}

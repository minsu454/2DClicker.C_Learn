using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public event Action<Vector2> ClickEvent;

    private bool isPointerOverGameObject;

    private void Update()
    {
        isPointerOverGameObject = EventSystem.current.IsPointerOverGameObject();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && !isPointerOverGameObject)
        {
            Vector2 pos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ClickEvent?.Invoke(pos);
        }
    }
}

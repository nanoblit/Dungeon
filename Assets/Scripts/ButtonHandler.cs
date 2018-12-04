using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool IsButtonDown { get; private set; } = false;
    public bool WasButtonPressedLastFrame { get; private set; } = false;
    public bool WasButtonReleasedLastFrame { get; private set; } = false;

    private void LateUpdate()
    {
        if (WasButtonPressedLastFrame) WasButtonPressedLastFrame = false;
        if (WasButtonReleasedLastFrame) WasButtonReleasedLastFrame = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        IsButtonDown = true;
        WasButtonPressedLastFrame = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsButtonDown = false;
        WasButtonReleasedLastFrame = true;
    }
}

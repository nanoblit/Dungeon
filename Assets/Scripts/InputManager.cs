using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    private ButtonHandler _goLeftButton;
    private ButtonHandler _goRightButton;
    private ButtonHandler _jumpButton;

    public static InputManager I { get; private set; }
    private void SetSingleton()
    {
        if (I == null)
        {
            I = this;
        }
        else if (I != this)
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        SetSingleton();

        _goLeftButton = GameObject.Find("Left Button").GetComponent<ButtonHandler>();
        _goRightButton = GameObject.Find("Right Button").GetComponent<ButtonHandler>();
        _jumpButton = GameObject.Find("Jump Button").GetComponent<ButtonHandler>();
    }

    public bool GoingLeft()
    {
        if (GameManager.I.IsPlayerInControl) return Input.GetKey(KeyCode.LeftArrow) || _goLeftButton.IsButtonDown;
        return false;
    }

    public bool GoingRight()
    {
        if (GameManager.I.IsPlayerInControl) return Input.GetKey(KeyCode.RightArrow) || _goRightButton.IsButtonDown;
        return false;
    }

    public bool Jumped()
    {
        if (GameManager.I.IsPlayerInControl) return Input.GetKeyDown(KeyCode.UpArrow) || _jumpButton.WasButtonPressedLastFrame;
        return false;
    }

    public bool StoppedJumping()
    {
        if (GameManager.I.IsPlayerInControl) return Input.GetKeyUp(KeyCode.UpArrow) || _jumpButton.WasButtonReleasedLastFrame;
        return false;
    }
}

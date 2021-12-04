using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Player Input")]
public class InputSys : ScriptableObject, MoveActionSys.IGamePlayActions
{
    private MoveActionSys moveActionSys;

    public event UnityAction<Vector2> onMove = delegate {};
    public event UnityAction onStopMove = delegate {};
    public event UnityAction onFire = delegate {};
    public event UnityAction stopFire = delegate {};
    public event UnityAction onDoge = delegate {};
    public event UnityAction onOver = delegate {};

     void OnEnable()
    {
        moveActionSys = new MoveActionSys();
        this.moveActionSys.GamePlay.SetCallbacks(this);
    }
     void OnDisable()
     {
         this.DisEnablePlayInput();
     }

     public  void DisEnablePlayInput()
     {
         this.moveActionSys.Disable();
     }

    public  void EnableGamePlayInput()
    {
        this.moveActionSys.Enable();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (onMove != null)
            {
                onMove.Invoke(context.ReadValue<Vector2>());
            }
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            if (onStopMove != null)
            {
                onStopMove.Invoke();
            }
        }
    }

    public void OnFile(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (onFire != null)
            {
                onFire.Invoke();
            }
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            if (stopFire != null)
            {
                stopFire.Invoke();
            }
        }
    }

    public void OnDoge(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (onDoge != null)
            {
                onDoge.Invoke();
            }
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            if (onDoge != null)
            {
                onDoge.Invoke();
            }
        }
    }

    public void OnOver(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (onOver != null)
            {
                onOver.Invoke();
            }
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            if (onOver != null)
            {
                onOver.Invoke();
            }
        }
    }
}

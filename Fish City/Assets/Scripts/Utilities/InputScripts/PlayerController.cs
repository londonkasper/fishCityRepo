using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
   private Vector2 moveDirection = Vector2.zero;
    private bool jumpPressed = false;
    private bool interactPressed = false;
    private bool submitPressed = false;

    private bool clickPressed = false;

    private static PlayerController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }
        instance = this;
       
    }

    public static PlayerController GetInstance() 
    {
        return instance;
    }

    public void MovePressed(InputAction.CallbackContext context)
    {
        Debug.Log("movepressed");
        if (context.performed)
        {
            Debug.Log("context performed for move pressed");
            moveDirection = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            Debug.Log("context cancelled for move pressed");
            moveDirection = context.ReadValue<Vector2>();
        } 
    }

    public void JumpPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            jumpPressed = true;
        }
        else if (context.canceled)
        {
            jumpPressed = false;
        }
    }

    public void InteractButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactPressed = true;
        }
        else if (context.canceled)
        {
            interactPressed = false;
        } 
    }

    public void SubmitPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            submitPressed = true;
        }
        else if (context.canceled)
        {
            submitPressed = false;
        } 
    }

      public void ClickPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            clickPressed = true;
        }
        else if (context.canceled)
        {
            clickPressed = false;
        } 
    }
    public Vector2 GetMoveDirection() 
    {
        return moveDirection;
    }

    // for any of the below 'Get' methods, if we're getting it then we're also using it,
    // which means we should set it to false so that it can't be used again until actually
    // pressed again.

    public bool GetJumpPressed() 
    {
        bool result = jumpPressed;
        jumpPressed = false;
        return result;
    }

    public bool GetInteractPressed() 
    {
        bool result = interactPressed;
        interactPressed = false;
        return result;
    }

    public bool GetSubmitPressed() 
    {
        bool result = submitPressed;
        submitPressed = false;
        return result;
    }
    public bool GetClickPressed() 
    {
        bool result = clickPressed;
        clickPressed = false;
        return result;
    }

    public void RegisterSubmitPressed() 
    {
        submitPressed = false;
    }
    public void RegisterClickPressed() 
    {
        clickPressed = false;
    }

}

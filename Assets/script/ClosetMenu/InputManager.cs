using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{
    public delegate void StartTouch(Vector2 postion, float time);
    public event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector2 postion, float time);
    public event EndTouch OnEndTouch;

    PlayerControls playerControls;
    private Camera mainCamera;

    private void Awake()
    {
        playerControls = new PlayerControls();
        mainCamera = Camera.main;
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Start()
    {
        playerControls.PlayerControl.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        playerControls.PlayerControl.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
    }

    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        Debug.Log("EndTouchPrimary");
        if (OnEndTouch != null)
        {
            Vector2 inputVector2 = playerControls.PlayerControl.PrimaryPosition.ReadValue<Vector2>();
            Vector3 inputVector3 = ScreenToWorld(mainCamera, inputVector2);
            OnEndTouch(inputVector3, (float)context.startTime);
        }
    }

    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        Debug.Log("StartTouchPrimary");
        if (OnStartTouch != null)
        {
            Vector2 inputVector2 = playerControls.PlayerControl.PrimaryPosition.ReadValue<Vector2>();
            Vector3 inputVector3 = ScreenToWorld(mainCamera, inputVector2);
            OnStartTouch(inputVector3, (float)context.startTime);
        }
    }

    private Vector3 ScreenToWorld(Camera camera, Vector3 position)
    {
        position.z = camera.nearClipPlane;
        return camera.ScreenToWorldPoint(position);
    }
}


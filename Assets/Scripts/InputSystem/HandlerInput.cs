using System;
using UnityEngine;

public class HandlerInput {
    private Controls _controls;
    private float _differenceTime;
    public event Action UpButtonEvent;
    public event Action DownButtonEvent;
    public event Action<Vector2> MoveMouseEvent;
    
    public void Initialize() {
        _controls = new Controls();
        _controls.MouseControl.Enable();
        Subscribe();
    }

    private void OnMoveMouse(Vector2 position) {
        MoveMouseEvent?.Invoke(position);
    }

    private void OnDownButton() {
        DownButtonEvent?.Invoke();
    }
    private void OnUpButton() {
        UpButtonEvent?.Invoke();
    }
    
    private void Subscribe() {
        _controls.MouseControl.ButtonLeft.started += context => { OnDownButton(); };
        _controls.MouseControl.ButtonLeft.canceled += context => { OnUpButton(); };
        _controls.MouseControl.MoveMouse.performed += context => { OnMoveMouse(context.ReadValue<Vector2>()); }; ;
    }

    public void UnSubscribe() {
        _controls.MouseControl.ButtonLeft.started -= context => { OnDownButton(); };
        _controls.MouseControl.ButtonLeft.canceled -= context => { OnUpButton(); };
        _controls.MouseControl.MoveMouse.performed -= context => { OnMoveMouse(context.ReadValue<Vector2>()); }; ;
    }
}
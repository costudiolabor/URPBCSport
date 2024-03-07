using System;
using UnityEngine;

public class Kicker {
    private HandlerMouse handlerMouse = new ();
    public event Action<Vector2, float> UpButtonEvent;
    
    private bool startTap;
    private Vector2 startPosition;
    private Vector2 endPosition;
    
    public void Initialize() {
        handlerMouse.Initialize();
        Subscribe();
    }
    
    private void OnUpButton() {
        float distance = Vector2.Distance(startPosition, endPosition);
        Vector2 direction = startPosition - endPosition;
        direction = direction.normalized;
        Debug.Log("direction " + direction);
        UpButtonEvent?.Invoke(direction, distance);
    }
    
    private void MoveMouse(Vector2 position) {
        if (startTap) {
            startTap = false;
            startPosition = position;
            Debug.Log("startPosition " + position);
        }
        endPosition = position;
    }
    
    private void OnDownButton() {
        startTap = true;
        Debug.Log("startTap " +   startTap);
    }
    
    private void Subscribe() {
        handlerMouse.UpButtonEvent += OnUpButton;
        handlerMouse.DownButtonEvent += OnDownButton;
        handlerMouse.MoveMouseEvent += MoveMouse;
    }

    public void UnSubscribe() {
        handlerMouse.UpButtonEvent -= OnUpButton;
        handlerMouse.DownButtonEvent -= OnDownButton;
        handlerMouse.MoveMouseEvent -= MoveMouse;
    }
}

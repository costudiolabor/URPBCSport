using System;
using UnityEngine;

public class Kicker {
    private readonly HandlerInput _handlerInput = new ();
    public event Action<Vector2, float> MoveMouseEvent;
    public event Action<Vector2, float> UpButtonEvent;
    
    private bool startTap;
    private Vector2 startPosition;
    private Vector2 endPosition;

    private Vector2 direction;
    private float distance;
    
    public void Initialize() {
        _handlerInput.Initialize();
        Subscribe();
    }
    
    private void OnUpButton() => UpButtonEvent?.Invoke(direction, distance);
    
    private void MoveInput(Vector2 position) {
        if (startTap) {
            startTap = false;
            startPosition = position;
        }
        endPosition = position;
        direction = (startPosition - endPosition).normalized;
        distance = Vector2.Distance(startPosition, endPosition);
        MoveMouseEvent?.Invoke(direction, distance);
    }
    
    private void OnDownButton() => startTap = true;
    private void Subscribe() {
        _handlerInput.UpButtonEvent += OnUpButton;
        _handlerInput.DownButtonEvent += OnDownButton;
        _handlerInput.MoveMouseEvent += MoveInput;
    }

    public void UnSubscribe() {
        _handlerInput.UpButtonEvent -= OnUpButton;
        _handlerInput.DownButtonEvent -= OnDownButton;
        _handlerInput.MoveMouseEvent -= MoveInput;
        _handlerInput.UnSubscribe();
    }
}

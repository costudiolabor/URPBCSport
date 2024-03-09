using System;
using UnityEngine;

public class Goal : MonoBehaviour {
    public event Action GoalEvent;
    private void OnCollisionEnter(Collision collision) {
        Debug.Log("trigger");
        var isBall = collision.gameObject.TryGetComponent(out Ball ball);
        if (isBall == false) return;
        Debug.Log("Ball");
        if (ball.isActive == false) return;
        ball.isActive = false;
        GoalEvent?.Invoke();
    }
}

using System;
using UnityEngine;

public class Boots : MonoBehaviour {
    [SerializeField] private Vector2 direction;
    [SerializeField] private float distance = 1.0f;
    public event Action KickEvent;
    public void SetParametrs(Vector2 direction, float distance) {
        this.direction = direction;
        this.distance += distance;
    }
    private void OnTriggerEnter(Collider other) {
        bool isBall = other.TryGetComponent(out Ball ball);
        //Debug.Log(" Collision");
        //Debug.Log(ball);
        if (isBall) {
            KickEvent?.Invoke();
            ball.Kick(direction, distance);
        }
    }
}

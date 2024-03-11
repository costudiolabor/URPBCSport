using System;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public event Action GoalEvent;
    
    private void OnCollisionEnter(Collision collision) {
        Debug.Log("trigger");
        var isBall = collision.gameObject.TryGetComponent(out BallPenalty ball);
        if (isBall == false) return;
        Debug.Log("Ball");
        if (ball.isActive == false) return;
        audioSource.Play();
        ball.isActive = false;
        GoalEvent?.Invoke();
    }
    
}

using System;
using System.Collections;
using UnityEngine;

public class GateView : View {
    [SerializeField] private PlayerPenalty playerPenalty;
    [SerializeField] private GoalKeeper goalKeeper;
    [SerializeField] private Transform parentBall;
    [SerializeField] private float timeSpawn = 3.0f;
    public event Action GetBallEvent, IdleEvent, GoalEvent;

    public void Initialize() {
        goalKeeper.Initialize();
        playerPenalty.IdleEvent += () => { IdleEvent?.Invoke(); };
    }
   
    public Transform GetParentBall() => parentBall;
    public void MoveKick(Vector2 direction, float distance) {
        playerPenalty.MoveKick(direction, distance);
        StartCoroutine(TimerSpawn());
    }
    
    private IEnumerator TimerSpawn() {
         yield return new WaitForSeconds(timeSpawn);
         GetBallEvent?.Invoke();
     }

    private void OnTriggerEnter(Collider other) {
       // Debug.Log("trigger");
       var isBall = other.TryGetComponent(out Ball ball);
       if (isBall == false) return;
       //Debug.LogError("Ball");
       if (ball.isActive == false) return;
       ball.isActive = false;
       GoalEvent?.Invoke();
    }
}

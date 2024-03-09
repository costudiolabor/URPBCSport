using System;
using System.Collections;
using UnityEngine;

public class GateView : View {
    [SerializeField] private Goal goal;
    [SerializeField] private PlayerPenalty playerPenalty;
    [SerializeField] private GoalKeeper goalKeeper;
    [SerializeField] private Transform parentBall;
    [SerializeField] private float timeSpawn = 3.0f;
    public event Action GetBallEvent, IdleEvent, GoalEvent;
    public void Initialize() {
        goalKeeper.Initialize();
        playerPenalty.IdleEvent += () => { IdleEvent?.Invoke(); };
        goal.GoalEvent += () => { GoalEvent?.Invoke(); };
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

    private void OnDestroy() {
        playerPenalty.IdleEvent -= () => { IdleEvent?.Invoke(); };
        goal.GoalEvent -= () => { GoalEvent?.Invoke(); };
    }
}

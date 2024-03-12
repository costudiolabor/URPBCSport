using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GateView : View {
    [SerializeField] private Goal goal;
    [SerializeField] private PlayerPenalty playerPenalty;
    [SerializeField] private GoalKeeper goalKeeper;
    [SerializeField] private Transform parentBall;
    [SerializeField] private ActivedEffects activedEffects;
    [SerializeField] private float timeSpawn = 3.0f;
    public event Action GetBallEvent, IdleEvent, GoalEvent;
    public event Action KickEvent;
    public void Initialize() {
        goalKeeper.Initialize();
        Subscribe();
       
    }
    public void ShowEffects() => activedEffects.Show();
    public Transform GetParentBall() => parentBall;
    
    public void MoveKick(Vector2 direction, float distance) {
        playerPenalty.MoveKick(direction, distance);
        StartCoroutine(TimerSpawn());
    }
    
    private void OnKick() {
        KickEvent?.Invoke();
    }
    
    private IEnumerator TimerSpawn() {
         yield return new WaitForSeconds(timeSpawn);
         GetBallEvent?.Invoke();
    }

    private void Subscribe() {
        playerPenalty.IdleEvent += () => { IdleEvent?.Invoke(); };
        playerPenalty.KickEvent += OnKick;
        goal.GoalEvent += () => { GoalEvent?.Invoke(); };
    }  
    
    private void UnSubscribe() {
        playerPenalty.IdleEvent -= () => { IdleEvent?.Invoke(); };
        playerPenalty.KickEvent -= OnKick;
        goal.GoalEvent -= () => { GoalEvent?.Invoke(); };
    }
    
    private void OnDestroy() {
        UnSubscribe();
    }
}

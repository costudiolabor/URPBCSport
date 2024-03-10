using System;
using UnityEngine;

[Serializable]
public class Gate : ViewOperator<GateView> {
    [SerializeField] private SpawnerBall spawnerBall;
    private Ball _ball;
    private Transform _parentBall;
    public event Action<Vector2, float> MoveKickEvent;  
    public event Action GoalEvent;  
    public void Initialize() {
        _parentBall = view.GetParentBall();
        spawnerBall.SetParentBall(_parentBall);
        Subscribe();
    }
    public void SetPositionObject(Vector3 position) {
        view.transform.position = position;
        Debug.Log("PositionObject " + position);
    }

    public Transform GetParentBall() => _parentBall;
    
    public void Open() {
        view.Open();
        view.Initialize();
        SpawnBall();
        OnSpawnBall();
    }
    private void SpawnBall() {
        _ball = spawnerBall.GetBall();
        view.IdleEvent += OnSpawnBall;
    }
    private void OnSpawnBall() => MoveKickEvent += OnMoveKick;
    private void OnMoveKick(Vector2 direction, float distance) {
        view.MoveKick(direction, distance);
        MoveKickEvent -= OnMoveKick;
        view.IdleEvent -= OnSpawnBall;
    }
    public void Close() => view.Close();
    public void MoveKick(Vector2 direction, float distance) {
        MoveKickEvent?.Invoke(direction, distance);
    }
    private void Goal() => GoalEvent?.Invoke();
    
    private void Subscribe() {
        view.GetBallEvent += SpawnBall;
        view.GoalEvent += Goal;
    }  
    
    public void UnSubscribe() {
        view.GetBallEvent -= SpawnBall;
        view.GoalEvent -= Goal;
    }

}

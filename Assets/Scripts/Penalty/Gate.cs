using System;
using UnityEngine;

[Serializable]
public class Gate : ViewOperator<GateView> {
   [SerializeField] private SpawnerBall spawnerBall;
    private BallPenalty _ballPenalty;
    private Transform _parentBall;
    private float _distance;
    private Vector2 _direction;
    public event Action<Vector2, float> MoveKickEvent;  
    public event Action GoalEvent;  
    public void Initialize() {
        _parentBall = view.GetParentBall();
        spawnerBall.SetParentBall(_parentBall);
        Subscribe();
    }
    // public void SetPositionObject(Vector3 position) {
    //     view.transform.position = position;
    // }
    
    public void SetPositionObject(Vector3 position, Transform target) {
        view.transform.position = position;
        TurnOnTarget(target);
    }

    private void TurnOnTarget(Transform target) {
        Transform viewTransform = view.transform;
        viewTransform.LookAt(target);
        viewTransform.eulerAngles = new Vector3(0, viewTransform.eulerAngles.y,0);
    }

    public Transform GetParentBall() => _parentBall;
    
    public void Open() {
        view.Open();
        view.Initialize();
        SpawnBall();
        OnSpawnBall();
    }
    private void SpawnBall() {
        _ballPenalty = spawnerBall.GetBallPenalty();
        view.IdleEvent += OnSpawnBall;
    }
    private void OnSpawnBall() => MoveKickEvent += OnMoveKick;
    private void OnMoveKick(Vector2 direction, float distance) {
        _direction = direction;
        _distance = distance;
        
        view.MoveKick(direction, distance);
        MoveKickEvent -= OnMoveKick;
        view.IdleEvent -= OnSpawnBall;
    }
    
    private void OnKick() {
        _ballPenalty.Kick(_direction, _distance);
    }
    
    public void Close() => view.Close();
    public void MoveKick(Vector2 direction, float distance) {
        MoveKickEvent?.Invoke(direction, distance);
    }
    private void Goal() {
        view.ShowEffects();
        GoalEvent?.Invoke();
    }

    private void Subscribe() {
        view.GetBallEvent += SpawnBall;
        view.GoalEvent += Goal;
        view.KickEvent += OnKick;
    }  
    
    public void UnSubscribe() {
        view.GetBallEvent -= SpawnBall;
        view.GoalEvent -= Goal;
        view.KickEvent -= OnKick;
    }

}

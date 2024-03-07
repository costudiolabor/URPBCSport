using System;

[Serializable]
public class Poses : ViewOperator<PosesView> {
    public event Action IdleEvent, KickBallEvent, BallIdleEvent, BallWaitEvent, PhotoEvent;
    public void Initialize() {
        view.Initialize();
        Subscribe();
    }
    private void OnIdle() => IdleEvent?.Invoke();
    private void OnKickBall() => KickBallEvent?.Invoke();
    private void BallIdle() => BallWaitEvent?.Invoke();
    private void BallWait() => BallIdleEvent?.Invoke();
    private void Photo() => PhotoEvent?.Invoke();
    public void Open() => view.Open();
    public void Close() => view.Close();
    private void Subscribe() {
        view.IdleEvent += OnIdle;
        view.KickBallEvent += OnKickBall;
        view.BallIdleEvent += BallIdle;
        view.BallWaitEvent += BallWait;
        view.PhotoEvent += Photo;
    }  
    
    public void UnSubscribe() {
        view.IdleEvent -= OnIdle;
        view.KickBallEvent -= OnKickBall;
        view.BallIdleEvent -= BallIdle;
        view.BallWaitEvent -= BallWait;
        view.PhotoEvent -= Photo;
    }
}
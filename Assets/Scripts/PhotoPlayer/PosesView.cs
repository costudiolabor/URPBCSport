using System;
using UnityEngine;
using UnityEngine.UI;

public class PosesView : View {
    [SerializeField] private Toggle toggleKickBall;
    [SerializeField] private Toggle toggleBallWaiting;
    [SerializeField] private Toggle toggleIdle;
    [SerializeField] private Toggle toggleBallIdle;
    [SerializeField] private Button buttonPhoto;

    public event Action IdleEvent, KickBallEvent, BallIdleEvent, BallWaitEvent, PhotoEvent;
    
    //private void Awake() => Initialize();
    
    public void Initialize() {
        toggleKickBall.onValueChanged.AddListener(OnKickBall);
        toggleBallWaiting.onValueChanged.AddListener(OnBallWaiting);
        toggleIdle.onValueChanged.AddListener(OnIdle);
        toggleBallIdle.onValueChanged.AddListener(OnBallIdle);
        buttonPhoto.onClick.AddListener(OnPhoto);
    }
    private void OnKickBall(bool state) => KickBallEvent?.Invoke();
    private void OnBallWaiting(bool state) => BallWaitEvent?.Invoke();
    private void OnIdle(bool state) => IdleEvent?.Invoke();
    private void OnBallIdle(bool state) => BallIdleEvent?.Invoke();
    private void OnPhoto() => PhotoEvent?.Invoke();
}
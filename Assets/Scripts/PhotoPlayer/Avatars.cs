using System;
using UnityEngine;

[Serializable]
public class Avatars: ViewOperator<AvatarsView> {
    public void Open() => view.Open();
    public void Close() => view.Close();

    public void Initialize() {
        view.Initialize();
    }
    public void SetPositionPlayer(Vector3 position) {
        view.transform.position = position;
        KickBall();
    }
    
    public void Idle() => view.Idle();
    public void KickBall() => view.KickBall();
    public void BallIdle() => view.BallIdle();
    public void BallWaitWaiting() => view.BallWaiting();
}

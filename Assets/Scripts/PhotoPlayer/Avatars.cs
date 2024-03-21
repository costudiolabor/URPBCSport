using System;
using UnityEngine;

[Serializable]
public class Avatars: ViewOperator<AvatarsView> {
    public void Open() => view.Open();
    public void Close() => view.Close();

    public void Initialize() {
        view.Initialize();
    }
    
    public void SetPositionObject(Vector3 position, Transform target) {
        view.transform.position = position;
        TurnOnTarget(target);
        KickBall(); 
    }

    private void TurnOnTarget(Transform target) {
        Transform viewTransform = view.transform;
        viewTransform.LookAt(target);
        viewTransform.eulerAngles = new Vector3(0, viewTransform.eulerAngles.y,0);
    }
    
    public void Idle() => view.Idle();
    public void KickBall() => view.KickBall();
    public void BallIdle() => view.BallIdle();
    public void BallWaitWaiting() => view.BallWaiting();
}

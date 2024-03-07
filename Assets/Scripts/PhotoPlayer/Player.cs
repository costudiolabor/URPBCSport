using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Player : ViewOperator<PlayerView> {
    public void Open() => view.Open();
    public void Close() => view.Close();
    public void SetPositionPlayer(Vector3 position) {
        Idle();
        view.transform.position = position;
    }
    public void Idle() => view.Idle();
    public void KickBall() => view.KickBall();
    public void LegInBall() => view.LegOnBall();
    public void FingerInUp() => view.FingerInUp();
    public void Initialize() {  Idle(); }
}

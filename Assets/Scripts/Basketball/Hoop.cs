using System;
using UnityEngine;

[Serializable]
public class Hoop : ViewOperator<HoopView> {
    public event Action HitEvent;
    public void Initialize() { Subscribe(); }
    public void SetScoreBoard(int score) => view.SetScoreBoard(score);
    public void ResetRing() { view.NetEvent -= OnNet; }
    public void Open() {
        view.Open();
        view.Initialize();
    }
    private void OnRing() { view.NetEvent += OnNet; }
    private void OnNet() {
            view.ShowEffects();
            HitEvent?.Invoke();
    }
    public void SetPositionObject(Vector3 position) { view.transform.position = position; }
    private void Subscribe() { view.RingEvent += OnRing; }  
    private void UnSubscribe() {
        view.RingEvent -= OnRing;
        view.NetEvent -= OnNet;
    }
    private void OnDestroy() { UnSubscribe(); }
}

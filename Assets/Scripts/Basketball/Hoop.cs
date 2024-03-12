using System;
using UnityEngine;

[Serializable]
public class Hoop : ViewOperator<HoopView> {
    public event Action HitEvent;

    private bool isRing;
    
    public void Initialize() {
        Subscribe();
    }

    public void SetScoreBoard(int score) => view.SetScoreBoard(score);
    
    public void ResetRing() => isRing = false;
    
    public void Open() {
        view.Open();
        view.Initialize();
    }

    private void OnRing() {
        Debug.Log("OnRing ");
        isRing = true;
    }

    private void OnNet() {
        if (isRing) {
            view.ShowEffects();
            HitEvent?.Invoke();
        }      
    }
    
    public void SetPositionObject(Vector3 position) {
        view.transform.position = position;
        Debug.Log("PositionObject " + position);
    }
    
    private void Subscribe() {
        view.RingEvent += OnRing;
        view.NetEvent += OnNet;
    }  
    
    private void UnSubscribe() {
        view.RingEvent -= OnRing;
        view.NetEvent -= OnNet;
    }
    
    private void OnDestroy() {
        UnSubscribe();
    }
}

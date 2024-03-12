using System;
using TMPro;
using UnityEngine;

public class HoopView : View {
    [SerializeField] private TMP_Text textTablo;
    [SerializeField] private ActivedTrigger ringTrigger;
    [SerializeField] private ActivedTrigger netTrigger;
    [SerializeField] private ActivedEffects activedEffects;
    public event Action RingEvent, NetEvent;
    
    public void Initialize() {
        Subscribe();
    }

    public void SetScoreBoard(int score) => textTablo.text = score.ToString();

    public void ShowEffects() => activedEffects.Show();
    
    private void Subscribe() {
        ringTrigger.ActivedEvent += () => { RingEvent?.Invoke(); };
        netTrigger.ActivedEvent += () => { NetEvent?.Invoke(); };
    }  
    
    private void UnSubscribe() {
        ringTrigger.ActivedEvent -= () => { RingEvent?.Invoke(); };
        netTrigger.ActivedEvent -= () => { NetEvent?.Invoke(); };
    }
    
    private void OnDestroy() {
        UnSubscribe();
    }
}

using System;
using UnityEngine;

[Serializable]
public class ScoreInfo : ViewOperator<ScoreInfoView> {
    [SerializeField] private int countScoreGoal = 1;
    private int _currentScoreGoal;
    
    public void Initialize() {
      view.Initialize();
    }

    public void SetGoal() {
        _currentScoreGoal += countScoreGoal;
        view.SetCurrentCount(_currentScoreGoal.ToString());
    }

    public void SetRecord(string text) => view.SetRecord(text);
    
}

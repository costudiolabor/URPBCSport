using System;
using UnityEngine;

[Serializable]
public class ScoreInfo : ViewOperator<ScoreInfoView> {
    [SerializeField] private  int countScoreGoal = 1;
    private int _currentScoreGoal;
    private int _scoreRecord;
    private GameData _gameData = new();
    
    public void Initialize() {
        _scoreRecord = _gameData.LoadRecord();
        SetRecord(_scoreRecord.ToString());
        view.Initialize();
    }

    public void SetGoal() {
        _currentScoreGoal += countScoreGoal;
        view.SetCurrentCount(_currentScoreGoal.ToString());
    }

    public void SetRecord(string text) => view.SetRecord(text);

    public void SaveRecord() { if (_currentScoreGoal > _scoreRecord) _gameData.SaveRecord(_currentScoreGoal); }
}

using System;
using UnityEngine;

[Serializable]
public class ScoreInfo : ViewOperator<ScoreInfoView> {
    [SerializeField] private  int countScoreGoal = 1;
    private int _currentScoreGoal;
    private int _bestScore;
    private GameData _gameData = new();
    
    public void Initialize() {
        _bestScore = _gameData.LoadBestScore();
        SetBestScore(_bestScore.ToString());
        view.Initialize();
    }

    public void SetGoal() {
        _currentScoreGoal += countScoreGoal;
        view.SetCurrentScore(_currentScoreGoal.ToString());
    }

    public void SetBestScore(string text) => view.SetBestScore(text);

    public void SaveBestScore() { if (_currentScoreGoal > _bestScore) _gameData.SaveBestScore(_currentScoreGoal); }
}

using System;
using UnityEngine;

[Serializable]
public class ScoreInfo : ViewOperator<ScoreInfoView> {
    private int _currentScore;
    private int _bestScore;
    [SerializeField] private GameData _gameData = new();
    
    public void Initialize() {
        _bestScore = _gameData.LoadBestScore();
        SetBestScore(_bestScore.ToString());
        view.Initialize();
    }

    public int GetScore() => _currentScore; 
    
    public void SetGoal(int score) {
        _currentScore += score;
        view.SetCurrentScore(_currentScore.ToString());
    }

    public void SetBestScore(string text) => view.SetBestScore(text);

    public void SaveBestScore() { if (_currentScore > _bestScore) _gameData.SaveBestScore(_currentScore); }
}

using System;
using UnityEngine;

[Serializable]
public class GameData : IStorageService {
    [SerializeField] private string bestScore = "BestScore";
    private bool CheckKey(string key) => PlayerPrefs.HasKey(key);
    public void SaveBestScore(int value) {
        PlayerPrefs.SetInt(bestScore, value);
        PlayerPrefs.Save();
    }
    public int LoadBestScore() {
        var result = 0;
        if (CheckKey(bestScore)) result = PlayerPrefs.GetInt(bestScore);
        return result;
    }
}

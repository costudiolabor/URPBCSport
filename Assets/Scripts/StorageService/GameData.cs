using System;
using UnityEngine;

[Serializable]
public class GameData : IStorageService {
    private const string BestScore = "record";
    private bool CheckKey(string key) => PlayerPrefs.HasKey(key);
    public void SaveBestScore(int value) {
        PlayerPrefs.SetInt(BestScore, value);
        PlayerPrefs.Save();
    }
    public int LoadBestScore() {
        var result = 0;
        if (CheckKey(BestScore)) result = PlayerPrefs.GetInt(BestScore);
        return result;
    }
}

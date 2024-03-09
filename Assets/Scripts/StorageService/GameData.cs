using System;
using UnityEngine;

[Serializable]
public class GameData : IStorageService {
    private const string ScoreRecord = "record";
    private bool CheckKey(string key) => PlayerPrefs.HasKey(key);
    public void SaveRecord(int value) {
        PlayerPrefs.SetInt(ScoreRecord, value);
        PlayerPrefs.Save();
    }
    public int LoadRecord() {
        var result = 0;
        if (CheckKey(ScoreRecord)) result = PlayerPrefs.GetInt(ScoreRecord);
        return result;
    }
}

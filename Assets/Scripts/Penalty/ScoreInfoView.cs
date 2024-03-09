using TMPro;
using UnityEngine;

public class ScoreInfoView : View {
    [SerializeField] private TMP_Text textCurrentCount;
    [SerializeField] private TMP_Text textRecord;
    
    public void Initialize() { }

    public void SetCurrentCount(string text) => textCurrentCount.text = text;
    public void SetRecord(string text) => textRecord.text = text;
}

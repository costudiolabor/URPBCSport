using TMPro;
using UnityEngine;

public class ScoreInfoView : View {
    [SerializeField] private TMP_Text textCurrentScore;
    [SerializeField] private TMP_Text textBestScore;
    
    public void Initialize() { }

    public void SetCurrentScore(string text) => textCurrentScore.text = text;
    public void SetBestScore(string text) => textBestScore.text = text;
}

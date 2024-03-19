using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAR_3DView : View {
    [SerializeField] private Button buttonMode;
    [SerializeField] private TMP_Text textButton;
    [SerializeField] private string textAR;
    [SerializeField] private string text3D;

    private bool isAR;
    public event Action<bool> ChangeEvent;
    public void Initialize() {
        buttonMode.onClick.AddListener(OnChange);
        textButton.text = text3D;
        isAR = true;
    }

    private void OnChange() {
        if (isAR) {
            isAR = false;
            textButton.text = textAR;
        }
        else {
            isAR = true;
            textButton.text = text3D;
        }
        ChangeEvent?.Invoke(isAR);
    }
}

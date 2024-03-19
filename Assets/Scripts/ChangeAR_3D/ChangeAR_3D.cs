using UnityEngine;
using System;

[Serializable]
public class ChangeAR_3D  : ViewOperator<ChangeAR_3DView> {
    [SerializeField] private GameObject cameraAR;
    [SerializeField] private GameObject content3D;
    
    public event Action<bool> ChangeEvent;
    public void Initialize() {
        view.Initialize();
        Subscribe();
        content3D.SetActive(false);
    }
    private void OnChange(bool state) {
        ChangeEvent?.Invoke(state);
        cameraAR.SetActive(state);
        content3D.SetActive(!state);
    }
    
    public void Close() => view.Close();
    public void Open() => view.Open();
    private void Subscribe() => view.ChangeEvent += OnChange;
    public void UnSubscribe() => view.ChangeEvent -= OnChange;
}
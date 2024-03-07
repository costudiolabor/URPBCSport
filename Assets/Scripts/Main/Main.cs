using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class Main : ViewOperator<MainView> {
    [SerializeField] private int sceneMenu = 0;
    public void Initialize() {
        view.Initialize();
        Subscribe();
    }

    private void OnClose() => SceneManager.LoadScene(sceneMenu);
    private void Subscribe() => view.CloseEvent += OnClose;
    public void UnSubscribe() => view.CloseEvent -= OnClose;
    public void Close() => view.Close();
    public void Open() => view.Open();
}

using UnityEngine;

public class EntryMain : MonoBehaviour {
    [SerializeField] private Main main;
    [SerializeField] private ARObject arObject;
    
    private void Awake() { 
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Time.timeScale = 1.0f;
        main.CreateView();
        main.Initialize();
        
        arObject.CreateView();
        Subscribe();
    }
    
    private void OnDestroy() => UnSubscribe();

    private void Subscribe() {
      
    }  
    
    private void UnSubscribe() {
        main.UnSubscribe();
    }
}

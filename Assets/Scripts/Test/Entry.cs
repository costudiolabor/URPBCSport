using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Entry : MonoBehaviour {
    [SerializeField] private Main main;
    [SerializeField] private ARContent arContent;
    [SerializeField] private FinderTarget finderTarget; 
    [SerializeField] private ARObject arObject;
    
    private void Awake() { 
       Screen.sleepTimeout = SleepTimeout.NeverSleep;
       main.CreateView();
       main.Initialize();
       Time.timeScale = 1.0f;
       
       arObject.CreateViewClosed();
       arObject.Initialize();
       
       ARRaycastManager arRaycastManager = arContent.GetARRaycastManager();
       finderTarget.CreateView();
       finderTarget.SetRayCastManager(arRaycastManager);
       finderTarget.Initialize();
       
       Subscribe();
    }

    private void SetPositionObject(Vector3 position) {
        arObject.SetPositionPlayer(position);
        arObject.Open();
        
        arContent.DisableARPlaneManager();
        arContent.DisableARRayCastManager();
        
        finderTarget.Close();
    }
    
    private void OnDestroy() => UnSubscribe();

    private void Subscribe() {
        finderTarget.SetPositionEvent += SetPositionObject;
    }  
    
    private void UnSubscribe() {
        main.UnSubscribe();
        finderTarget.UnSubscribe();
        finderTarget.SetPositionEvent -= SetPositionObject;
    }
}

using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Entry : MonoBehaviour {
    [SerializeField] private Main main;
    [SerializeField] private ChangeAR_3D changeAR3D;
    [SerializeField] private ARComponents arComponents;
    [SerializeField] private FinderTarget finderTarget; 
    [SerializeField] private ARObject arObject;
    
    private void Awake() { 
       Screen.sleepTimeout = SleepTimeout.NeverSleep;
       main.CreateView();
       main.Initialize();
       
       changeAR3D.CreateViewClosed();
       changeAR3D.Initialize();
       
       Time.timeScale = 1.0f;
       
       arObject.CreateViewClosed();
       arObject.Initialize();
       
       ARRaycastManager arRaycastManager = arComponents.GetARRaycastManager();
       finderTarget.CreateView();
       finderTarget.SetRayCastManager(arRaycastManager);
       finderTarget.Initialize();
       
       Subscribe();
    }

    private void SetPositionObject(Vector3 position) {
        arObject.SetPositionPlayer(position);
        arObject.Open();
        
        arComponents.DisableARPlaneManager();
        arComponents.DisableARRayCastManager();
        
        finderTarget.Close();
        changeAR3D.Open();
        changeAR3D.ChangeEvent += OnChange;
    }
    
    private void OnChange(bool state) {
        arObject.SetState(state);
    }
    
    private void OnDestroy() => UnSubscribe();

    private void Subscribe() {
        finderTarget.SetPositionEvent += SetPositionObject;
    }  
    
    private void UnSubscribe() {
        main.UnSubscribe();
        changeAR3D.UnSubscribe();
        changeAR3D.ChangeEvent -= OnChange;
        finderTarget.UnSubscribe();
        finderTarget.SetPositionEvent -= SetPositionObject;
    }
}

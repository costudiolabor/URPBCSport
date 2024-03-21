using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class EntryStadium : MonoBehaviour {
    [SerializeField] private Main main;
    [SerializeField] private ARComponents arComponents;
    [SerializeField] private FinderTarget finderTarget; 
    [SerializeField] private ARObject arObject;
    
    private void Awake() { 
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        main.CreateView();
        main.Initialize();
        
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
        Transform target = arComponents.GetMainCamera();
        arObject.SetPositionObject(position, target);
        arObject.Open();
        
        arComponents.DisableARPlaneManager();
        arComponents.DisableARRayCastManager();
        
        finderTarget.Close();
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
        finderTarget.UnSubscribe();
        finderTarget.SetPositionEvent -= SetPositionObject;
    }
}

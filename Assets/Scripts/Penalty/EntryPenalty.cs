using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class EntryPenalty : MonoBehaviour {
    [SerializeField] private Main main;
    [SerializeField] private ARContent arContent;
    [SerializeField] private FinderTarget finderTarget;
    [SerializeField] private Gate gate;
    
    private Kicker kicker = new Kicker();
    private void Awake() { 
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        main.CreateView();
        main.Initialize();
        
        arContent.CreateView();
        ARRaycastManager arRaycastManager = arContent.GetARRaycastManager();
        
        finderTarget.CreateView();
        finderTarget.SetRayCastManager(arRaycastManager);
        finderTarget.Initialize();
        
        gate.CreateViewClosed();
        gate.Initialize();
      
        Subscribe();
    }

    private void SetPositionObject(Vector3 position) {
        gate.Open();
        gate.SetPositionObject(position);
        
        arContent.DisableARPlaneManager();
        arContent.DisableARRayCastManager();
        finderTarget.Close();
        
        kicker.Initialize();
        kicker.UpButtonEvent += OnUpButton;
    }
    
    private void OnUpButton(Vector2 direction, float distance) {
        gate.MoveKick(direction, distance);
    }

    private void Subscribe() {
        finderTarget.SetPositionEvent += SetPositionObject;
    }  
    
    private void UnSubscribe() {
        main.UnSubscribe();
        finderTarget.SetPositionEvent -= SetPositionObject;
        kicker.UpButtonEvent -= OnUpButton;
        kicker.UnSubscribe();
        gate.UnSubscribe();
    }
    
    private void OnDestroy() {
        UnSubscribe();
    }
}

using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class EntryPenalty : MonoBehaviour {
    [SerializeField] private Main main;
    [SerializeField] private ScoreInfo scoreInfo;
    [SerializeField] private ARComponents arComponents;
    [SerializeField] private FinderTarget finderTarget;
    [SerializeField] private Gate gate;
    
    private readonly Kicker _kicker = new Kicker();
    [SerializeField] private ShowDirection _showDirection = new ();
    
    private void Awake() { 
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Time.timeScale = 1.0f;
        main.CreateView();
        main.Initialize();
        
        scoreInfo.CreateView();
        scoreInfo.Initialize();
        
        ARRaycastManager arRaycastManager = arComponents.GetARRaycastManager();
        
        finderTarget.CreateView();
        finderTarget.SetRayCastManager(arRaycastManager);
        finderTarget.Initialize();
        
        gate.CreateViewClosed();
        gate.Initialize();
      
        Subscribe();
    }

    private void SetPositionObject(Vector3 position) {
        Transform target = arComponents.GetMainCamera();
        gate.Open();
        gate.SetPositionObject(position, target);
        //gate.SetPositionObject(position);
        
        arComponents.DisableARPlaneManager();
        arComponents.DisableARRayCastManager();
        finderTarget.Close();
        
        _kicker.Initialize();
        _kicker.UpButtonEvent += OnUpButton;
        
        _kicker.MoveMouseEvent += OnMoveMouse;
    }
    
    private void OnMoveMouse(float difference, Vector2 direction, float distance) {
        var parentBall = gate.GetParentBall();
        _showDirection.Show(difference, parentBall, direction, distance);
    }
    
    private void OnUpButton(Vector2 direction, float distance) {
        gate.MoveKick(direction, distance);
    }

    private void Goal() {
        const int scoreGoal = 1;
        scoreInfo.SetGoal(scoreGoal);
    }

    private void SaveBestScore() => scoreInfo.SaveBestScore();
    
    private void Subscribe() {
        finderTarget.SetPositionEvent += SetPositionObject;
        gate.GoalEvent += Goal;
    }  
    
    private void UnSubscribe() {
        main.UnSubscribe();
        finderTarget.SetPositionEvent -= SetPositionObject;
        gate.GoalEvent -= Goal;
        _kicker.UpButtonEvent -= OnUpButton;
        
        _kicker.MoveMouseEvent -= OnMoveMouse;
        
        _kicker.UnSubscribe();
        gate.UnSubscribe();
    }
    
    private void OnDestroy() {
        UnSubscribe();
        SaveBestScore();
    }
}
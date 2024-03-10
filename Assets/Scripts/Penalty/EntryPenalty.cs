using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.ARFoundation;

public class EntryPenalty : MonoBehaviour {
    [SerializeField] private Main main;
    [SerializeField] private ScoreInfo scoreInfo;
    [SerializeField] private ARContent arContent;
    [SerializeField] private FinderTarget finderTarget;
    [SerializeField] private Gate gate;
    
    private readonly Kicker _kicker = new Kicker();
    private void Awake() { 
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        main.CreateView();
        main.Initialize();
        
        scoreInfo.CreateView();
        scoreInfo.Initialize();
        
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
        
        _kicker.Initialize();
        _kicker.UpButtonEvent += OnUpButton;
        
        _kicker.MoveMouseEvent += OnMoveMouse;
    }

    private readonly ShowDirection _showDirection = new ();
    
    private void OnMoveMouse(Vector2 direction, float distance) {
        Vector3 ballPosition = gate.GetParentBall().position;
        _showDirection.Show(ballPosition, direction, distance);
    }
    
    private void OnUpButton(Vector2 direction, float distance) {
        gate.MoveKick(direction, distance);
    }

    private void Goal() {
        scoreInfo.SetGoal();
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
        
        _kicker.MoveMouseEvent += OnMoveMouse;
        
        _kicker.UnSubscribe();
        gate.UnSubscribe();
    }
    
    private void OnDestroy() {
        UnSubscribe();
        SaveBestScore();
    }
}

[System.Serializable]
public class ShowDirection {
    public void Show(Vector3 ballPosition, Vector2 direction, float distance) {
        distance /= 100;
        var targetPosition = new Vector3(direction.x, ballPosition.y, direction.y);
        targetPosition = (ballPosition + targetPosition) * distance;
        
        //Debug.Log("direction:" + direction + "  distance:" + distance);
        Debug.DrawLine(ballPosition, targetPosition, Color.red, 0.5f); 
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class EntryBasketball : MonoBehaviour {
    [SerializeField] private Main main;
    [SerializeField] private ScoreInfo scoreInfo;
    [SerializeField] private ARContent arContent;
    [SerializeField] private FinderTarget finderTarget;
    [SerializeField] private Hoop hoop;
    [SerializeField] private SpawnerBall spawnerBall;
    [SerializeField] private ShowDirection _showDirection = new ();
    [SerializeField] private BallBasketBall ballBasketball;
    [SerializeField] private Transform parentBall;
    
    [SerializeField] private float timeSpawn = 2.0f;
    
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

        hoop.CreateViewClosed();
        hoop.Initialize();
      
        Subscribe();
    }
    
    private void SetPositionObject(Vector3 position) {
        hoop.Open();
        hoop.SetPositionObject(position);
        
        arContent.DisableARPlaneManager();
        arContent.DisableARRayCastManager();
        
        finderTarget.Close();
        SpawnBall();
        
        _kicker.Initialize();
        _kicker.UpButtonEvent += OnUpButton;
        
        _kicker.MoveMouseEvent += OnMoveMouse;
    }
    
    private void SpawnBall() {
       ballBasketball = spawnerBall.GetBallBasketball();
    }
    
    private void OnMoveMouse(float difference, Vector2 direction, float distance) {
        parentBall = spawnerBall.GetParentBall();
        _showDirection.Show(difference, parentBall, direction, distance);
    }
    
    private void OnUpButton(Vector2 direction, float distance) {
        ballBasketball.Kick(direction, distance);
        StartCoroutine(TimerSpawn());
    }
    
    private void Goal() { scoreInfo.SetGoal(); }
    private void SaveBestScore() => scoreInfo.SaveBestScore();
    
    private void Subscribe() {
        finderTarget.SetPositionEvent += SetPositionObject;
    }  
    
    private void UnSubscribe() {
        main.UnSubscribe();
        finderTarget.SetPositionEvent -= SetPositionObject;
        
        _kicker.UpButtonEvent -= OnUpButton;
        _kicker.MoveMouseEvent -= OnMoveMouse;
        _kicker.UnSubscribe();
    }
    
    private void OnDestroy() {
        UnSubscribe();
        //SaveBestScore();
    }

    private IEnumerator TimerSpawn() {
        yield return new WaitForSeconds(timeSpawn);
        SpawnBall();
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class EntryBasketball : MonoBehaviour {
    [SerializeField] private Main main;
    [SerializeField] private ScoreInfo scoreInfo;
    [SerializeField] private ARComponents arComponents;
    [SerializeField] private FinderTarget finderTarget;
    [SerializeField] private Hoop hoop;
    [SerializeField] private SpawnerBall spawnerBall;
    [SerializeField] private ShowDirection _showDirection = new ();
    [SerializeField] private float timeSpawn = 2.0f;
    
    private BallBasketBall ballBasketball;
    private Transform parentBall;
    private readonly Kicker _kicker = new Kicker();

    private void Awake() {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        main.CreateView();
        main.Initialize();
        scoreInfo.CreateView();
        scoreInfo.Initialize();
        ARRaycastManager arRaycastManager = arComponents.GetARRaycastManager();
        finderTarget.CreateView();
        finderTarget.SetRayCastManager(arRaycastManager);
        finderTarget.Initialize();
        hoop.CreateViewClosed();
        hoop.Initialize();
        Subscribe();
    }
    
    private void SetPositionObject(Vector3 position) {
        Transform target = arComponents.GetMainCamera();
        hoop.Open();
        hoop.SetPositionObject(position, target);
        
        arComponents.DisableARPlaneManager();
        arComponents.DisableARRayCastManager();
        finderTarget.Close();
        _kicker.Initialize();
        SpawnBall();
    }
    
    private void SpawnBall() {
       ballBasketball = spawnerBall.GetBallBasketball();
       hoop.ResetRing();
       _kicker.UpButtonEvent += OnUpButton;
    }
    
    private void OnMoveMouse(float difference, Vector2 direction, float distance) {
        parentBall = spawnerBall.GetParentBall();
        _showDirection.Show(difference, parentBall, direction, distance);
    }
    
    private void OnUpButton(Vector2 direction, float distance) {
        _kicker.UpButtonEvent -= OnUpButton;
        ballBasketball.Kick(direction, distance);
        StartCoroutine(TimerSpawn());
    }

    private void Goal() {
        var scoreGoal = 1;
        scoreInfo.SetGoal(scoreGoal);
        scoreGoal = scoreInfo.GetScore();
        hoop.SetScoreBoard(scoreGoal);
    }
    private void SaveBestScore() => scoreInfo.SaveBestScore();
    
    private void Subscribe() {
        finderTarget.SetPositionEvent += SetPositionObject;
        hoop.HitEvent += Goal;
    }  
    
    private void UnSubscribe() {
        main.UnSubscribe();
        finderTarget.SetPositionEvent -= SetPositionObject;
        _kicker.UpButtonEvent -= OnUpButton;
        _kicker.MoveMouseEvent -= OnMoveMouse;
        _kicker.UnSubscribe();
        hoop.HitEvent -= Goal;
    }
    
    private void OnDestroy() {
        UnSubscribe();
        SaveBestScore();
    }

    private IEnumerator TimerSpawn() {
        yield return new WaitForSeconds(timeSpawn);
        SpawnBall();
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class EntryPhoto : MonoBehaviour {
    [SerializeField] private Main main;
    [SerializeField] private ARComponents arComponents;
    [SerializeField] private FinderTarget finderTarget; 
    [SerializeField] private Poses poses;
    [SerializeField] private Avatars avatars;
    [SerializeField] private ScreenShot screenShot;
    
    private void Start() { 
       Screen.sleepTimeout = SleepTimeout.NeverSleep;
       Time.timeScale = 1.0f;
       main.CreateView();
       main.Initialize();
       
       avatars.CreateViewClosed();
       avatars.Initialize();
       
       poses.CreateViewClosed();
       poses.Initialize();
       
       ARRaycastManager arRaycastManager = arComponents.GetARRaycastManager();
       finderTarget.CreateView();
       finderTarget.SetRayCastManager(arRaycastManager);
       finderTarget.Initialize();
       
       Subscribe();
    }

    private void SetPositionObject(Vector3 position) {
        Transform target = arComponents.GetMainCamera();
        avatars.SetPositionObject(position, target);
        avatars.Open();
        
        arComponents.DisableARPlaneManager();
        arComponents.DisableARRayCastManager();
        
        finderTarget.Close();
        poses.Open();
    }

    private event Action DoneScreenShotEvent;

    private void StartScreenShot() {
        CloseView();
        screenShot.GetScreenShot(DoneScreenShotEvent);
        //Application.CaptureScreenshot("Screenshot.png");
       // Application.CaptureScreenshot();
       Debug.Log("StartScreenShot");
       //ScreenCapture.CaptureScreenshot("Screenshot.png");
       //DoneScreenShot();
    }

    private void CloseView() {
        main.Close();
        poses.Close();
    }
    
    private void OpenView() {
        main.Open();
        poses.Open();
    }
    
    //private void DoneScreenShot(Texture2D texture) {
    
    private void DoneScreenShot() {
        OpenView();
        Debug.Log("DoneScreenShot");
        //rawImage.texture = texture;
    }
    
    private void OnDestroy() => UnSubscribe();

    private void Subscribe() {
        poses.IdleEvent += avatars.Idle;
        poses.KickBallEvent += avatars.KickBall;
        poses.BallIdleEvent += avatars.BallIdle;
        poses.BallWaitEvent += avatars.BallWaitWaiting;
        poses.PhotoEvent += StartScreenShot;
        DoneScreenShotEvent += DoneScreenShot;
            
        finderTarget.SetPositionEvent += SetPositionObject;
    }  
    
    private void UnSubscribe() {
        main.UnSubscribe();
        poses.UnSubscribe();
        
        poses.IdleEvent -= avatars.Idle;
        poses.KickBallEvent -= avatars.KickBall;
        poses.BallIdleEvent -= avatars.BallIdle;
        poses.BallWaitEvent -= avatars.BallWaitWaiting;
        poses.PhotoEvent -= StartScreenShot;
        DoneScreenShotEvent -= DoneScreenShot;
        
        finderTarget.UnSubscribe();
        finderTarget.SetPositionEvent -= SetPositionObject;
    }
}

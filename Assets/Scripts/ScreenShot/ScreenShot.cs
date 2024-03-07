using System;
using System.Collections;
using UnityEngine;

public class ScreenShot : MonoBehaviour {
    //public void GetScreenShot(Action<Texture2D> doneEvent) => StartCoroutine(Take(doneEvent));
    public void GetScreenShot(Action doneEvent) => StartCoroutine(Take(doneEvent));
    
    private IEnumerator Take(Action doneEvent){
        Debug.Log("StartSnapshot");
        yield return new WaitForEndOfFrame();
        ScreenCapture.CaptureScreenshot("Screenshot.png");
        doneEvent?.Invoke();
    }
    
    // public IEnumerator Take(Action<Texture2D> doneEvent){
    //     Debug.Log("StartSnapshot");
    //     var screenShot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    //     yield return new WaitForEndOfFrame();
    //     screenShot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
    //     screenShot.Apply();
    //     doneEvent?.Invoke(screenShot);
    // }
}

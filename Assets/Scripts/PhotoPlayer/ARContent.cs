using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[Serializable]
public class ARContent {
    [SerializeField] private ARPlaneManager arPlaneManager;
    [SerializeField] private ARRaycastManager arRaycastManager;
    
    public ARRaycastManager GetARRaycastManager() => arRaycastManager;
    public void DisableARPlaneManager() => arPlaneManager.enabled = false;
    public void DisableARRayCastManager() => arRaycastManager.enabled = false;
    
    //public ARRaycastManager GetARRaycastManager() => view.GetARRaycastManager();
    // public void DisableARRayCastManager() =>  view.DisableARRayCastManager();
    // public void DisableARPlaneManager() =>  view.DisableARPlaneManager();
}

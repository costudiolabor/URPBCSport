using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[Serializable]
public class ARComponents {
    [SerializeField] private ARPlaneManager arPlaneManager;
    [SerializeField] private ARRaycastManager arRaycastManager;
    [SerializeField] private Transform arCamera;
    
    public ARRaycastManager GetARRaycastManager() => arRaycastManager;
    public void DisableARPlaneManager() => arPlaneManager.enabled = false;
    public void DisableARRayCastManager() => arRaycastManager.enabled = false;

    public Transform GetMainCamera() => arCamera;
}
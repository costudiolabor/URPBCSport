using System;
using UnityEngine.XR.ARFoundation;

[Serializable]
public class ARContent : ViewOperator<ARContentView> {
    public ARRaycastManager GetARRaycastManager() => view.GetARRaycastManager();

    public void DisableARRayCastManager() =>  view.DisableARRayCastManager();
    public void DisableARPlaneManager() =>  view.DisableARPlaneManager();
}

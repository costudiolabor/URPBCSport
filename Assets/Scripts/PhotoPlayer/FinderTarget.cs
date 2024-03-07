using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[Serializable]
public class FinderTarget : ViewOperator<FinderTargetView> {
    public event Action<Vector3> SetPositionEvent;
    public void SetRayCastManager(ARRaycastManager arRaycastManager) => view.SetRayCastManager(arRaycastManager);
    public void Initialize() {
        view.Initialize();
        Subscribe();
    }
    public void Close() => view.Close();
    private void OnPosition(Vector3 position) => SetPositionEvent?.Invoke(position);
    private void Subscribe() => view.SetPositionEvent += OnPosition;
    public void UnSubscribe() => view.SetPositionEvent -= OnPosition;
}
using UnityEngine;
using System;

[Serializable]
public class ARObject : ViewOperator<ARObjectView> {
    public void Open() => view.Open();
    public void Close() => view.Close();
    public void SetState(bool state) => view.gameObject.SetActive(state);
    public void Initialize() { }
    
    // public void SetPositionPlayer(Vector3 position) {
    //     view.transform.position = position;
    // }
    
    public void SetPositionObject(Vector3 position, Transform target) {
        view.transform.position = position;
        TurnOnTarget(target);
    }

    private void TurnOnTarget(Transform target) {
        Transform viewTransform = view.transform;
        viewTransform.LookAt(target);
        viewTransform.eulerAngles = new Vector3(0, viewTransform.eulerAngles.y,0);
    }
}

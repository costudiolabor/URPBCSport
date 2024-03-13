using UnityEngine;
using System;

[Serializable]
public class ARObject : ViewOperator<ARObjectView> {
    public void Open() => view.Open();
    
    public void Close() => view.Close();

    public void Initialize() { }
    public void SetPositionPlayer(Vector3 position) {
        view.transform.position = position;
    }
}
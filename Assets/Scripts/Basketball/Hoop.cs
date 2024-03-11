using System;
using UnityEngine;

[Serializable]
public class Hoop : ViewOperator<HoopView> {
  
    public void Initialize() { }
    
    public void Open() {
        view.Open();
        view.Initialize();
    }
    
    public void SetPositionObject(Vector3 position) {
        view.transform.position = position;
        Debug.Log("PositionObject " + position);
    }

}

using UnityEngine;
public class ScaleRotate : MonoBehaviour {
    [SerializeField] private Transform transformObject;
    [SerializeField] private float minScale = 1;
    [SerializeField] private float maxScale = 3;
    [SerializeField] private float minAngle = 2;
    [SerializeField] private float stepScale = 0.001f;

    private float _lastDistance;
    private bool _isBeginTouch;
    private Vector3 _currentDirection;
    private  Vector3 _lastDirection;
    private Touch _touch1;
    private Touch _touch2;

    private void Awake() {
        minScale = transformObject.localScale.x;
    }
    void Update() {
       ScaleRotation();
       
    }

  private void ScaleRotation() {
      if (Input.touchCount == 2) {
          _touch1 = Input.touches[0];
          _touch2 = Input.touches[1];
          
          if (_isBeginTouch == false) {
              _lastDistance = Vector2.Distance(_touch1.position, _touch2.position);
              _lastDirection = _touch1.position - _touch2.position;
              _isBeginTouch = true;
              return;
          }           
          
          if (_touch1.phase == TouchPhase.Moved || _touch2.phase == TouchPhase.Moved) {
              _currentDirection = _touch1.position - _touch2.position;
              float angle = Vector2.SignedAngle(_currentDirection, _lastDirection);
              _lastDirection = _currentDirection;
              float angleABS = Mathf.Abs(angle);
              if (angleABS > minAngle) {
                  Rotate(angle);
              }
              else {
                  Scale();
              }
          }
      }
      _isBeginTouch = false;
  }

  private void Scale() {
      float currentDistance = Vector2.Distance(_touch1.position, _touch2.position);
      float valueScale = (currentDistance - _lastDistance) * stepScale;
      _lastDistance = currentDistance;
      Vector3 result = new Vector3(transformObject.localScale.x + valueScale,
          transformObject.localScale.y + valueScale, transformObject.localScale.z + valueScale);
      bool isMin = (result.x > minScale); 
      bool isMax = (maxScale > result.x);
      if (isMin & isMax) {
          transformObject.localScale = result;
      }
      Debug.Log(" scale " + transformObject.localScale.x);
  }

  private void Rotate(float angle) {
      transformObject.Rotate(0, angle, 0);
  }
  
}

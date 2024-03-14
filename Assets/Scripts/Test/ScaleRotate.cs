using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class ScaleRotate : MonoBehaviour
{
    [SerializeField] private Transform _transformObject;
    [SerializeField] private Text text;

    private Vector2 TouchPosition;
    private Quaternion YRotation;
    public bool Rotation;

    [SerializeField] private float minScale;
    [SerializeField] private float maxScale ;

    private void Awake() {
        minScale = _transformObject.localScale.x;
        maxScale = minScale * 3;
    }

    void Update() {
       //MoveAndRotateObject();
       ScaleRotation();
    }

  void MoveAndRotateObject()
    {
        if(Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            TouchPosition = touch.position;
            
        if (touch.phase == TouchPhase.Moved && Input.touchCount == 1 )
            {
                if (Rotation)
                {
                   // Rotate Object by 1 finger
                    YRotation = Quaternion.Euler(0f, -touch.deltaPosition.x * 0.1f, 0f);
                    _transformObject.transform.rotation = YRotation * _transformObject.transform.rotation;
                }
                else
                {
                   // Move Object
                   _transformObject.transform.position = new Vector3(0, 0, 0); //hits[0].pose.position;
                }
            }
            //Rotate Objec by 2 fingers
            if (Input.touchCount == 2)
            {
                Touch touch1 = Input.touches[0];
                Touch touch2 = Input.touches[1];

                if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
                {
                    float DistanceBetweenTouches = Vector2.Distance(touch1.position, touch2.position);
                    float prevDistanceBetweenTouches = Vector2.Distance(touch1.position - touch1.deltaPosition, touch2.position - touch2.deltaPosition);
                    float Delta = DistanceBetweenTouches - prevDistanceBetweenTouches;

                    if (Mathf.Abs(Delta) > 0)
                    {
                        Delta *= 0.1f;
                    }
                    else
                    {
                        DistanceBetweenTouches = Delta = 0;
                    }
                    YRotation = Quaternion.Euler(0f, -touch1.deltaPosition.x * Delta, 0f);
                    _transformObject.transform.rotation = YRotation * _transformObject.transform.rotation;
                }

            }
            // Deselect object
            // if (touch.phase == TouchPhase.Ended)
            // {
            //     if (SelectedObject.CompareTag("Selected"))
            //     {
            //         SelectedObject.tag = "UnSelected";
            //     }
            // }
        }
    }

  private float lastDistance; 

  private void ScaleRotation() {
      if (Input.touchCount == 2) {
          
          Touch touch1 = Input.touches[0];
          Touch touch2 = Input.touches[1];

          if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved) {
              
              float currentDistance = Vector2.Distance(touch1.position, touch2.position);
              //float prevDistanceBetweenTouches = Vector2.Distance(touch1.position - touch1.deltaPosition, touch2.position - touch2.deltaPosition);
              //float Delta = DistanceBetweenTouches - prevDistanceBetweenTouches;

              // if (Mathf.Abs(Delta) > 0)
              // {
              //     Delta *= 0.01f;
              // }
              // else
              // {
              //     DistanceBetweenTouches = Delta = 0;
              // }

              //float valueScale = -touch1.deltaPosition.x * Delta;

              float valueScale = (currentDistance - lastDistance) * 0.01f;

              lastDistance = currentDistance;
              
              Vector3 result = new Vector3(_transformObject.localScale.x + valueScale,
                  _transformObject.localScale.y + valueScale, _transformObject.localScale.z + valueScale);

              bool isMin = (result.x > minScale); 
              bool isMax = (maxScale > result.x);

              if (isMin || isMax) {
                _transformObject.localScale = result;
              }
              
              var angle = Vector2.SignedAngle(touch1.position, touch2.position);
              text.text = angle.ToString();
               //_transformObject.localRotation = Quaternion.AngleAxis(angle, Vector3.up);

          }
          
      }

      //lastDistance = 0;
  }
  
}

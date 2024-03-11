using System.Collections;
using UnityEngine;

public class BallPenalty : MonoBehaviour {
    [SerializeField] private Rigidbody thisRigidbody;
    [SerializeField] private GameObject directionObject;
    [SerializeField] private float maxSpeedBall = 1.0f;
    [SerializeField] private float timeLife = 10.0f;
    private Coroutine _coroutine;
    public bool isActive = true;
    

    public void Kick(Vector2 direction, float power) {
        var speedBall = maxSpeedBall * power;
        directionObject.SetActive(false);
        //var parent = transform.parent;
        //var directionBall = new Vector3(direction.x, transform.position.y, direction.y);
        //directionBall = (transform.TransformDirection(directionBall));
       // Debug.DrawLine(transform.position, directionBall, Color.green, 1.0f); 
        var directionBall = transform.forward;
        directionBall *= speedBall;
        
        thisRigidbody.AddForce(directionBall, ForceMode.Impulse);
        StartCoroutine(TimerLife());
    }
  
    private IEnumerator TimerLife() {
        yield return new WaitForSeconds(timeLife);
        gameObject.SetActive(false);
        _coroutine = null;
    }
    
    private void OnDisable() {
        if (_coroutine == null) return; 
        StopCoroutine(_coroutine);
    }
}

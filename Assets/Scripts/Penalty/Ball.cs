using System.Collections;
using UnityEngine;
public class Ball : MonoBehaviour {
    [SerializeField] private Rigidbody thisRigidbody;
    [SerializeField] private float maxSpeedBall = 1.0f;
    [SerializeField] private float timeLife = 10.0f;
    private Coroutine _coroutine;
    public bool isActive = true;
    

    public void Kick(Vector2 direction, float power) {
        var speedBall = maxSpeedBall * power;
        var thisTransform = transform;
        //Vector3 directionBall = new Vector3(direction.x, thisTransform.position.y, direction.y) +  thisTransform.forward;;
        Vector3 directionBall = thisTransform.forward;;
        thisRigidbody.AddForce(directionBall * speedBall, ForceMode.Impulse);
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

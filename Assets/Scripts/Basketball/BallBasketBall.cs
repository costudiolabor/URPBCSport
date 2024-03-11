using System.Collections;
using UnityEngine;

public class BallBasketBall : MonoBehaviour {
   [SerializeField] private Rigidbody thisRigidbody;
   [SerializeField] private GameObject directionObject;
   [SerializeField] private float maxSpeedBall = 0.1f;
   [SerializeField] private float timeLife = 10.0f;
   
   private Coroutine _coroutine;
   
   public void Kick(Vector2 direction, float power) {
      var speedBall = maxSpeedBall * power;
      directionObject.SetActive(false);
      
      var directionBall = transform.forward + transform.up;
      directionBall *= speedBall;
      thisRigidbody.useGravity = true;
      thisRigidbody.AddForce(directionBall, ForceMode.Impulse);
      transform.parent = null;
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

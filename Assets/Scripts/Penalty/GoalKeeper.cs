using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GoalKeeper : MonoBehaviour {
   [SerializeField] private Animator animator;
   [SerializeField] private Transform leftPoint;
   [SerializeField] private Transform rightPoint;
   [SerializeField] private string blend = "Blend";
   [SerializeField] private float speed = 1.0f;
   [SerializeField] private Vector3 targetPosition; 
   [SerializeField] private Vector3 currentPosition;
   [SerializeField] private int state;
   [SerializeField] private int lastState;
   [SerializeField] private float minDistance = 0.01f;

   private const int StateIdle = 0;
   private const int StateMoveRight = 1;
   private const int StateMoveLeft = 2;
   
   private float _timeState;
   private Transform _thisTransform;

   public void Initialize() {
      _thisTransform = animator.transform;
      StartCoroutine(GetState());
      StartCoroutine(TimerMove());
   }

   private void Idle() {
      animator.SetFloat(blend, 0);
      targetPosition = currentPosition;
   }

   private void MoveRight() {
      animator.SetFloat(blend, -1);
      targetPosition = rightPoint.localPosition;
   }
   
   private void MoveLeft() {
      animator.SetFloat(blend, 1);
      targetPosition = leftPoint.localPosition;
   }

   private IEnumerator GetState() {
      while (true) {
         yield return new WaitForSeconds(_timeState);
         _timeState = Random.Range(0.5f, 3.0f);
         state = Random.Range(0, 3);
         HandleState();
      }
   }

   private void HandleState() {
      if (lastState == state) return;
      switch (state) {
         case StateIdle :
            Idle();
            break;
         case StateMoveRight :
            MoveRight();
            break;
         case StateMoveLeft :
            MoveLeft();
            break;
      }
      lastState = state;
   }
   
   private IEnumerator TimerMove() {
      while (true) {
         currentPosition = _thisTransform.localPosition;
         _thisTransform.localPosition = Vector3.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
         if (Vector3.Distance(currentPosition, targetPosition) <= minDistance) state = StateIdle;
         yield return null;
      }
   }
   
}

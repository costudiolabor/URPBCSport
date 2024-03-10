using System;
using System.Collections;
using UnityEngine;

public class PlayerPenalty : MonoBehaviour {
   [SerializeField] private Animator animator;
   [SerializeField] private Boots boots;
   [SerializeField] private string idle = "Idle";
   [SerializeField] private string kick = "MoveKick";
   [SerializeField] private string back = "MoveBack";
   [SerializeField] private Vector3 startPosition; 
   [SerializeField] private Vector3 startRotation; 
   [SerializeField]private Vector3 currentPosition;
   [SerializeField] private bool isKick;
   [SerializeField] private float minDistance = 0.01f;
   [SerializeField] private float speed = 5f;
   
   private Transform _thisTransform;
   public event Action IdleEvent;
   
   private void Awake() {
      Initialize();
   }
   
   public void Initialize() {
      _thisTransform = animator.transform;
      startPosition = _thisTransform.localPosition;
      startRotation = new Vector3(0, 0, 0);
      boots.KickEvent += OnKick;
   }
   
   public void MoveKick(Vector2 direction, float distance) {
      boots.SetParametrs(direction, distance);
      StateMoveKick();
      isKick = false;
   }

   private void OnKick() {
      StateMoveBack();
   }

   private void Update() {
      Kick();
   }

   private void Kick() {
      if (isKick) {
         MoveKick(new Vector2(0, 1), 10.0f);
      }
   }

   private void StateIdle() {
      _thisTransform.localPosition = startPosition;
      animator.SetTrigger(idle);
      var localEulerAngles = startRotation;
      _thisTransform.localEulerAngles = localEulerAngles;
      IdleEvent?.Invoke();
   }
   
   private void StateMoveKick() {
      _thisTransform.localEulerAngles = startRotation;
      animator.SetTrigger(kick);
   }
   
   private void StateMoveBack() {
      animator.SetTrigger(back);
      StartCoroutine(TimerMoveBack());
   }
   
   private IEnumerator TimerMoveBack() {
      while (true) {
            currentPosition = _thisTransform.localPosition;
            _thisTransform.localPosition = Vector3.MoveTowards(currentPosition, startPosition, speed * Time.deltaTime);
            yield return null;
            if (Vector3.Distance(currentPosition, startPosition) <= minDistance) break;
      }
      Debug.Log("FinishCoroutine");
      StateIdle();
   }

}

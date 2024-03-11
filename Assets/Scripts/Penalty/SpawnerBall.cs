using System;
using UnityEngine;

[Serializable]
public class SpawnerBall {
   [SerializeField] private Transform _parentBall;
   [SerializeField] private BallPenalty prefabBallPenalty;
   [SerializeField] private BallBasketBall prefabBallBasketball;
   private Factory _factory = new ();

   public void SetParentBall(Transform parentBall) => this._parentBall = parentBall;
   public Transform GetParentBall() => _parentBall;
   
   public BallPenalty GetBallPenalty() {
      var ball = _factory.Get(prefabBallPenalty, _parentBall.position);
      ball.transform.SetParent(_parentBall);
      ball.transform.rotation = _parentBall.rotation;
      return ball;
   }
   
   public BallBasketBall GetBallBasketball() {
      var ball = _factory.Get(prefabBallBasketball, _parentBall.position);
      ball.transform.SetParent(_parentBall);
      ball.transform.rotation = _parentBall.rotation;
      return ball;
   }
}

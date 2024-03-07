using System;
using UnityEngine;

[Serializable]
public class SpawnerBall {
   [SerializeField] private Ball prefabBall;
   private Transform _parentBall;
   private Factory _factory = new ();

   public void SetParentBall(Transform parentBall) => this._parentBall = parentBall;
   
   public Ball GetBall() {
      Ball ball = _factory.Get(prefabBall, _parentBall.position);
      ball.transform.SetParent(_parentBall);
      return ball;
   }

  
}

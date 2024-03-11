using System;
using UnityEngine;

public class AnimEvents : MonoBehaviour {
   public event Action KickEvent;
   public void Kick() {
      KickEvent?.Invoke();
   }
}

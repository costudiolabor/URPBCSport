using System;
using UnityEngine;
using UnityEngine.UI;

public class MainView : View {
   [SerializeField]
   private Button buttonClose;

   public event Action CloseEvent;
   public void Initialize() {
      buttonClose.onClick.AddListener(OnClose);
   }

   private void OnClose() {
      CloseEvent?.Invoke();
   }
}

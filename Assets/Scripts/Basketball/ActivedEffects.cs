using System;
using System.Collections;
using UnityEngine;

public class ActivedEffects : MonoBehaviour {
   [SerializeField] private GameObject parentEffects;
   [SerializeField] private float timeEffects = 1.0f;

   private void OnEnable() {
      parentEffects.SetActive(false);
   }

   public void Show() => StartCoroutine(StartEffects());

   private IEnumerator StartEffects() {
      parentEffects.SetActive(true);
      yield return new WaitForSeconds(timeEffects);
      parentEffects.SetActive(false);
   }
}

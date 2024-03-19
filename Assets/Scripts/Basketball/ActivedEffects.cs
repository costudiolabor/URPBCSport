using System.Collections;
using UnityEngine;

public class ActivedEffects : MonoBehaviour {
   [SerializeField] private GameObject parentEffects;
   [SerializeField] private GameObject parentEffects2;
   [SerializeField] private float timeEffects = 1.0f;

   private void OnEnable() {
      parentEffects.SetActive(false);
      parentEffects2.SetActive(false);
   }

   public void Show() { GetEffects(); }

   private void GetEffects() {
      if (parentEffects.activeInHierarchy) {
         StartCoroutine(StartEffects2());
         return;
      };
      StartCoroutine(StartEffects());
   }

   private IEnumerator StartEffects() {
      parentEffects.SetActive(true);
      yield return new WaitForSeconds(timeEffects);
      parentEffects.SetActive(false);
   }
   
   private IEnumerator StartEffects2() {
      parentEffects2.SetActive(true);
      yield return new WaitForSeconds(timeEffects);
      parentEffects2.SetActive(false);
   }
}

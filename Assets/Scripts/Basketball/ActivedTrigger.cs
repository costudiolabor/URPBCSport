using System;
using UnityEngine;

public class ActivedTrigger : MonoBehaviour {
    public event Action ActivedEvent;
    [SerializeField] private string component;

    private void OnTriggerEnter(Collider other) {
        ActivedEvent?.Invoke();
        Debug.Log("OnTriggerEnter " + component);
    }
}

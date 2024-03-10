using UnityEngine;

public class EntryBasketball : MonoBehaviour {
    [SerializeField] private Main main;
    private void Awake() {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        main.CreateView();
        main.Initialize();
    }
}

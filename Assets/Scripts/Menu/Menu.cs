using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    [SerializeField] private Button buttonPhoto;
    [SerializeField] private Button buttonBasketball;
    [SerializeField] private Button buttonPenalty;

    [SerializeField] private int scenePhoto;
    [SerializeField] private int sceneBasketball;
    [SerializeField] private int scenePenalty;
    private void Awake() {
        buttonPhoto.onClick.AddListener(OnPhoto);
        buttonBasketball.onClick.AddListener(OnBasketball);
        buttonPenalty.onClick.AddListener(OnPenalty);
    }

    private void OnPhoto() {
        SceneManager.LoadScene(scenePhoto);
    }
    
    private void OnBasketball() {
        SceneManager.LoadScene(sceneBasketball);
    }
    
    private void OnPenalty() {
        SceneManager.LoadScene(scenePenalty);
    }
}

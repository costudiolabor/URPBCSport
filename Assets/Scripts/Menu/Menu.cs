using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    [SerializeField] private Button buttonPhoto;
    [SerializeField] private Button buttonPenalty;
    [SerializeField] private Button buttonStadium;
    [SerializeField] private Button buttonPlayer;
    [SerializeField] private Button buttonBasketball;

    [SerializeField] private int scenePhoto;
    [SerializeField] private int scenePenalty;
    [SerializeField] private int sceneStadium;
    [SerializeField] private int scenePlayer;
    [SerializeField] private int sceneBasketball;
    
    private void Awake() {
        buttonPhoto.onClick.AddListener(OnPhoto);
        buttonBasketball.onClick.AddListener(OnBasketball);
        buttonPenalty.onClick.AddListener(OnPenalty);
        buttonPlayer.onClick.AddListener(OnPlayer);
        buttonStadium.onClick.AddListener(OnStadium);
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
    
    private void OnPlayer() {
        SceneManager.LoadScene(scenePlayer);
    }
    
    private void OnStadium() {
        SceneManager.LoadScene(sceneStadium);
    }
}

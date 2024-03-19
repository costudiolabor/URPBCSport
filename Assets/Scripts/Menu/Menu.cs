using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    [SerializeField] private Button buttonPhoto;
    [SerializeField] private Button buttonPenalty;
    [SerializeField] private Button buttonStadium;
    [SerializeField] private Button buttonARCARD;
    [SerializeField] private Button buttonARCARD2;
    // [SerializeField] private Button buttonCARD;
    [SerializeField] private Button buttonBasketball;

    [SerializeField] private int sceneBasketball;
    [SerializeField] private int sceneStadium;
    [SerializeField] private int sceneARCARD;
    [SerializeField] private int sceneARCARD2;
    //[SerializeField] private int sceneCARD;
    [SerializeField] private int scenePhoto;
    [SerializeField] private int scenePenalty;
    
    private void Awake() {
        buttonPhoto.onClick.AddListener(OnPhoto);
        buttonBasketball.onClick.AddListener(OnBasketball);
        buttonPenalty.onClick.AddListener(OnPenalty);
        buttonARCARD.onClick.AddListener(ARCARD);
        buttonARCARD2.onClick.AddListener(ARCARD2);
        // buttonCARD.onClick.AddListener(CARD);
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
    
    private void ARCARD() {
        SceneManager.LoadScene(sceneARCARD);
    }
    
    private void ARCARD2() {
        SceneManager.LoadScene(sceneARCARD2);
    }
    
    // private void CARD() {
    //     SceneManager.LoadScene(sceneCARD);
    // }
    
    private void OnStadium() {
        SceneManager.LoadScene(sceneStadium);
    }
}

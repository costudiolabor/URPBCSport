using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScenes : MonoBehaviour
{
    [SerializeField] private int sceneBasketball;
    [SerializeField] private int sceneStadium;
    [SerializeField] private int sceneARCARD;
    [SerializeField] private int sceneARCARD2;
    [SerializeField] private int scenePhoto;
    [SerializeField] private int scenePenalty;

    public MenuScenes Instanse = null;
    
    private void Awake()
    {
        if (Instanse == null)
        {
            Instanse = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void HandleScene(string message)
    {
        int scene = 0;
        string sceneName = "menu";
        switch (message)
        {
            case "Back":
                SceneManager.LoadScene(0, LoadSceneMode.Single);
                return;
            
            case "Quit":
                Application.Quit();
                return;
            
            case "Menu":
                scene = 0;
                sceneName = "Menu";
                break;

            case "Basketball":
                scene = sceneBasketball;
                sceneName = "AR_Basketball";
                break;

            case "Stadium":
                scene = sceneStadium;
                sceneName = "AR_Stadium";
                break;

            case "AR_Card_1":
                scene = sceneARCARD;
                sceneName = "AR_Card_Player_Black";
                break;

            case "AR_Card_2":
                scene = sceneARCARD2;
                sceneName = "AR_Card_Player_White";
                break;

            case "Photo":
                scene = scenePhoto;
                sceneName = "AR_Photo";
                break;

            case "Penalty":
                scene = scenePenalty;
                sceneName = "AR_Penalty";
                break;
        }

        //SceneManager.LoadScene(scene, LoadSceneMode.Single);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
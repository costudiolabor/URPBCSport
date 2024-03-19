using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScenes : MonoBehaviour {
   [SerializeField] private int sceneBasketball;
   [SerializeField] private int sceneStadium;
   [SerializeField] private int sceneARCARD;
   [SerializeField] private int sceneARCARD2;
   [SerializeField] private int scenePhoto;
   [SerializeField] private int scenePenalty;

   public void HandleScene(string message) {
      int scene = 0;
      switch (message) {
         
         case "Scene1":
            scene = sceneBasketball;
            break;
         
         case "Scene2": 
            scene = sceneStadium;
            break;
         
         case "Scene3": 
            scene = sceneARCARD;
            break;
         
         case "Scene4": 
            scene = sceneARCARD2;
            break;
         
         case "Scene5": 
            scene = scenePhoto;
            break;
         
         case "Scene6": 
            scene = scenePenalty;
            break;
      }
      
      SceneManager.LoadScene(scene, LoadSceneMode.Single);
   }
}

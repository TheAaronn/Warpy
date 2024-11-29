using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class GameOverScreen : MonoBehaviour {
    public Text pointsText;
    public GameManager GameManager;
    public void Setup() {
        if(gameObject == null){
            return;
        }else{
            gameObject.SetActive(true);
        }
    }

    public void RestartButton() {
        // Cargar primera escena a través del GameManager
        GameManager.RestartGame();
    }
    
    public void ExitButton() {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}

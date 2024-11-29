using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class VictoryScreen : MonoBehaviour {
    public Text pointsText;
    public void Setup() {
        gameObject.SetActive(true);
    }

    public void RestartButton() {
        // Cargar primera escena a través del GameManager
        GameManager.Instance.RestartGame();
    }
    
    public void ExitButton() {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    public VictoryScreen VictoryScreen;
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public void GameOver()
    {
        GameOverScreen.Setup();
    }

    public void Victory() {
        VictoryScreen.Setup();
    }

    public void RestartGame()
    {
        Debug.Log("Restarted");
        SceneManager.LoadScene("Level 1");
        return;
    }

    public void ExitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}

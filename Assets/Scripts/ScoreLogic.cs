using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    AudioManager audioManager;
    private ScoreCounter scoreCounter;
    void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        // Buscar el ScoreCounter que viene de la escena anterior
        scoreCounter = FindObjectOfType<ScoreCounter>();
        
        if (scoreCounter == null)
        {
            Debug.LogError("No se encontró ScoreCounter en la escena");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && scoreCounter != null)
        {
            audioManager.PlaySFX(audioManager.coin);
            scoreCounter.GainScore();
            Destroy(gameObject);
        }
    }
}

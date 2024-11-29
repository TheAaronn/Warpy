using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class LifesCounter : MonoBehaviour {
    public TextMeshProUGUI lifesText;
    public GameManager GameManager;
    private int lifes = 3;

    void Start() {
        UpdateLifesText();
    }   

    void UpdateLifesText() {
        lifesText.text = string.Format("LIFES: {0}", lifes);
    }

    public void LoseLife() {
        lifes--;
        if(lifes <= 0) {
            GameManager.GameOver();
            return;
        }
        UpdateLifesText();
    }
    public void GainLife() {
        lifes++;
        UpdateLifesText();
    }
    
}

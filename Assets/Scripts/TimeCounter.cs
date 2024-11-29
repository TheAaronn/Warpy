using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
        float t = Time.time - startTime;

        int minutes = (int)t / 60;
        int seconds = (int)t % 60;

        timeText.text = string.Format("TIME {0:00}:{1:00}", minutes, seconds);
    }
}

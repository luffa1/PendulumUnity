using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;
    private float stopTime;
    private bool isStarted = false;

    public void startTimer()
    {
        isStarted = true;
        startTime = Time.time;
    }

    public void stopTimer() 
    {
        isStarted = false;
    }
    void Update()
    {
        if(isStarted) 
        {
            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            timerText.text = minutes + ":" + seconds;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReversePendulumTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    internal float ElapsedTime;
    private float startTime;
    private float stopTime;
    public bool isStarted = false;
    private float fallingTime;
    private Vector3 startingPosition;

    public void startTimer() {
        isStarted = true;
        startTime = Time.time;
    }
    public void stopTimer() {
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

            // // Pobierz aktualne położenie wahadła
            // Vector3 currentPosition = transform.position;

            // // Jeśli aktualne położenie wahadła jest niższe niż położenie początkowe,
            // // rozpocznij liczenie czasu
            // if (currentPosition.y < startingPosition.y)
            // {
            //     // Zwiększ zmienną fallingTime o czas, który upłynął od ostatniej klatki
            //     fallingTime += Time.deltaTime;
            // }
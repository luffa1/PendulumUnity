using UnityEngine;
using TMPro;

public class ReversePeriodCounter : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public TextMeshProUGUI periodText;
    private float previousSpeed = 0;
    private int halfPeriod = 0;
    private int period{get => halfPeriod/2;}
    public ReversePendulumTimer timerr;
    public bool shouldCount = false;

    void Start()
    {
        timerr = GameObject.Find("ReversePendulumTimer").GetComponent<ReversePendulumTimer>();
        rb2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        // sprawdza czy liczenie okresów powinno być aktywne
        if (shouldCount == true)
        {
            // pobiera aktualną prędkość wahadełka z komponentu Rigidbody2D
            float speed = rb2D.velocity.x;
            // sprawdza czy wahadło zmieniło kierunek ruchu
            if (previousSpeed * speed < 0)
            {
                halfPeriod ++;
            }
            // sprawdza czy wahadło wykonało 10 pełnych okresów, jesli tak zatrzymuje czas
            if (period >= 10)
            {
                timerr.stopTimer();
            }
            // Jeśli okres wahadła jest mniejszy lub rówy 10, to ustaw tekst z okresem wahadła
            if (period <= 10)
            {
                periodText.text = period.ToString("");
            }
            // Ustawienie aktualnej prędkości jako poprzednią prędkość
            previousSpeed = speed;
        }
    }
    // Funkcja odpowiadająca za zresetowanie okresu
    public void ResetPeriod()
    {
        halfPeriod = 0;
    }
}

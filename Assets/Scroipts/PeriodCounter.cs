using UnityEngine;
using TMPro;

public class PeriodCounter : MonoBehaviour
{
    private Rigidbody2D rb2D; // Obiekt Rigidbody2D wahadła
    public TextMeshProUGUI periodText; // Tekst do wyświetlania okresu
    private float previousSpeed = 0; // Poprzednia prędkość wahadła
    private int halfPeriod = 0; // Licznik półokresów
    private int period{get => halfPeriod/2;} // Okres wahadła (półokresy podzielone przez 2)
    public Timer timer; // Skrypt Timer

    // Funkcja wywoływana podczas startu skryptu
    void Start()
    {
        // Pobranie skryptu Timer
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        // Pobranie komponentu Rigidbody2D wahadła
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Funkcja wywoływana co klatkę dla obiektów z kinematyką
    void FixedUpdate()
    {
        // Pobranie aktualnej prędkości wahadła
        float speed = rb2D.velocity.x;
        // Jeśli aktualna prędkość ma przeciwny znak do poprzedniej prędkości, to znaczy, że wahadło zmieniło kierunek ruchu
        if (previousSpeed * speed < 0)
        {
            // Zwiększenie licznika półokresów
            halfPeriod ++;
        }
        // Jeśli okres wahadła jest większy lub równy 10, to zatrzymanie odliczania czasu
        if (period >= 10)
        {
            timer.stopTimer();
        }
        // Jeśli okres wahadła jest mniejszy lub równy 10, to ustawienie tekstu z okresem wahadła
        if (period <= 10)
        {
            periodText.text = period.ToString("");
        }
        // Ustawienie aktualnej prędkości jako poprzednią prędkość
        previousSpeed = speed;
    }
}

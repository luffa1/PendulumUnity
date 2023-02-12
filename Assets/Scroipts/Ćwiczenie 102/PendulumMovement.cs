using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumMovement : MonoBehaviour
{
    // Siła wahadła
    public float swingForce = 10f;

    // Współczynnik tarcia
    public float friction = 0.9f;

    // Miejsce, w którym kula jest podpięta do wahadła
    public Transform pivot;

    // Komponent Line Renderer do rysowania linii
    private LineRenderer lineRenderer;

    // Prędkość kuli
    private Vector2 velocity;
    public Transform ball; // referencja do kuli

    void Start()
    {
        // Pobranie komponentu Line Renderer
        lineRenderer = GetComponent<LineRenderer>();
        // Ustawienie grubości linii
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        // Ustawienie koloru linii
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
    }
    void Update()
    {
        
        // Obliczenie siły, która będzie działać na kulę
        Vector2 force = (pivot.position - transform.position).normalized * swingForce;

        // Zastosowanie siły grawitacji
        force += Physics2D.gravity;

        // Zastosowanie tarcia
        velocity *= friction;

        // Zmiana prędkości kuli
        velocity += force * Time.deltaTime;

        // Zmiana pozycji kuli
        transform.position += (Vector3)velocity * Time.deltaTime;

        // Ustawienie punktów linii na pozycje kuli i miejsca, w którym jest podpięta do wahadła
        lineRenderer.SetPosition(0, pivot.position);
        lineRenderer.SetPosition(1, transform.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererCode : MonoBehaviour
{
    public Transform circle; // Transform obiektu koła
    private LineRenderer line; // Komponent LineRenderer służący do rysowania linii
    void Start()
    {
        // Pobranie komponentu LineRenderer
        line = GetComponent<LineRenderer>();
        // Ustawienie szerokości początku i końca linii
        line.startWidth = 0.005f;
        line.endWidth = 0.005f;
    }

    void Update()
    {
        // ustaw pozycję początku linii wahadła na pozycji punktu zawieszenia
        line.SetPosition(0, transform.position);
        // ustaw pozycję końca linii wahadła na pozycji końca wahadła
        line.SetPosition(1, circle.position);
    }
}

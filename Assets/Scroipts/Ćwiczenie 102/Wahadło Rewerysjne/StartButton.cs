using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class StartButton : MonoBehaviour
{
     // Obiekt, na którym jest umieszczony skrypt z funkcją Update()
    public GameObject otherObject;

    // Skrypt z funkcją Update()
    private TestingCodeForMovement otherScript;
    // Pole tekstowe, w którym użytkownik wprowadza wartość siły
    
    private float force;

    // Metoda wywoływana po włączeniu skryptu
    void Start()
    {
        // Pobranie skryptu z funkcją Update() z obiektu otherObject
        otherScript = otherObject.GetComponent<TestingCodeForMovement>();
    }

    // Metoda wywoływana po kliknięciu przycisku
    void OnButtonClick()
    {
        // Uruchomienie funkcji Update() z innego skryptu
        // otherScript.Update();
        // Tutaj można umieścić dodatkowy kod, który zostanie uruchomiony po kliknięciu przycisku Start
        
    }
    
}
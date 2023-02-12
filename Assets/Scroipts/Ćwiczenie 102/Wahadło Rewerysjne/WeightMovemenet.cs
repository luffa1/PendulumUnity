using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeightMovemenet : MonoBehaviour
{
    // Referencja do obiektu suwaka
    public Slider slider;
    public TextMeshProUGUI sliderValue;
    // Komponent Transform obiektu, dla którego chcemy zmieniać wartość Y
    private Transform targetTransform;
    // Tablica zawierająca wartości wyświetlane dla poszczególnych pozycji suwaka
    private string[] displayedValues = { "90", "85", "80", "75", "70", "65", "60", "55", "50", "45", "40", "35", "30", "25"};

    void Start()
    {
        // Pobranie komponentu Transform obiektu, dla którego chcemy zmieniać wartość Y
        targetTransform = GetComponent<Transform>();

        // Nasłuchiwanie zdarzenia zmiany pozycji suwaka
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        OnSliderValueChanged(slider.value);
        sliderValue.text = "90 cm";
    }

    // Funkcja wywoływana po zmianie pozycji suwaka
    void OnSliderValueChanged(float value)
    {
        // Ustawienie nowej wartości Y dla obiektu
        targetTransform.position = new Vector3(targetTransform.position.x, value, targetTransform.position.z);

        // Pobranie indeksu tablicy odpowiadającego pozycji suwaka
        float arrayIndex = value * (14f / 0.9f) + 7f;

        // Sprawdzenie, czy indeks jest w zakresie dostępnych wartości
        if (arrayIndex >= 0f && arrayIndex < 14f)
        {
            // Jeśli indeks jest ujemny, dodać odpowiednią liczbę elementów tablicy
            if (arrayIndex < 0)
            {
                arrayIndex += 8;
            }
            // Ustawienie wyświetlanej wartości jako element tablicy o odpowiednim indeksie
            sliderValue.text = displayedValues[(int)arrayIndex] + " cm";
        }
    }
}
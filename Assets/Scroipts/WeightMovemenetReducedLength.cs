using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class WeightMovemenetReducedLength : MonoBehaviour
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
    }

    // Funkcja wywoływana po zmianie pozycji suwaka
    void OnSliderValueChanged(float value)
    {
        // Ustawienie nowej wartości Y dla obiektu
        targetTransform.position = new Vector3(targetTransform.position.x, value, targetTransform.position.z);

        // Obliczenie indeksu tablicy displayedValues na podstawie wartości suwaka
        int arrayIndex = (int)Mathf.Round((value - slider.minValue) / (slider.maxValue - slider.minValue) * displayedValues.Length);
        // Ograniczenie indeksu do zakresu tablicy displayedValues
        arrayIndex = Mathf.Clamp(arrayIndex, 0, displayedValues.Length - 1);
        // Ustawienie tekstu na wartość z indeksu arrayIndex tablicy displayedValues
        sliderValue.text = displayedValues[arrayIndex] + " cm";
    }
}
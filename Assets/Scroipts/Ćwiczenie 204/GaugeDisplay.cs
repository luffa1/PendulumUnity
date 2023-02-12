using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GaugeDisplay : MonoBehaviour
{
    public SliderForVoltage gaugeValue;
    [SerializeField] private Slider sliderAmp;
    [SerializeField] private TextMeshProUGUI sliderText;


    void Start()
    {
        gaugeValue = GameObject.Find("Slider 2").GetComponent<SliderForVoltage>();
        
        sliderAmp.onValueChanged.AddListener((x) => {
            sliderText.text = x.ToString("0.000");
        });
    }

    // Funkcja odpowiadająca za zwiększanie się amperów według wzoru
    public void DisplayAmperGauge(float u)
    {
        SkryptObliczeniowy skrypt = new SkryptObliczeniowy();
        sliderText.text = skrypt.CalculateAmper(u).ToString("0.000");
    }
}
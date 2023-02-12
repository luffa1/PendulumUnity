using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SliderForAmpers : MonoBehaviour
{
    public GaugeDisplay gaugeDisplay;
    public SliderForVoltage sliderVoltage;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI sliderText;
    [SerializeField] private TextMeshProUGUI distanceText;


    void Start()
    {
        sliderVoltage = GameObject.Find("Slider 2").GetComponent<SliderForVoltage>();
        gaugeDisplay = GameObject.Find("Amperomierz").GetComponent<GaugeDisplay>();

        
        slider.onValueChanged.AddListener((v) => {
            sliderText.text = v.ToString("0.00");
            sliderVoltage.Amper(v);
        });
    }

    // Funkcja odpowiadająca za zwiększanie się amperów według wzoru
    public void Voltage(float u)
    {
        string distanceValue = "";
        if (u <= 2.5) 
        {
            distanceValue = "1";
        } else if (u <= 5)
        {
            distanceValue = "2";
        }
        
        SkryptObliczeniowy skrypt = new SkryptObliczeniowy();
        sliderText.text = skrypt.CalculateAmper(u).ToString("0.00");
        gaugeDisplay.DisplayAmperGauge(u);
        distanceText.text = distanceValue;
    }
  
}



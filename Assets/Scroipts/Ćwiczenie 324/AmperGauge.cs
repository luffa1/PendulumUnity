using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmperGauge : MonoBehaviour
{
    public Slider prismaAngleSlider;
    public ButtonScript buttonHolder;
    [SerializeField] private TextMeshProUGUI amperText;
    [SerializeField] Button button90;
    [SerializeField] Button button0;
    public static bool clicked;
    void Start()
    {
        Button btn90 = button90.GetComponent<Button>();
        btn90.onClick.AddListener(delegate {
            PolarizationValue.GetInstance().SetPreviousPolarizationValue(90);
            Polarization90();
        });
        Button btn0 = button0.GetComponent<Button>();
        button0.onClick.AddListener(delegate {
            PolarizationValue.GetInstance().SetPreviousPolarizationValue(0);
            Polarization0();
        });
    
        

    }
    public void Update()
    {
        if(PolarizationValue.GetInstance().GetPreviousPolarizationValue() == 90){
            Polarization90();
        } else {
            Polarization0();
        }
    }
    public void Polarization90()
        {
         // wykorzystanie wzoru do obliczenia natężenia detektora dla polaryzacji 90
            SliderValue sliderValue =  SliderValue.GetInstance();
            float prismaAngle = sliderValue.GetPreviousSliderValue() * 5;
            float voltage = 7.06f;
            float detectorVoltage = prismaAngle * prismaAngle * voltage;
            amperText.text = detectorVoltage.ToString("0.00");

        }
        
    
    public void Polarization0()
        {
         // wykorzystanie wzoru do obliczenia natężenia detektora dla polaryzacji 0
            SliderValue sliderValue =  SliderValue.GetInstance();
            float prismaAngle = sliderValue.GetPreviousSliderValue() * 2;
            float voltage = 7.11f;
            float detectorVoltage = prismaAngle * prismaAngle * voltage;
            amperText.text = detectorVoltage.ToString("0.00");
        }
}

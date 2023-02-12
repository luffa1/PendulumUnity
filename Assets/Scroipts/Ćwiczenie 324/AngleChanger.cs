using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AngleChanger : MonoBehaviour
{
    public CurrentConsumption consumption;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI sliderText;

 void Start()
    {
        consumption = GameObject.Find("Detektor").GetComponent<CurrentConsumption>();

        slider.onValueChanged.AddListener((v) => {
            float prismaAngle = v * 5;
            consumption.UpdatePosition(v); 
            sliderText.text = prismaAngle.ToString("0");
        });
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    public TextMeshProUGUI buttonText;


    void Update()
    {
        buttonText.text = PolarizationValue.GetInstance().GetPreviousPolarizationValue().ToString();
    }
}

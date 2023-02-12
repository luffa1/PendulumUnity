using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RotateMirror : MonoBehaviour
{

    [SerializeField] private Slider slider;

    void Start()
    {
        slider.onValueChanged.AddListener(delegate {
            ObjRotation();
        });
    }

    // public void ObjRotation() {
    //     transform.rotation = Quaternion.Euler(Vector3.forward * - slider.value);
    // }
    public void ObjRotation() 
    {
        SliderValue sliderValue =  SliderValue.GetInstance();

        transform.eulerAngles = Vector3.forward * - slider.value;
        sliderValue.SetPreviousSliderValue(slider.value);
    }
}

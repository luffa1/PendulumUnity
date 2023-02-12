using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCodesLenght : MonoBehaviour
{
    // Referencja do suwaka
    public Slider lengthSlider;

    // Obecna długość obiektu w osi Y
    private float lengthY;

    void Start()
    {
        // Pobierz początkową długość obiektu w osi Y
        lengthY = transform.localScale.y;

        // Ustaw wartość suwaka na początkową długość obiektu w osi Y
        lengthSlider.value = lengthY;
    }

    void Update()
    {
        // Pobierz aktualną wartość suwaka
        lengthY = lengthSlider.value;

        // Zmień długość obiektu w osi Y na wartość suwaka
        transform.localScale = new Vector3(transform.localScale.x, lengthY, transform.localScale.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LenghtChanges : MonoBehaviour
{
    public Slider lengthSlider; // referencja do slidera
    public GameObject pivotPoint; // referencja do punktu zawieszenia wahadła
    public GameObject pendulumEnd; // referencja do końca wahadła
    public LineRenderer lineRenderer; // referencja do linii wahadła
    public TextMeshProUGUI lengthValue; // referencja do pola tekstowego

    void Start()
    {
        lengthSlider.onValueChanged.AddListener(SetLength);
        // ustaw początkową długość wahadła na wartość slidera
        SetLength(lengthSlider.value);
    }

    public void SetLength(float length)
    {
        // ustaw pozycję końca wahadła
        pendulumEnd.transform.position = pivotPoint.transform.position + Vector3.down * length;

        // ustaw pozycję początku linii wahadła na pozycji punktu zawieszenia
        lineRenderer.SetPosition(0, pivotPoint.transform.position);

        // ustaw pozycję końca linii wahadła na pozycji końca wahadła
        lineRenderer.SetPosition(1, pendulumEnd.transform.position);

        lengthValue.text = length.ToString("") + " cm";  
    }
}
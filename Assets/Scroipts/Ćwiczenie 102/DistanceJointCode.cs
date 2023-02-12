using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceJointCode : MonoBehaviour
{
    public Transform ball; // referencja do kuli
    public Transform pivot; // referencja do punktu, do którego jest przywiązana linia

    public Slider distanceSlider; // suwak do zmiany odległości między kulą a pivotem

    private DistanceJoint2D distanceJoint; // joint DistanceJoint2D łączący kulę i pivot

    private void Start()
    {
        // utworzenie nowego jointu DistanceJoint2D i przypisanie go do zmiennej distanceJoint
        distanceJoint = ball.gameObject.AddComponent<DistanceJoint2D>();

        // ustawienie pivot jako obiektu, do którego jest przywiązany joint
        distanceJoint.connectedBody = pivot.GetComponent<Rigidbody2D>();

        // ustawienie odległości między kulą a pivotem na wartość początkową suwaka
        distanceJoint.distance = distanceSlider.value;
        distanceJoint.autoConfigureDistance = false;
    }

    private void Update()
    {
        // aktualizacja odległości między kulą a pivotem na podstawie wartości suwaka
        distanceJoint.distance = distanceSlider.value;
    }
}

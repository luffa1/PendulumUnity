using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TestZliczaniaOkresów : MonoBehaviour
{
    // Siatka tekstowa wyświetlająca aktualny kąt wahadła
    public TextMeshProUGUI periodText;
    // Przekształcanie składowej punktu obrotu wahadła
    public Transform pivot;
    // Bieżący okres wahadła w sekundach
    public Transform anchor;
    private float period = 0;
    // Komponent timera do śledzenia czasu, który upłynął
    public Timer timer;
    // Komponent Rigidbody2D
    private Rigidbody2D rb2D;
    // Komponent HingeJoint2D
    private HingeJoint2D hing2D;
    // Komponent Slider
    public Slider lengthSlider;
    // Siatka tekstowa do wyświetlania wartości długości
    public TextMeshProUGUI lengthValue;
    // Komponent Kamery
    public Camera cameraa;
    // Określenie czy funkcja sprawdzająca czy wahadło się rusza
    private bool isDragging = false;

    void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        rb2D = GetComponent<Rigidbody2D>();
        hing2D = GetComponent<HingeJoint2D>();
        lengthSlider.onValueChanged.AddListener(SetLength);
        SetLength(lengthSlider.value);
    }
    void OnMouseDrag() 
    {
        if (isDragging)
        {
            rb2D.isKinematic = true;
            rb2D.velocity = Vector2.zero;
            rb2D.angularVelocity = 0;
            Vector3 Screepoint = Camera.main.WorldToScreenPoint (transform.position);
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Screepoint.z);
            Vector3 objposition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            transform.position = objposition;
            transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
        }    
    }
    void OnMouseUp() 
    {
        if(isDragging)
        {
            timer.startTimer();
            period = 0;
            ResetPosition();
            isDragging = false;
        }
    }
    void OnMouseDown() 
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        
        if (hit.collider != null) 
        {
            Transform objectHit = hit.transform;
            if (objectHit.tag == "Circle")
            {
                isDragging = true;
                Debug.Log(objectHit.tag);
            }
        }
    }
    public void SetLength(float length)
    {
        ResetPosition();
        lengthValue.text = length.ToString("") + " cm";  
    }
    public void ResetPosition()
    {
        rb2D.isKinematic = false;
        Vector2 v2 = (anchor.position - pivot.position).normalized * lengthSlider.value / 100;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, v2);
        pivot.rotation = rotation;
        pivot.position = anchor.position - (Vector3) v2;
        hing2D.anchor = v2.magnitude * Vector2.up;
    }
}

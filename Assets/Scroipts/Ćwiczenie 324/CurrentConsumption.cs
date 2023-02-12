using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CurrentConsumption : MonoBehaviour
{
    [SerializeField] private Slider gaugePosition;
    void Start()
    {
        gaugePosition.onValueChanged.AddListener(delegate {
        });
    }

    public void UpdatePosition(double n)
    {
        
        if (n == 1)
        {
            transform.position = new Vector2(-7.44f, 2.21f);
        }
        if (n == 2)
        {
            transform.position = new Vector2(-6.57f, 2.22f);
        }
        if (n == 3)
        {
            transform.position = new Vector2(-6.11f, 2.4f);
        }
        if (n == 4)
        {
            transform.position = new Vector2(-5.97f, 2.63f);
        }
        if (n == 5)
        {
            transform.position = new Vector2(-5.95f, 3.03f);
        }
        if (n == 6)
        {
            transform.position = new Vector2(-5.57f, 3.12f);
        }
        if (n == 7)
        {
            transform.position = new Vector2(-5.2f, 3.3f);
        }
        if (n == 8)
        {
            transform.position = new Vector2(-4.97f, 3.46f);
        }
        if (n == 9)
        {
            transform.position = new Vector2(-4.45f, 3.41f);
        }
        if (n == 10)
        {
            transform.position = new Vector2(-4.34f, 3.68f);
        }
        if (n == 11)
        {
            transform.position = new Vector2(-3.81f, 3.68f);
        }
        if (n == 12)
        {
            transform.position = new Vector2(-3.35f, 3.68f);
        }
        if (n == 13)
        {
            transform.position = new Vector2(-3.06f, 3.7f);
        }
        if (n == 14)
        {
            transform.position = new Vector2(-2.98f, 3.98f);
        }
        if (n == 15)
        {
            transform.position = new Vector2(-2.63f, 3.99f);
        }
        if (n == 16)
        {
            transform.position = new Vector2(-2.33f, 4f);
        }
        if (n == 17)
        {
            transform.position = new Vector2(-1.97f, 4.01f);
        }
    }
}

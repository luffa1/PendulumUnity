using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReducedLength : MonoBehaviour
{
    public float swingSpeed = 1.0f; // szybkość wahadła
    public float swingDistance = 1.0f; // odległość wahadła
    public bool swingRight = true; // kierunek wahadła (true = prawo, false = lewo)

    private new HingeJoint2D hingeJoint; // złącze wahadła
    private Rigidbody2D rb; // ciało sztywne obiektu wahadła

    void Start()
    {
        // pobierz komponenty złącza i ciała sztywnego
        hingeJoint = GetComponent<HingeJoint2D>();
        rb = GetComponent<Rigidbody2D>();

        // ustaw długość zredukowaną
        Vector2 anchor = hingeJoint.anchor;
        anchor.y = -swingDistance / 2;
        hingeJoint.anchor = anchor;
    }

    void Update()
    {
        // oblicz pozycję wahadła
        float yPos = Mathf.Sin(Time.time * swingSpeed) * swingDistance;

        // ustaw pozycję obiektu
        rb.MovePosition(new Vector2(rb.position.x, yPos));

        // jeśli obiekt ma się poruszać w lewo, odwróć go
        if (!swingRight)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}


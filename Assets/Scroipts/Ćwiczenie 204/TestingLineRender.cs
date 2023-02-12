using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingLineRender : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private LineControler line;

    private void Start() {
        line.SetUpLine(points);
    }
}


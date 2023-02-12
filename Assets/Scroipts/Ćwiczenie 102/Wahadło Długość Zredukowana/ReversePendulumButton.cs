using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReversePendulumButton : MonoBehaviour
{
    public void LoadWahadloReversyjne()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        if (buildIndex != 0)
        {
            // Załaduj scenę o indeksie o jeden mniejszym
            SceneManager.LoadScene(buildIndex - 1);
        }
        
    }
}

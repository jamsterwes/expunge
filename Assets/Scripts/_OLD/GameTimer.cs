using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    // UI element for timer fill
    public Image timerEmpty;
    public float solveTime;

    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float timeRemaining = solveTime - (Time.time - startTime);
        timerEmpty.fillAmount = 1.0f - (timeRemaining / solveTime);
    }
}

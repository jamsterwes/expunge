using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    // UI element for timer fill
    public Image timerEmpty;
    public float solveTime;

    private float startTime;

    public bool running = true;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (!running) return;

        float timeRemaining = solveTime - (Time.time - startTime);
        
        if (timeRemaining <= 0.0f)
        {
            WorldManager.inst.Die();
            return;
        }

        timerEmpty.fillAmount = 1.0f - (timeRemaining / solveTime);
    }
}

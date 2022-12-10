using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
    public Image[] hearts;

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++) {
            hearts[i].enabled = (i + 1) <= WorldManager.inst.GetLives();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{
    // Manage general state, etc...
    // Control minigames, etc...
    [Header("Player")]
    public Transform playerTransform;

    // Minigame UI (TEMP)
    [Header("Minigame")]
    public GameObject minigameUI;

    // Handle objects being broken
    public void OnObjectBroken(GameObject gameObject)
    {
        // Spawn minigame
        minigameUI.SetActive(true);
    }

    // Die
    public void Die()
    {
        SceneManager.LoadScene("DeathScreen");
    }
    void Update()
    {
        // Kill player if it falls too low
        if (playerTransform.position.y < -20.0f) Die();
    }

    // Singleton thyself
    public static WorldManager inst = null;
    void Awake()
    {
        inst = this;
    }
}

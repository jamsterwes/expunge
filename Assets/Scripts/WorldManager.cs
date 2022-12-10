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
    public MinigameManager minigameManager;

    // STATE
    private bool canBreak = true;
    private int playerLives = 3;

    // Handle objects being broken
    public void OnObjectBroken(GameObject gameObject)
    {
        // Spawn minigame
        minigameUI.SetActive(true);

        // Restart game
        minigameManager.Restart();

        // Disable breaking
        canBreak = false;
    }

    public void OnPuzzleSolve()
    {
        // Re-enable breaking
        canBreak = true;

        // Despawn minigame
        minigameUI.SetActive(false);
    }

    // Die
    public void Die(bool forceDie = false)
    {
        if (playerLives <= 1 || forceDie) SceneManager.LoadScene("DeathScreen");
        else playerLives--;
    }

    public int GetLives()
    {
        return playerLives;
    }

    public bool CanBreak()
    {
        return canBreak;
    }

    void Update()
    {
        // Kill player if it falls too low
        if (playerTransform.position.y < -20.0f) Die(true);
    }

    // Singleton thyself
    public static WorldManager inst = null;
    void Awake()
    {
        inst = this;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    // Manage general state, etc...
    // Control minigames, etc...

    // Minigame UI (TEMP)
    [Header("Minigame")]
    public GameObject minigameUI;

    // Handle objects being broken
    public void OnObjectBroken(GameObject gameObject)
    {
        // Spawn minigame
        minigameUI.SetActive(true);
    }

    // Singleton thyself
    public static WorldManager inst = null;
    void Awake()
    {
        inst = this;
    }
}

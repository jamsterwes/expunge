using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    // Manage general state, etc...
    // Control minigames, etc...

    // Singleton thyself
    public static WorldManager inst = null;
    void Awake()
    {
        inst = this;
    }
}

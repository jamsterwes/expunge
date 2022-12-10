using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class DeathScreen : MonoBehaviour
{
    [Header("Return to Main Menu")]
    public string mainMenuSceneName;
    public float timeBeforeReturn = 5.0f;

    [Header("Sounds")]
    public AudioClip deathSound;

    // COMPONENTS
    private AudioSource audioSource;
    
    // STATE
    private float loadTime;

    void Awake()
    {
        // Get components
        audioSource = GetComponent<AudioSource>();

        // Get load time
        loadTime = Time.time;
    }

    void Start()
    {
        // Play death sound
        audioSource.PlayOneShot(deathSound);
    }

    void Update()
    {
        // Poll for changing to main menu
        if (Time.time - loadTime >= timeBeforeReturn)
        {
            SceneManager.LoadScene(mainMenuSceneName);
        }
    }
}

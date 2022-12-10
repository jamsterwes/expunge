using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(SpriteRenderer))]
public class Breakable : MonoBehaviour, IInteractable
{
    [Header("Visuals")]
    public Sprite before;
    public Sprite after;

    [Header("Sound")]
    public AudioClip breakSound;

    // COMPONENTS
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;

    // STATE
    private bool broken = false;

    void Awake()
    {
        // Get connected components
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set initial sprite
        spriteRenderer.sprite = before;
    }

    public void OnInteract(WorldManager wm)
    {
        // Test/set object to broken
        if (broken) return;
        broken = true;

        // Switch sprite over
        spriteRenderer.sprite = after;

        // Play sound
        audioSource.PlayOneShot(breakSound);

        // Notify world manager something broke
        WorldManager.inst.OnObjectBroken(gameObject);
    }
}

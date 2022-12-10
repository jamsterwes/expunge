using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace ButtonMinigame
{
    [RequireComponent(typeof(AudioSource))]
    public class Button : MonoBehaviour
    {
        [HideInInspector]
        public ButtonManager manager;

        // Coordinates for this button
        int x, y;

        // If button is turned on or not
        public bool buttonOn = false;

        // Images for on/off
        public Image OnImage, OffImage;

        // Audio clip for button press
        public AudioClip PressSound;

        void Start()
        {
            UpdateImages();
        }

        void UpdateImages()
        {
            // Enable/disable the proper images
            OnImage.enabled = buttonOn;
            OffImage.enabled = !buttonOn;
        }

        public void OnClick()
        {
            // Tell manager to flip
            manager.ButtonPressed(x, y);
            
            // Check is solved?
            manager.CheckIsSolved();

            // Play sound
            GetComponent<AudioSource>().PlayOneShot(PressSound, 0.5f);
        }

        public void Flip()
        {
            // Flip the on boolean
            buttonOn = !buttonOn;
            UpdateImages();
        }

        public void SetPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
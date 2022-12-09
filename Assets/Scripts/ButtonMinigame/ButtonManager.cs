using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ButtonMinigame
{
    public class ButtonManager : MonoBehaviour
    {
        public GameObject buttonPrefab;

        [Range(2, 8)]
        public int size = 3;

        public float buttonSizePx = 200.0f;

        [Range(0, 64)]
        public int initialPresses = 8;

        Button[,] buttons;

        void Awake()
        {
            // Build grid of buttons
            buttons = new Button[size, size];

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    // Create and parent button
                    GameObject newButton = Instantiate(buttonPrefab);
                    newButton.transform.SetParent(transform);

                    // Name button
                    newButton.name = "Button (" + x.ToString() + ", " + y.ToString() + ")";

                    // Position button
                    float fullSize = buttonSizePx * size;
                    float halfSize = fullSize / 2;
                    float offset = -halfSize + buttonSizePx / 2;
                    float xPos = offset + buttonSizePx * x;
                    float yPos = offset + buttonSizePx * y;
                    newButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, yPos);
                    newButton.GetComponent<RectTransform>().localScale = buttonSizePx * Vector3.one;

                    // Connect button to manager
                    buttons[x,y] = newButton.GetComponent<Button>();
                    buttons[x,y].manager = this;
                    buttons[x,y].SetPosition(x, y);
                }
            }

            // Randomly press some buttons
            for (int p = 0; p < initialPresses; p++)
            {
                ButtonPressed(Random.Range(0, size), Random.Range(0, size));
            }
        }

        public void ButtonPressed(int x, int y)
        {
            // Flip all buttons in row and column
            for (int n = 0; n < size; n++)
            {
                if (n != y) buttons[x,n].Flip();
                if (n != x) buttons[n,y].Flip();
            }
            // Flip original button
            buttons[x,y].Flip();
        }
    }
}
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public static int boxPoints = 0;
    public int winBoxCount = 8; // Set the number of boxes required to win

    // Reference to the TMP Text element for displaying the box count
    public TMP_Text boxCountText;

    private void Update()
    {
        // Initialize the TMP Text with the current box count
        if (boxCountText != null)
        {
            boxCountText.text = "Boxes: " + boxPoints;

            // Check if the player has collected enough boxes to win
            if (boxPoints >= winBoxCount)
            {
                // Implement your win logic here
                Debug.Log("Player has won!");
            }
        }
    }

    public static void IncrementBoxPoints()
    {
        boxPoints++;
        Debug.Log("The player collected a box. Boxes: " + boxPoints);
    }
}

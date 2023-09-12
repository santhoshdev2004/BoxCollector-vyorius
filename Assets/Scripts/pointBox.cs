using UnityEngine;


public class pointBox : MonoBehaviour
{
    private bool isCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isCollected && other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Call the GameManager's IncrementBoxPoints method to increase the box count
            gameManager.IncrementBoxPoints();
            isCollected = true; // Set the flag to indicate that the box is collected

            Destroy(gameObject);
        }
        else if (isCollected)
        {
            Debug.Log("This box is already collected.");
        }
    }
}

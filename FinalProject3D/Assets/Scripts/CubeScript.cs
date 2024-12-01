using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public PuzzleManager puzzleManager;  // Reference to the PuzzleManager

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player touches this cube
        if (other.CompareTag("Player"))
        {
            // Log a message when the player touches the cube
            Debug.Log("Player touched cube: " + gameObject.name);

            // Notify PuzzleManager that the cube was touched
            if (puzzleManager != null)
            {
                puzzleManager.CubeTouched(gameObject);  // Send the touched cube to the PuzzleManager
            }
        }
    }
}
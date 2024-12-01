using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public PuzzleManager puzzleManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player touched cube: " + gameObject.name);

            if (puzzleManager != null)
            {
                puzzleManager.CubeTouched(gameObject);
            }
        }
    }
}
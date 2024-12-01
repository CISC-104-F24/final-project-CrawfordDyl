using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject door;
    public List<GameObject> correctCubes; 
    private int currentCubeIndex = 0;

    private void Start()
    {
        if (door != null)
        {
            door.SetActive(true);
        }
    }

    public void CubeTouched(GameObject touchedCube)
    {
        if (touchedCube == correctCubes[currentCubeIndex])
        {
            Debug.Log("Correct cube: " + touchedCube.name);
            currentCubeIndex++;

            if (currentCubeIndex == correctCubes.Count)
            {
                CloseDoor(); 
            }
        }
        else
        {
            Debug.Log("Wrong cube! Resetting sequence."); 
            ResetSequence(); 
        }
    }

    private void CloseDoor()
    {
        if (door != null)
        {
            Debug.Log("Puzzle solved! Closing door...");
            door.SetActive(false);
        }
    }

    private void ResetSequence()
    {
        currentCubeIndex = 0;
    }
}
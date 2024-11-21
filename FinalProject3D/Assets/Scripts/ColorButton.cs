using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButton : MonoBehaviour
{
    public string requiredTag; 
    public GameObject door; 
    private bool isPressed = false; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(requiredTag))
        {
            isPressed = true;
            CheckAllButtons();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(requiredTag))
        {
            isPressed = false;
        }
    }

    private void CheckAllButtons()
    {
        ColorButton[] buttons = FindObjectsOfType<ColorButton>();

        foreach (ColorButton button in buttons)
        {
            if (!button.isPressed)
            {
                return;
            }
        }

        if (door != null)
        {
            door.SetActive(false); 
        }
    }
}

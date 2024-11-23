using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Destroy the cannonball when it hits any object
        Destroy(gameObject);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject cannonballPrefab;
    public Transform firePoint; 
    public float shootInterval = 2f; 
    public float cannonballSpeed = 10f; 

    private float shootTimer;

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    void Shoot()
    {
        GameObject cannonball = Instantiate(cannonballPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = cannonball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false; 
            rb.velocity = firePoint.forward * cannonballSpeed; 
        }

        Destroy(cannonball, 1.7f);
    }
}

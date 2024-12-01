using System.Collections;
using UnityEngine;

public class DoubleJumpPowerUp : MonoBehaviour
{
    public float spinSpeed = 100f;  // Speed for spinning the power-up
    public float bounceHeight = 0.5f;  // Height for the bounce effect
    public float bounceSpeed = 2f;  // Speed for the bounce effect

    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        // Spin the power-up object
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime, Space.World);

        // Bounce the power-up object
        float newY = startingPosition.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player interacts with the power-up
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.canDoubleJump = true;  // Grant double jump ability
            }

            // Destroy the power-up object
            Destroy(gameObject);
        }
    }
}

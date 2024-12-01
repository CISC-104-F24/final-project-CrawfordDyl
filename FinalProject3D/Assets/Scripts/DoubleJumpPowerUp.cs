using System.Collections;
using UnityEngine;

public class DoubleJumpPowerUp : MonoBehaviour
{
    public float spinSpeed = 100f; 
    public float bounceHeight = 0.5f; 
    public float bounceSpeed = 2f;

    private Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime, Space.World);

        float newY = startingPosition.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.canDoubleJump = true; 
            }

            Destroy(gameObject);
        }
    }
}

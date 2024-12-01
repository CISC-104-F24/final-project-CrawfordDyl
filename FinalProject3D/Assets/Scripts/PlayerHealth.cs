using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    public TMP_Text livesText;
    public Transform startPosition;  // Starting position (default respawn)
    public Transform[] checkpoints;  // Array to hold all checkpoints in the scene
    private Transform currentCheckpoint;  // The player's current checkpoint
    private int currentLives;

    void Start()
    {
        currentLives = maxLives;
        currentCheckpoint = startPosition; // Set the initial checkpoint to the starting position
        UpdateLivesUI();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cannonball"))
        {
            TakeDamage();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // If player touches a checkpoint, update the current checkpoint
        if (other.CompareTag("Checkpoint"))
        {
            currentCheckpoint = other.transform; // Set the checkpoint the player reached
        }
    }

    public void TakeDamage()
    {
        currentLives--;

        if (currentLives > 0)
        {
            transform.position = currentCheckpoint.position;  // Respawn at the current checkpoint
        }
        else
        {
            Debug.Log("Game Over! Restarting...");
            ResetPlayer();
        }

        UpdateLivesUI();
    }

    void ResetPlayer()
    {
        currentLives = maxLives;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Restart the level
    }

    void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + currentLives;
        }
    }
}
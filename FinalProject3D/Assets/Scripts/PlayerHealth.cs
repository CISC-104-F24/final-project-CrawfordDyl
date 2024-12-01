using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    public TMP_Text livesText;
    public Transform startPosition; 
    public Transform[] checkpoints; 
    private Transform currentCheckpoint; 
    private int currentLives;

    void Start()
    {
        currentLives = maxLives;
        currentCheckpoint = startPosition;
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
        if (other.CompareTag("Checkpoint"))
        {
            currentCheckpoint = other.transform;
        }
    }

    public void TakeDamage()
    {
        currentLives--;

        if (currentLives > 0)
        {
            transform.position = currentCheckpoint.position;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + currentLives;
        }
    }
}
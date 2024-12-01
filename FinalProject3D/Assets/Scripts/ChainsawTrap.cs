using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainsawTrap : MonoBehaviour
{
    public float minMoveSpeed = 2f;
    public float maxMoveSpeed = 5f; 
    public float moveDistance = 5f; 

    public float spinSpeed = 360f;

    private Vector3 startingPosition;
    private bool movingRight = true;
    private float moveSpeed;

    void Start()
    {
        startingPosition = transform.position;

        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
    }

    void Update()
    {
        MoveChainsaw();

        SpinChainsaw();
    }

    void MoveChainsaw()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            if (transform.position.x >= startingPosition.x + moveDistance)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            if (transform.position.x <= startingPosition.x - moveDistance)
            {
                movingRight = true;
            }
        }
    }

    void SpinChainsaw()
    {
        transform.Rotate(spinSpeed * Time.deltaTime, 0f, 0f); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage();
            }
        }
    }
}
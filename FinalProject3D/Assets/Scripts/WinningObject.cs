using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinningObject : MonoBehaviour
{
    public TMP_Text winMessage; 
    public float spinSpeed = 100f;
    public float bounceHeight = 0.5f; 
    public float bounceSpeed = 2f; 

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;  

        if (winMessage != null)
        {
            winMessage.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime, Space.World);

        float newY = startPosition.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (winMessage != null)
            {
                winMessage.text = "Congratulations! You Have Won!";
                winMessage.gameObject.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
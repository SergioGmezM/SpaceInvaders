using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenBullet : MonoBehaviour
{
    private GameManager gameManager;
    private Transform playerTransform;

    [SerializeField] private float speed = 20f;
    [SerializeField] private float minDistance = 10.0f;
    [SerializeField] private Vector3 direction;

    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Start()
    {
        direction = playerTransform.position - transform.position;
    }

    private void Update()
    {
        if (Vector3.Distance(playerTransform.position, transform.position) > minDistance)
        {
            direction = playerTransform.position - transform.position;
        }
        
        transform.Translate(direction.normalized * speed * Time.deltaTime);
        // Poner un timer de que a los 3 segundos se destruya la bala
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.RemoveHealth(1);
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("OutOfScene"))
        {
            gameObject.SetActive(false);
        }
    }
}

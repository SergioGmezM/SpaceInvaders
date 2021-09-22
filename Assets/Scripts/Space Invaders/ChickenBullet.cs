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
    bool choosenDirection;

    // variable de control de tiempo
    float timeLived;
    [SerializeField] private float timeToDie = 1.5f;


    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void OnEnable()
    {
        timeLived = 0;
        choosenDirection = false;
    }

    private void Update()
    {
        if (!choosenDirection)
        {
            direction = playerTransform.position - transform.position;
            choosenDirection = true;
        }

        transform.Translate(direction.normalized * speed * Time.deltaTime);
        // Poner un timer de que a los 3 segundos se destruya la bala
        timeLived += Time.deltaTime;
        if (timeLived > timeToDie || gameManager.gameOver) 
        {
            gameObject.SetActive(false);
        }
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

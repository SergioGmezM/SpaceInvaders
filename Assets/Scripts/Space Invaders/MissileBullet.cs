using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBullet : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject playerGO;

    [SerializeField] private float reDirSpeed = 1.1f;
    [SerializeField] private float speed = 20f;
    [SerializeField] private float minDistance = 10.0f;
    [SerializeField] private Vector3 direction;
    Vector3 oldDirection;

    // variable de control de tiempo
    float timeLived;
    [SerializeField] private float timeToDie = 1.5f;


    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerGO = GameObject.Find("Player");
    }

    private void OnEnable()
    {
        timeLived = 0;
        direction = (playerGO.transform.position - transform.position);
        oldDirection = (playerGO.transform.position - transform.position);
    }

    private void Update()
    {
        Vector3 newDirection = (playerGO.transform.position - transform.position);
        direction = Vector3.Lerp(oldDirection, newDirection, .5f);

        transform.Translate(direction.normalized * speed * Time.deltaTime);
        // Poner un timer de que a los 3 segundos se destruya la bala
        timeLived += Time.deltaTime;
        if (timeLived > timeToDie) // añadir || gameManager.gameOver
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
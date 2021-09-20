using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private float speed = 10f;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameManager.AddScore(1);
            gameObject.SetActive(false);
            // Desactivar/Destruir enemigo
        }

        if (other.gameObject.CompareTag("OutOfScene"))
        {
            gameObject.SetActive(false);
        }
    }
}

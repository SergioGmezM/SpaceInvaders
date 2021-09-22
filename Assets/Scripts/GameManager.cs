using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int score = 0;
    [SerializeField] private int playerHealth = 5;
    [SerializeField] Text scoreText;
    [SerializeField] Text healthText;
    [SerializeField] Text victoryText;
    [SerializeField] GameObject restartButton;
    public bool gameOver = false;
    Player player;


    private void Start()
    {
        player = FindObjectOfType<Player>();
        scoreText.text = "Puntuacion: " + score.ToString();
        healthText.text = "Vida: " + playerHealth.ToString();
        victoryText.text = "";
        restartButton.SetActive(false);
    }

    public void AddScore(int points)
    {
        score += points;
        // Mostrar en una interfaz
        scoreText.text = "Puntuacion: " + score.ToString();
        if (score >= 55)  // añadir && !gameOver numero de pollos, si puede ser que se modifique se puede buscar el chickenmanager y hacer la referencia
        {
            player.canShoot = false;
            victoryText.text = "Victoria!!!";
            gameOver = true;
            Invoke("RestartGame", 2f);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void RemoveHealth(int points)
    {
        playerHealth -= points;
        // Mostrar en una interfaz
        healthText.text = "Vida: " + playerHealth.ToString();
        if (playerHealth <= 0) // añadir && !gameOver
        {
            player.canShoot = false;
            playerHealth = 0;
            gameOver = true;
            victoryText.text = "Derrota...";
            Invoke("RestartGame", 2f);
        }
    }

    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    public void RestartGame()
    {
        restartButton.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Space Invaders");
    }
}

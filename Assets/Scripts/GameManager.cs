using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variables de dificultad del juego
    [SerializeField] private int score = 0;
    [SerializeField] private int playerHealth = 5;
    public int chickenRows = 5;
    public int chickenColumns = 11;

    // Variables de interfaz
    public Text scoreText;
    public Text healthText;
    public Text victoryText;
    public Text gameOverText;
    public Button restartButton;
    public Button quitButton;
  //  public Button pauseButton;
    public Button resumeButton;
    public Canvas pauseCanvas; // dani

    // Variables de control del juego
    public bool gameOver = false;
    //public bool gamePaused = false;
    public bool paused = false; // dani


    private void Start()
    {
        pauseCanvas.gameObject.SetActive(false); // dani
        scoreText.text = "Puntuación: " + score.ToString();
        healthText.text = "Vidas: " + playerHealth.ToString();
        victoryText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
      //  pauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            PauseMenu();
        }
    }

    public void AddScore(int points)
    {
        score += points;

        scoreText.text = "Puntuación: " + score.ToString();
        if (score >= (chickenRows * chickenColumns) && !gameOver)
        {
            gameOver = true;
         //   pauseButton.gameObject.SetActive(false);
            victoryText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void RemoveHealth(int points)
    {
        playerHealth -= points;

        healthText.text = "Vidas: " + playerHealth.ToString();
        if (playerHealth <= 0 && !gameOver)
        {
            playerHealth = 0;
            gameOver = true;
       //     pauseButton.gameObject.SetActive(false);
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
        }
    }

    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    public void PauseMenu() // dani
    {
        if (paused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }
    
    public void PauseGame()
    {
        pauseCanvas.gameObject.SetActive(true);
        //      pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        paused = false;
      //  pauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        pauseCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Space Invaders");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

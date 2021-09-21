using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int score = 0;
    [SerializeField] private int playerHealth = 5;

    public void AddScore(int points)
    {
        score += points;
        // Mostrar en una interfaz
        Debug.Log(score);
    }

    public int GetScore()
    {
        return score;
    }

    public void RemoveHealth(int points)
    {
        playerHealth -= points;
        // Mostrar en una interfaz
        Debug.Log(playerHealth);
    }

    public int GetPlayerHealth()
    {
        return playerHealth;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int score = 0;

    public void AddScore(int points)
    {
        score += points;
        // Mostrar en una interfaz
        Debug.Log(score);
    }
}

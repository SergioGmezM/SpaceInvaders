using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Canvas puntuacionCanvas;
    public Canvas instructionsCanvas;
    public Canvas menuCanvas;
    public Canvas minijuegosCanvas;
    public Text maxScoreText;

    bool minijuegosCanvasActive = false;

    private void Start()
    {
        maxScoreText.text = "Maxima Puntuación: " + PlayerPrefs.GetInt("Max Score");
    }

    public void OnPlayButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Space Invaders");
    }

    public void OnInstructionsButton()
    {
       menuCanvas.gameObject.SetActive(false);
       instructionsCanvas.gameObject.SetActive(true);
    }

    public void OnBackToMenuButton()
    {
        menuCanvas.gameObject.SetActive(true);
        instructionsCanvas.gameObject.SetActive(false);
        puntuacionCanvas.gameObject.SetActive(false);
        if (minijuegosCanvasActive == true)
        {
            minijuegosCanvas.gameObject.SetActive(false);
            minijuegosCanvasActive = false;
        }
        
    }

    public void OnPuntuationButton()
    {
        menuCanvas.gameObject.SetActive(false);
        puntuacionCanvas.gameObject.SetActive(true);
    }

    public void Salir()  // poner en evento de boton de salir
    {
        Application.Quit();
    }

}

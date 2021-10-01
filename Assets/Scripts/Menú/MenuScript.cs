using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    [SerializeField] private Canvas instructionsCanvas;
    [SerializeField] private Canvas menuCanvas;
    [SerializeField] private Canvas minijuegosCanvas;

    bool minijuegosCanvasActive = false;

    public void OnPlayButton()
    {
        menuCanvas.gameObject.SetActive(false);
        minijuegosCanvas.gameObject.SetActive(true);
        minijuegosCanvasActive = true;
    }

    public void OnMinijuego1Button()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Minijuego 1");
    }

    public void OnMinijuego2Button()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Minijuego2");
    }

    public void OnExplorationButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Classroom");
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
        if (minijuegosCanvasActive == true)
        {
            minijuegosCanvas.gameObject.SetActive(false);
            minijuegosCanvasActive = false;
        }
        
    }

    public void Salir()  // poner en evento de boton de salir
    {
        Application.Quit();
    }

}

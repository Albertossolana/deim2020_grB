using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InteractividadBotones : MonoBehaviour
{
    /*public Button BotonInicio;
    void Start()
    {
        BotonInicio.Select();
    }*/
    public void EmpezarJuego()
    {
        SceneManager.LoadScene("EscenaJuego");
    }
    public void HighScore()
    {
        SceneManager.LoadScene("HighScore");
    }
    public void BackStartGame()
    {
        SceneManager.LoadScene("StartMenu");
    }
}

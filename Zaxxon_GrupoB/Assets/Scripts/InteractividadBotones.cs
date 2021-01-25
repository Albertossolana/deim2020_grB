using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractividadBotones : MonoBehaviour
{
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

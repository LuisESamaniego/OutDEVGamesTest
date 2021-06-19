using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Ejercicio1()
    {
        SceneManager.LoadScene("Ejercicio1");
    }
    public void Ejercicio2()
    {
        SceneManager.LoadScene("Ejercicio2");
    }
    public void Proyecto()
    {
        SceneManager.LoadScene("Proyecto");
    }
    public void ProyectoP2()
    {
        SceneManager.LoadScene("ProyectoP2");
    }

    public void MainMenuP()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Salir()
    {
        Application.Quit();
    }
}

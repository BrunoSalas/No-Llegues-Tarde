using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public CanvasGroup game;
    public CanvasGroup men�;
    public CanvasGroup instruciones;
    public void Tutorial()
    {
        men�.interactable = false;
        instruciones.alpha = 1;
        instruciones.interactable = true;
    }
    public void Inicio()
    {
        instruciones.interactable = false;
        instruciones.alpha = 0;
        game.interactable = true;
    }

    public void Salir()
    {
        Application.Quit();
    }
}

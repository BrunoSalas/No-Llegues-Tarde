using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public CanvasGroup game;
    public CanvasGroup menú;
    public CanvasGroup instruciones;
    public void Tutorial()
    {
        menú.interactable = false;
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

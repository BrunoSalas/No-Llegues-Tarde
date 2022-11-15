using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject game;
    public GameObject menú;
    public GameObject instruciones;
    public GameObject player;
    public GameObject ganar;
    public GameObject pierde;
    public GameObject txt;
    public GameObject boton;

    private void FixedUpdate()
    {
        if (player.GetComponent<Player>().perder)
        {
            pierde.SetActive(true);
            txt.SetActive(true);
            boton.SetActive(true);
        }
        if (player.GetComponent<Player>().final)
        {
            ganar.SetActive(true);
            txt.SetActive(true);
            boton.SetActive(true);
        }
    }
    public void Tutorial()
    {
        menú.SetActive(false);
        instruciones.SetActive(true);
    }
    public void Inicio()
    {
        instruciones.SetActive(false);
        player.GetComponent<Player>().velocity = 0.8f;
        game.SetActive(true);
    }

    public void Salir()
    {
        Application.Quit();
    }
    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}

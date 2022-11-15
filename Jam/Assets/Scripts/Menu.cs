using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject game;
    public GameObject menu;
    public GameObject instruciones;
    public GameObject player;
    public GameObject ganar;
    public GameObject pierde;
    public GameObject txt;
    public GameObject boton;
    public GameObject soundOff;
    public coin coin;
    public AudioSource audioSource;
    public AudioClip audio;
    private bool sound;
    public Camera cam;

    private void Start()
    {
        cam = Camera.FindObjectOfType<Camera>();
    }

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
        audioSource.PlayOneShot(audio);
        menu.SetActive(false);
        instruciones.SetActive(true);
    }
    public void Inicio()
    {
        audioSource.PlayOneShot(audio);
        instruciones.SetActive(false);
        player.GetComponent<Player>().velocity = 0.8f;
        game.SetActive(true);
    }

    public void Salir()
    {
        audioSource.PlayOneShot(audio);
        Application.Quit();
        coin.puntuaje = 0;
    }
    public void SceneChange(string sceneName)
    {
        audioSource.PlayOneShot(audio);
        SceneManager.LoadScene(sceneName);
    }

    public void SoundSfx()
    {
        if(sound)
        {
            audioSource.PlayOneShot(audio);
            cam.GetComponent<Camera>().GetComponent<AudioListener>().enabled = false;
            sound = !sound;
            soundOff.SetActive(true);
        }
        else
        {
            audioSource.PlayOneShot(audio);
            cam.GetComponent<Camera>().GetComponent<AudioListener>().enabled = true;
            sound = !sound;
            soundOff.SetActive(false);
        }
    }
}

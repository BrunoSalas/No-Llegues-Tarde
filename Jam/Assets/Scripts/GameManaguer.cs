using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameManaguer : MonoBehaviour
{
    public coin puntuaje;
    public int costeVelocidad;
    public int costeInvulnerable;
    public int costeRomper;
    public GameObject moneda;
    public GameObject moneda2;
    public GameObject textInvul;
    public GameObject textDestru;
    public GameObject textVelo;
    public GameObject player;
    public static GameManaguer gameManaguer;

    private void Start()
    {
        puntuaje.puntuaje = 0;
            
        gameManaguer = this;

        player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Cerebro");

    }



// Update is called once per frame
    void Update()
    {
        if (textVelo == null)
        {
            textVelo = GameObject.FindGameObjectWithTag("TextVelo");
        }
        else
        {
            textVelo.GetComponent<Text>().text = costeVelocidad.ToString();
        }
        if (textDestru == null)
        {
            textDestru = GameObject.FindGameObjectWithTag("TextoDestru");
        }
        else
        {
            textDestru.GetComponent<Text>().text = costeRomper.ToString();
        }
        if (textInvul == null)
        {
            textInvul = GameObject.FindGameObjectWithTag("TextInvul");
        }
        else
        {
            textInvul.GetComponent<Text>().text = costeInvulnerable.ToString();
        }

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");    
        }
        if (player.GetComponent<Player>().perder == false)
        {
            if (moneda == null)
            {
                moneda = GameObject.FindGameObjectWithTag("Text");
            }
            moneda.GetComponent<Text>().text = puntuaje.puntuaje.ToString();
        }
        if (player.GetComponent<Player>().perder == true)
        {
            if (moneda2 == null)
            {
                moneda2 = GameObject.FindGameObjectWithTag("2");
            }
            moneda2.GetComponent<Text>().text = Player.metros.ToString();
        }
    }


    public void Velocidad()
    {
        if (puntuaje.puntuaje >= costeVelocidad)
        {
            player.GetComponent<Player>().velocity = 0.7f;
            player.GetComponent<Player>().x = 0.2f;
            puntuaje.puntuaje -= costeVelocidad;
            costeVelocidad += costeVelocidad;
        }
    }
    public void Invulnerable()
    {
        if (puntuaje.puntuaje >= costeInvulnerable)
        {
            player.GetComponent<Player>().invulnerable = true;
            player.GetComponent<Player>().rb.isKinematic = true;
            puntuaje.puntuaje -= costeInvulnerable;
            costeInvulnerable += costeInvulnerable;
        }
    }
    public void Romper()
    {
        if (puntuaje.puntuaje >= costeRomper)
        {
            player.GetComponent<Player>().colliderDestruir = true;
            puntuaje.puntuaje -= costeRomper;
            costeInvulnerable += costeRomper;
        }
    }
}

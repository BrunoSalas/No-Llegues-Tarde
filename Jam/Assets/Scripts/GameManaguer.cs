using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameManaguer : MonoBehaviour
{
    public coin puntuaje;
    public GameObject moneda;
    public GameObject moneda2;
    public GameObject player;
    public int a;
    public static GameManaguer gameManaguer;

    private void Start()
    {
        if( a == 0)
        {
            puntuaje.puntuaje = 0;
            a++;
        }
        gameManaguer = this;

        player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Cerebro");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }



// Update is called once per frame
    void Update()
    {
        if(player == null)
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
            moneda2.GetComponent<Text>().text = puntuaje.puntuaje.ToString();
        }
    }
}

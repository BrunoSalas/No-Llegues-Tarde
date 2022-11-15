using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameManaguer : MonoBehaviour
{
    public coin puntuaje;
    public GameObject moneda;
    public GameObject moneda2;
    public static GameManaguer gameManaguer;

    private void Start()
    {
        gameManaguer = this;

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
        if(moneda == null)
        {
            moneda = GameObject.FindGameObjectWithTag("Text");
        }
        if (moneda2 == null)
        {
            moneda2 = GameObject.FindGameObjectWithTag("Text2");
        }
        moneda.GetComponent<Text>().text = puntuaje.puntuaje.ToString();
        moneda2.GetComponent<Text>().text = puntuaje.puntuaje.ToString();
    }
}

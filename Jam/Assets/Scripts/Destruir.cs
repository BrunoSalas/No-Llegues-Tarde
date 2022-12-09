using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour
{
    public float destroid = 2;
    public float time;
    public GameObject obstaculo;
    bool paso;


    private void Update()
    {
        if (paso)
        {
            time += Time.deltaTime;
        }
        if (time >= destroid)
        {
            Destroy(obstaculo);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour
{
    public GameObject padre;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Destructor"))
        {
            Debug.Log("WWWWWW");
            Destroy(padre);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    public bool z;
    public bool y;
    public bool x;
    public float rotation;
    // Update is called once per frame
    void Update()
    {
        if (x)
        {
            transform.Rotate(rotation, 0, 0);
        }
        if (y)
        {
            transform.Rotate(0, rotation, 0);
        }
        if (z)
        {
            transform.Rotate(0, 0, rotation);
        }
    }
}

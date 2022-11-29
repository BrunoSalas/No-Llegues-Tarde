using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour
{
    public GameObject target;
    public float z;
    Vector3 position;

    private void Update()
    {
        transform.position = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z - z);
    }
}

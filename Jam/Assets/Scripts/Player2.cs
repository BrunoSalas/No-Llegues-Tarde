using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player2 : MonoBehaviour
{
    public Vector3 targetPos;
    public Vector3 z;
    private Rigidbody rb;
    public float increment;
    public float velocity;
    public GameObject[] target;

    public float timeFeedback = 0.1f;

    public float speed;
    public float maxWidth;
    public float minWidth;

    public bool isMoving = false;

    void Start()
    {
        targetPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }
    void Move()
    {
        if (transform.position.x == targetPos.x)
        {
            isMoving = false;
        }

        if(isMoving)
        {
            //transform.position = Vector3.MoveTowards(transform.position, z, speed);
        }
        targetPos.z = transform.position.z;

        z = new Vector3(targetPos.x, transform.position.y, transform.position.z + velocity);
        rb.position = z;
        //rb.position = Vector2.MoveTowards(transform.position, targetPos, speed);
    }
    public void ButtonRightDown()
    {
        if (!isMoving)
        {
            if (transform.position.x < maxWidth)
            {
                isMoving = true;
                targetPos = target[1].transform.position;
                StartCoroutine(Moving(targetPos.x));
            }
        }
    }
    public void ButtonRightUp()
    {
        isMoving = false;
    }
    public void ButtonLeftDown()
    {
        if (!isMoving)
        {
            if (transform.position.x > minWidth)
            {
                isMoving = true;
                targetPos.x = target[0].transform.position.x;
                StartCoroutine(Moving(targetPos.x));
            }
        }
    }
    public void ButtonLefttUp()
    {
        isMoving = false;
    }

    IEnumerator Moving(float x)
    {
        Vector2 r = new Vector2(x, transform.position.y);
        r.x = Mathf.Clamp(transform.position.x, z.x, speed * Time.deltaTime);
        transform.position = new Vector3(r.x, r.y, transform.position.z);
        yield return null;
    }
}

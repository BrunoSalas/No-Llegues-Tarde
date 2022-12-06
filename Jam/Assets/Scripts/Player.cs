using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public coin a;
    public Rigidbody rb;
    public float velocity;
    public float x;
    public float sides;
    public float impulseZ;
    public float impulseY;
    public bool left;
    public bool right;
    public bool final;
    public bool teChocaste;
    public bool perder;
    public AudioClip audio, motoAvanzando, motoGirando,choque;
    public AudioSource audioSource;
    public AudioSource audioChoque;
    public GameObject moneda;
    public GameObject humo;
    public GameObject h;
    public GameObject m;
    public Text text;

    public GameObject eje;
    public float rotateSpeed;
    bool perderUnaVez;


    public SpawnManager spawnManager;

    void Start()
    {
        perderUnaVez = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
  
    private void FixedUpdate()
    {
        if (!teChocaste)
        {
            if (!final)
            {
                Move();
            }
        }
        if (teChocaste)
        {
            if (!perderUnaVez)
            {
                StartCoroutine(Perdiste());
            }
        }

        //ROTACION, Bruno revisa esta mierda de acá abajo y lo mejoras si se te canta jaja asies
        //Y has que cuando no presionas nada, rotes al medio
        
        if (right && eje.transform.rotation.eulerAngles.z > 90)
        {
            //Debug.Log("rotando a derecha");
            eje.transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);
        }
        if (left && eje.transform.rotation.eulerAngles.z < 109)
        {
            eje.transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
            //Debug.Log("rotando a izquierda");
        }
        if(!left && eje.transform.rotation.eulerAngles.z <= 110  && eje.transform.rotation.eulerAngles.z > 100)
        {
            eje.transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);
        }
        if (!right && eje.transform.rotation.eulerAngles.z >= 90 && eje.transform.rotation.eulerAngles.z < 100)
        {
            eje.transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        }

    }

    public void ButtonRightDown()
    {
        right = true; sides = +x;
        audioSource.PlayOneShot(motoGirando);
    }
    public void ButtonRightUp()
    {
        right = false; sides = 0;
    }
    public void ButtonLeftDown()
    {
        left = true; sides =- x;
        audioSource.PlayOneShot(motoGirando);
    }
    public void ButtonLefttUp()
    {
        left = false; sides = 0;
    }

    public void Move()
    {
        Vector3 direction = new Vector3(transform.position.x + sides, transform.position.y, transform.position.z + velocity);
        //transform.position = new Vector3(direction.x, transform.position.y, direction.y);
        rb.position = direction;
        //rb.AddForce(direction.x, transform.position.y, direction.y, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Impulsores"))
        {
            Debug.Log("ds");
            rb.AddForce(transform.position.x, transform.position.y + impulseY, transform.position.z * impulseZ, ForceMode.Impulse);
        }
        if (other.CompareTag("Coin"))
        {
            GameObject _ = Instantiate(moneda);
            _.transform.position = m.transform.position;
            a.puntuaje += 2;
            audioSource.PlayOneShot(audio);
            Destroy(_, 2f);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Final"))
        {
            final = true;
        }
        if (other.CompareTag("Obstaculo"))
        {
          teChocaste = true;
        }
        if(other.CompareTag("Spawn Trigger"))
        { 
            spawnManager.SpawnTriggerEntered();
        }
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log(other.gameObject.name);
            spawnManager.SpawnTriggerObstacle();
        }
    }

    IEnumerator Perdiste()
    {
        Debug.Log("Uy te chocaste xdddd");
        GameObject _ = Instantiate(humo);
        _.transform.position = h.transform.position;
        audioChoque.PlayOneShot(choque);
        perderUnaVez = true;
         //Sonido de chocarse, el sonido está en el proyecto
         //Particulas de humo, también puedes ocultar el modelado al momento que salgan las particulas
         //Que las particulas se extiendan rápido, duren más de 2 segundos, que parezca que tapan al modelado, como caricatura
         yield return new WaitForSeconds(1);
        perder = true;

    }
}

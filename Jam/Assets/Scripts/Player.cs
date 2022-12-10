using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public coin a;
    public Rigidbody rb;
    private float metrosTime;
    public float metrosLon;
    public static int metros;
    private float timeVelocity;
    public float timeMaxVelocity;
    private float timeVelocityCould;
    public float timeMaxVelocityCould;
    public float velocity;
    public float acelerate;
    public float x;
    public float xAcelerate;
    private float timeInvulnerable;
    [SerializeField]
    private float timeMaxInvulnerable;
    private float timeDestru;
    [SerializeField]
    private float timeMaxDestru;
    [SerializeField]
    private float sides;
    [HideInInspector]
    public bool init;
    public bool velocityCould;
    public bool invulnerable;
    public bool colliderDestruir;
    private bool left;
    private bool right;
    private bool final;
    private bool teChocaste = false;
    [HideInInspector]
    public bool perder;
    public AudioClip audio, motoAvanzando, motoGirando, choque,destruitSound,invulnerableSound,velocidadSound;
    public AudioSource audioSource;
    public AudioSource audioChoque;
    public GameObject moneda;
    public GameObject humo;
    public GameObject h;
    public GameObject m;
    public GameObject motoristaNormal;
    public GameObject motoristaFantasma;
    public ParticleSystem invulnerableParticle;
    public ParticleSystem SlowParticle;
    public GameObject DestruirParticle;
    public GameObject idle;
    public Text text;
    public Text textMetros;
    public LayerMask destruir;
    RaycastHit hit;
    public GameObject eje;
    public float rotateSpeed;
    bool perderUnaVez;
    public enum states
    {
        Vivo,
        Muerto
    }

    public states state;

    public SpawnManager spawnManager;

    void Start()
    {
        state = states.Vivo;
        metros = 0;
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

        if (init && !teChocaste)
        {
            #region metros
            metrosTime += Time.deltaTime;

            textMetros.text = metros.ToString() + "  " + "M";

            if (metrosTime >= metrosLon)
            {
                metros += 1;
                metrosTime = 0;
            }
            #endregion
            #region aumento de velocidad
            if (!velocityCould)
            {
                if (velocity != 1.1)
                {
                    timeVelocity += Time.deltaTime;
                }
                if (timeVelocity > timeMaxVelocity && velocity < 1.1)
                {
                    velocity += acelerate;
                    x += xAcelerate;
                    timeVelocity = 0;
                }
            }
            else
            {
                timeVelocityCould += Time.deltaTime;

                velocity = 0.7f;
                x = 0.2f;
                if (timeVelocityCould > timeMaxVelocityCould)
                {
                    velocityCould = false;
                    timeVelocity = 0;
                }

            }
            #endregion
            #region rotar
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
            if (!left && eje.transform.rotation.eulerAngles.z <= 110 && eje.transform.rotation.eulerAngles.z > 100)
            {
                eje.transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);

            }
            if (!right && eje.transform.rotation.eulerAngles.z >= 89 && eje.transform.rotation.eulerAngles.z < 100)
            {
                eje.transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
            }

            if (!right && !left && velocity != 0)
            {
                idle.SetActive(true);
            }
            else
            {
                idle.SetActive(false);
            }
            #endregion
            #region power ups
            if (invulnerable)
            {
                StartCoroutine(Blink());
                timeInvulnerable += Time.deltaTime;
                if (timeInvulnerable >= timeMaxInvulnerable)
                {
                    invulnerable = false;
                    rb.isKinematic = false;
                    timeInvulnerable = 0;
                }
            }
            else if (invulnerable == false)
            {
                motoristaNormal.SetActive(true);
                motoristaFantasma.SetActive(false);
            }
            if (colliderDestruir)
            {
                timeDestru += Time.deltaTime;
                if(timeDestru >= timeMaxDestru)
                {
                    colliderDestruir = false;
                    timeDestru = 0;
                }
                if (Physics.Raycast(transform.position, transform.forward, out hit, 10f,destruir))
                {
                    if (hit.collider)
                    {
                        GameObject _ = Instantiate(DestruirParticle);
                        _.transform.position = m.transform.position;
                        audioSource.PlayOneShot(destruitSound);
                        Destroy(hit.collider.gameObject);
                        Destroy(_, 2f);
                    }
                }
                if (Physics.Raycast(transform.position, new Vector3(transform.right.x, 0, transform.forward.z), out hit, 10f, destruir))
                {
                    GameObject _ = Instantiate(DestruirParticle);
                    _.transform.position = m.transform.position;
                    audioSource.PlayOneShot(destruitSound);
                    Destroy(hit.collider.gameObject);
                    Destroy(_, 2f);
                }
                if (Physics.Raycast(transform.position, new Vector3(transform.right.x - 120, 0, transform.right.z + 360), out hit, 10f, destruir))
                {
                    GameObject _ = Instantiate(DestruirParticle);
                    _.transform.position = m.transform.position;
                    audioSource.PlayOneShot(destruitSound);
                    Destroy(hit.collider.gameObject);
                    Destroy(_, 2f);
                }
                if (Physics.Raycast(transform.position, new Vector3(-transform.right.x + 120, 0, transform.right.z + 360), out hit, 10f, destruir))
                {
                    GameObject _ = Instantiate(DestruirParticle);
                    _.transform.position = m.transform.position;
                    audioSource.PlayOneShot(destruitSound);
                    Destroy(hit.collider.gameObject);
                    Destroy(_, 2f);
                }
                if (Physics.Raycast(transform.position, new Vector3(-transform.right.x, 0, transform.forward.z), out hit, 10f, destruir))
                {
                    GameObject _ = Instantiate(DestruirParticle);
                    _.transform.position = m.transform.position;
                    audioSource.PlayOneShot(destruitSound);
                    Destroy(hit.collider.gameObject);
                    Destroy(_, 2f);
                }
            }
            #endregion
        }
        else
        {
            idle.SetActive(false);
        }
    }
    public void ButtonRightDown()
    {
        if (state != states.Muerto)
        {
            right = true; sides = +x;
            audioSource.PlayOneShot(motoGirando);
        }
    }
    public void ButtonRightUp()
    {
        if (state != states.Muerto)
        {
            right = false; sides = 0;
        }
    }
    public void ButtonLeftDown()
    {
        if (state != states.Muerto)
        {
            left = true; sides = -x;
            audioSource.PlayOneShot(motoGirando);
        }
    }
    public void ButtonLefttUp()
    {
        if (state != states.Muerto)
        {
            left = false; sides = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * 10f);
        Gizmos.DrawRay(transform.position, new Vector3(transform.right.x,0,transform.forward.z) * 10f);
        Gizmos.DrawRay(transform.position, new Vector3(transform.right.x -120, 0, transform.right.z+360) * 0.05f);
        Gizmos.DrawRay(transform.position, new Vector3(-transform.right.x + 120, 0, transform.right.z + 360) * 0.05f);
        Gizmos.DrawRay(transform.position, new Vector3(-transform.right.x, 0, transform.forward.z) * 10f);
    }

    public void Move()
    {
        float hor = Mathf.Clamp(transform.position.x + sides, -4.01f, 4.01f); // nota esto hace que no pase de izquierda a derecha siin collideer eficiente
        Vector3 direction = new Vector3(hor, 0.57f, transform.position.z + velocity);
        //transform.position = new Vector3(direction.x, transform.position.y, direction.y);
        rb.position = direction;
        //rb.AddForce(direction.x, transform.position.y, direction.y, ForceMode.Force);
    }
    private void OnTriggerEnter(Collider other)
    {
        //if(other.CompareTag("Impulsores"))
        //{
        //    Debug.Log("ds");
        //    rb.AddForce(transform.position.x, transform.position.y + impulseY, transform.position.z * impulseZ, ForceMode.Impulse);
        //}
        if (other.CompareTag("Coin"))
        {
            GameObject _ = Instantiate(moneda);
            _.transform.position = m.transform.position;
            a.puntuaje += 2;
            audioSource.PlayOneShot(audio);
            Destroy(_, 2f);
            Destroy(other.gameObject);
        }
        //if (other.CompareTag("Final"))
        //{
        //    final = true;
        //}
        if (other.CompareTag("Obstaculo"))
        {
            if (!invulnerable)
            {
                teChocaste = true;
            }
        }
        if (other.CompareTag("Spawn Trigger"))
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
        state = states.Muerto;
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
    IEnumerator Blink()
    {
        motoristaNormal.SetActive(false);
        motoristaFantasma.SetActive(true);
        yield return new WaitForSeconds(timeMaxInvulnerable/2);
        motoristaNormal.SetActive(true);
        motoristaFantasma.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        motoristaNormal.SetActive(false);
        motoristaFantasma.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        motoristaNormal.SetActive(true);
        motoristaFantasma.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        motoristaNormal.SetActive(false);
        motoristaFantasma.SetActive(true);
    }
}

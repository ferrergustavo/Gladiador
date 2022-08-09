using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [Header("EnemyData")]
    public float enemieSpeed;
    [Header("EnemySounds")]
    public AudioSource WalkSound;
    public AudioSource DamageSound;
    public AudioSource attackSound;
    [Header("Others")]
    public Transform target;
    public Vector3 distanceTarget;
    public int EnemieHealth;
    public GameObject bloodPrefab;
    public GameObject PanPrefab;
    public GameObject CalizPrefab;
    public GameObject ZapatosPrefab;
    public Transform enemieBloodPoint;
    public Animator enemyAnimator;
    private float ScalePreDef = 0.4f;


    private void Awake(){
        if (target == null){
           target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    private void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        
    }
    void Update()
    {
        enemieMove();

    }

    //Movimiento
    void enemieMove() {
        distanceTarget = target.position - transform.position;
        distanceTarget.Normalize();
        transform.position += distanceTarget * enemieSpeed * Time.deltaTime;

        if (target.position.x < transform.position.x && transform.localScale.x > 0)
        {
            Vector3 auxScale = transform.localScale;
            //print("Auxiliar antes " + auxScale);
            auxScale.x = auxScale.x * -1;
           // print("Auxiliar desp " + auxScale);
            transform.localScale = auxScale;
           // print("Voy para la izquierda");
        }
        else if (target.position.x > transform.position.x && transform.localScale.x < 0)
        {
            Vector3 auxScale = transform.localScale;
          //  print("Auxiliar antes " + auxScale);
            auxScale.x = ScalePreDef;
          //  print("Auxiliar desp " + auxScale);
            transform.localScale = auxScale;
          //  print("Voy para la derecha");
        }

        //Animacion caminar
        enemyAnimator.SetBool("IsWalk", true);
       
    }
    
    //Recibo Daño
    public void EnemieReciveDamage(int damage)
    {
        if (EnemieHealth > 0)
        {
            enemyAnimator.SetBool("IsReciveDamage", true);
            EnemieHealth -= damage;
            GameObject blood = Instantiate(bloodPrefab, enemieBloodPoint.position, Quaternion.identity);
            Destroy(blood, 5f);
            enemieSpeed = enemieSpeed / 2;
            StartCoroutine(WaitEnemySpeed());
            StartCoroutine(TimeDañoRecibido());
        }
        if (EnemieHealth <= 0){
            
            string drop = chanceDrop();
            if (drop == "Pan") {
                GameObject pan = Instantiate(PanPrefab, enemieBloodPoint.position, Quaternion.identity);
                print("Se instancio un Pan !");
                Destroy(pan, 10f);
            }
            else if(drop == "Caliz")
            {
                GameObject caliz = Instantiate(CalizPrefab, enemieBloodPoint.position, Quaternion.identity);
                print("Se instancio un Caliz !");
                Destroy(caliz, 10f);
            }
            else 
            {
                GameObject zapato = Instantiate(ZapatosPrefab, enemieBloodPoint.position, Quaternion.identity);
                print("Se instancio un Zapato !");
                Destroy(zapato, 10f);
            }
            dead();
        }
    }

     private void OnCollisionEnter2D(Collision2D collision)
    {
        // print(this.name + " entro en colision con " + collision.collider.name);
        if (collision.gameObject.CompareTag(this.tag) == false)
        {
            enemyAnimator.SetBool("IsAttack", true);
            enemieSpeed = 0;
            StartCoroutine(WaitEnemySpeed());
            StartCoroutine(TimeAttak());
        }

    }

    //ChanceDrop
    private string chanceDrop()
    {
        int porcentajeDrop = Random.Range(0, 101);
        print("El porcentaje del drop fue del: " + porcentajeDrop + " %");
        if (porcentajeDrop >= 70)
        {
            print("Dropea Pan");
            return "Pan";
            
        }
        else if(porcentajeDrop >= 15 && porcentajeDrop < 70)
        {
            print("Dropea Caliz");
            return "Caliz";
        }
        else
        {
            print("Dropea Zapatos");
            return "Zapatos";
        }
    }

    //Muerte
    private void dead()
    {
        enemyAnimator.SetBool("IsDead", true);
        enemieSpeed = 0;
        Destroy(this.gameObject, 0.55f);
    }

    //--------------------------Tiempos--------------------------

    IEnumerator TimeAttak()
    {
        yield return new WaitForSeconds(0.5f);
        enemyAnimator.SetBool("IsAttack", false);
    }

    //Tiempo despues de golpe o daño recibido
    IEnumerator WaitEnemySpeed()
    {
        yield return new WaitForSeconds(2);
        enemieSpeed = 2;
    }

    //Tiempo Animación daño recibido
    IEnumerator TimeDañoRecibido()
    {
        yield return new WaitForSeconds(0.5f);
        enemyAnimator.SetBool("IsReciveDamage", false);
    }

    

    //------------------Enemy Sounds------------------------------------------
    public void PlayWalkSound()
    {
        WalkSound.Play();
    }
    public void PlayDamageSound()
    {
        DamageSound.Play();
    }
    public void PlayattackSound()
    {
        attackSound.Play();
    }

}

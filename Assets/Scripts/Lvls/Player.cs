using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    [Header("Player Data")]
    public float speedDefault;
    public float pjSpeed;
    public int health;
    public int maxHealth;
    public bool shield;
    [Header("Player Sounds")]
    public AudioSource WalkSound;
    public AudioSource RunSound;
    public AudioSource SwordSound;
    public AudioSource PanSound;
    public AudioSource CalizSound;
    public AudioSource ZapatillasSound;
    public AudioSource DeadSound;
    public AudioSource DamageSound;
    public AudioSource DefendSound;
    [Header("Others")]
    public GameObject bloodPrefab;
    public GameObject LoseCanvas;
    public GameObject WinCanvas;
    public Transform bloodpoint;
    public Transform GolpeGarra;
    public Transform GolpeGarraFallo;
    public Animator animator;
    
  


    void Update()
    {
        playerMove();
        attack();
        defend();
        if (health <= 150)
        {
            
            SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
            
            renderer.color = Color.red;
        }
        else
        {
            SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
            renderer.color = new Color(255f, 255f, 255f, 255f);
        }
        

    }

    //Movimiento Personaje
    void playerMove() {

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        float runSpeed = pjSpeed * 2;
        animator.SetFloat("HorizontalInp",moveX);

        if (Input.GetButtonDown("Run")){
            if (moveX != 0f || moveY != 0f){
                pjSpeed = runSpeed;
                animator.SetBool("IsRun", true);
            }
           
        }else if (Input.GetButtonUp("Run")){
            animator.SetBool("IsRun", false);
            pjSpeed = speedDefault;
        }
        else {
            if (moveX != 0f || moveY != 0f) {
                rb.MovePosition(transform.position + new Vector3(moveX, moveY, 0) * pjSpeed * Time.deltaTime);
                animator.SetBool("IsWalk", true);
            }
            else {
                animator.SetBool("IsWalk", false);
            }
        }
    }

    //Daño Recibido
    public void ReciveDamage(int damage) {
        if (shield == false)
        {
            DamageSound.Play();
            if (health > 0) {
                health -= damage;
                GameObject blood = Instantiate(bloodPrefab, bloodpoint.position, Quaternion.identity);
                Destroy(blood, 5f);
            }
            else if (health <= 0){
                dead();
            }
        }
        else if (shield == true)
        {
            
            if (health > 0)
            {
                health -= 0;
            }
        }
    }

    //Muerte
    void dead(){
        DeadSound.Play();
        LoseCanvas.SetActive(true);
        print("Te quedaste sin vida, suerte la proxima espartano");
        Time.timeScale = 0f;
        this.gameObject.SetActive(false);
        
    }

    //Animaciones Ataque
    void attack(){

        if (Input.GetButtonDown("Punch")){
            animator.SetBool("IsAttack", true);
        }
        else if (Input.GetButtonUp("Punch")){
            animator.SetBool("IsAttack", false);

        }
    }

    //Animaciones Defensa PJ
    void defend(){

        if (Input.GetButtonDown("Defend")){
            animator.SetBool("IsDefend", true);
            DefendSound.Play();
            shield = true;
            StartCoroutine(WaitShieldActive());
        }
        else if (Input.GetButtonUp("Defend")){
            animator.SetBool("IsDefend", false);
            shield = false;
            DefendSound.Stop();
        }
    }

   

    //Victoria
    public void win(){
        WinCanvas.SetActive(true);
       print("Eliminaste a todos los enemigos, Ganaste. Has sobrevivido con "+ health + " de vida");
        Time.timeScale = 0f;

    }

    //Curarse con pan
    public void heal(int cantHeal){
        
        if (health > 0 && health < maxHealth){
            
            health = health + cantHeal;
            print("Te curaste " + cantHeal + " de vida, vida Actual: " + health);
            PanSound.Play();
        }
        
    }

    //Aumento de velocidad por zapatos
    public void addSpeed(int cantSpeedMultipl)
    {
            CalizSound.Play();
        if (pjSpeed > 0 && pjSpeed < 15)
        {
            pjSpeed = pjSpeed * cantSpeedMultipl;
            print("Aumentaste x" + cantSpeedMultipl + " la velocidad, tu velocidad Actual: " + pjSpeed);
            StartCoroutine(addSpeedTime());
        }
        else
        {
            pjSpeed = 3;
        }
    }

    IEnumerator addSpeedTime()
    {
        ZapatillasSound.Play();
        yield return new WaitForSeconds(10);
        print("Se acabo la potencia de los zapatos");
        pjSpeed = speedDefault;
    }

    IEnumerator WaitShieldActive()
    {
        yield return new WaitForSeconds(2f);
        shield = false;
    }

    //-----------------Sounds--------------------

    public void PlayWalkSound()
    {
        WalkSound.Play();
    }
    public void PlayRunSound()
    {
        RunSound.Play();
    }
    public void PlaySwordSound()
    {
        SwordSound.Play();
    }
    
    
    
}

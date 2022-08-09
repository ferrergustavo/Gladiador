using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieLancer : MonoBehaviour
{
    [Header("LancerData")]
    public int LancerHealth;
    [Header("LancerSounds")]
    public AudioSource DamageSound;
    [Header("Others")]
    public GameObject bloodPrefab;
    public GameObject PanPrefab;
    public GameObject CalizPrefab;
    public GameObject ZapatosPrefab;
    public Transform enemieBloodPoint;
    public Animator LancerAnimator;


  


    //Recibo Daño
    public void EnemieReciveDamage(int damage)
    {
        if (LancerHealth > 0)
        {
            LancerAnimator.SetBool("IsReciveDamage", true);
            LancerHealth -= damage;
            GameObject blood = Instantiate(bloodPrefab, enemieBloodPoint.position, Quaternion.identity);
            Destroy(blood, 5f);
        }
        if (LancerHealth <= 0)
        {

            string drop = chanceDrop();
            if (drop == "Pan")
            {
                GameObject pan = Instantiate(PanPrefab, enemieBloodPoint.position, Quaternion.identity);
                print("Se instancio un Pan !");
                Destroy(pan, 10f);
            }
            else if (drop == "Caliz")
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
        else if (porcentajeDrop >= 15 && porcentajeDrop < 70)
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
        LancerAnimator.SetBool("IsDead", true);
        Destroy(this.gameObject, 0.55f);
    }
}

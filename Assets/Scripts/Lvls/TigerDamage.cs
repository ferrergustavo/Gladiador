using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerDamage : MonoBehaviour
{
    [Header("Sounds")]
    public AudioSource GolpeoSound;
    public AudioSource ErroSound;
    [Header("Others")]
    public int tigerAttack;
    public GameObject tigerGolpeoPrefab;
    public GameObject tigerErroPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

    print(this.name + " entro en colision con " + collision.name);
        Player pj = collision.GetComponent<Player>();
        if (pj != null)
        {
            bool dmg = chanceGolpe();
            if (dmg == true)
            {
                GolpeoSound.Play();
                pj.ReciveDamage(tigerAttack);
                print(collision.name + " Fue golpeado, pierde Vida");
                GameObject tigerGolpeo = Instantiate(tigerGolpeoPrefab, pj.GolpeGarra.position, Quaternion.identity);
                Destroy(tigerGolpeo, 0.5f);
            }
            else
            {
                ErroSound.Play();
                print(collision.name + " Esquivo el golpe del tigre");
                GameObject tigerErro = Instantiate(tigerErroPrefab, pj.GolpeGarraFallo.position, Quaternion.identity);
                Destroy(tigerErro, 0.5f);
            }
        }
    }

    private bool chanceGolpe() {
        int porcentajeGolpe = Random.Range(0, 101);
        print("El porcentaje del golpe fue del: " + porcentajeGolpe + " %");
        if(porcentajeGolpe <= 70) { 
            return true;
        }
        else
        {
            return false;
        }
    }
}

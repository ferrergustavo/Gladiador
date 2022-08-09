using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caliz : MonoBehaviour
{
    [Header("Strength Data")]
    //Marca la cantidad de x cuanto se multiplica el golpe.
    public int cantStrength;
    //public SwordAttack swordattk;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(this.name + " entro en colision con " + collision.name);
        SwordAttack sa = collision.GetComponentInChildren<SwordAttack>();
        
        if(sa != null)
        {
            sa.strength(cantStrength);
        }
        Destroy(this.gameObject);
    }
}

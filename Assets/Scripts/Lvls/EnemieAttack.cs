using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieAttack : MonoBehaviour
{
    [Header("AttackData")]
    public int EnemyDamage;
    public float enemieSpeed;

    //Hago daño al Pj
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(this.name + " entro en colision con " + collision.name);
        if (collision.gameObject.CompareTag(this.tag) == false)
        {
            Player pj = collision.GetComponent<Player>();
            if (pj != null)
            {
                pj.ReciveDamage(EnemyDamage);
            }
        }
    }

}

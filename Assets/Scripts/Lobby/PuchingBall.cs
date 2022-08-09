using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuchingBall : MonoBehaviour
{
    public int HealthPuchingBall;
   // public int cantGolpesPuching;
    public Animator AnimPB;

    private void Start()
    {
        AnimPB = GetComponent<Animator>();
    }

    //Recibo daño del Pj
    public void PBReciveDamage(int damage)
    {
        AnimPB.SetTrigger("TriggerDamage");
        if (HealthPuchingBall > 0)
        {
            HealthPuchingBall -= damage;
            
        }
        if (HealthPuchingBall <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

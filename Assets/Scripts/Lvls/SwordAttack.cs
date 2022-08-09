using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public int DamageSword;
    public int CountEnemiesKill;
    public int cantGolpesPB;
    public Player playerObj;

    

    //Colision de golpe
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Enemies enemy = collision.GetComponent<Enemies>();
        PuchingBall pb = collision.GetComponent<PuchingBall>();
        EnemieLancer enemyLancer = collision.GetComponent<EnemieLancer>();
        

        //Golpes a enemigos
        if (enemy != null)
        {
            //print(this.name + " golpeo a  " + collision.name);
            enemy.EnemieReciveDamage(DamageSword);
            if (enemy.EnemieHealth <= 0)
            {
                CountEnemiesKill++;
                if (CountEnemiesKill == 15)
                {
                    playerObj.win();
                }
            }
        }

        if (enemyLancer != null)
        {
            //print(this.name + " golpeo a  " + collision.name);
            enemyLancer.EnemieReciveDamage(DamageSword);
            if (enemyLancer.LancerHealth <= 0)
            {
                CountEnemiesKill++;
                if (CountEnemiesKill == 15)
                {
                    playerObj.win();
                }
            }
        }



        //Golpes a punchingBalls  
        if (pb != null)
        {
            pb.PBReciveDamage(DamageSword);
            cantGolpesPB++;
            print(this.gameObject + "golpeo " + cantGolpesPB + " Al punchball");
        }
    }

    //Multiplicar fuerza Fuerza
    public void strength(int cantStrength)
    {
        DamageSword = DamageSword * cantStrength;
        print("Aumentaste la fuerza temporalmente x" + cantStrength + " , daño Actual: " + DamageSword);

        StartCoroutine(WaitPowerTime());

    }


    IEnumerator WaitPowerTime()
    {
        yield return new WaitForSeconds(10);
        print("Se acabo la potencia del caliz");
        DamageSword = 25;
    }
}

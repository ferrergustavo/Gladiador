using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPref;
   // public GameObject EnemyBossPref;  Todavia no incorporado
    public float TimeSpawn;
    public Transform SpawnPoint;
    public Animator PuertaAnim;
    

    private void Start()
    {
            PuertaAnim = GetComponent<Animator>();
            InvokeRepeating("spawnEnemies", TimeSpawn, TimeSpawn);
            //StartCoroutine(TimeBoss()); no incorporado
    }


    void spawnEnemies()
    {
        Instantiate(EnemyPref, SpawnPoint.position , Quaternion.identity);
        PuertaAnim.SetBool("IsOpen", true);
        StartCoroutine(TimeCerrarPuerta());
    }

    IEnumerator TimeCerrarPuerta()
    {
        yield return new WaitForSeconds(0.12f);
        PuertaAnim.SetBool("IsOpen", false);
    }

   /* Por el momento no incorporado
    * 
    * IEnumerator TimeBoss()
    {
        yield return new WaitForSeconds(25);
        Instantiate(EnemyBossPref, SpawnPoint.position, Quaternion.identity);
    }*/

}

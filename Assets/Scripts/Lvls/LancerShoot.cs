using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerShoot : MonoBehaviour
{
    public Transform Target;
    public Transform ShootPosition;
    public GameObject LancePrefab;
    public Vector3 DistanceTaget;
    public AudioSource LanzaSound;

    private void Awake()
    {
        if (Target == null)
        {
            Target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    public void shoot()
    {
        LanzaSound.Play();
        print("tiro lanza");
        GameObject lanceShoot = Instantiate(LancePrefab, ShootPosition.position, ShootPosition.rotation);
        DistanceTaget = Target.position - ShootPosition.position;
        lanceShoot.transform.right = DistanceTaget;
    }
}

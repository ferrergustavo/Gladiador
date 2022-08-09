using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceMovement : MonoBehaviour
{
    public float lanceSpeed;
    public Rigidbody2D Rb;
    public float timeDestroy;
    public int LanceDamage;

    void Start()
    {
        Rb.AddForce(transform.right * lanceSpeed, ForceMode2D.Impulse);
        Destroy(this.gameObject, timeDestroy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(this.name + "golpeo al weon de   " + collision.name);
        Player pj = collision.GetComponent<Player>();
        if (pj != null)
        {
            pj.ReciveDamage(LanceDamage);
            
        }

    }
}


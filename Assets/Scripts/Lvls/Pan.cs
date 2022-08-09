using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour
{
    public int cantHeal;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player pj = collision.GetComponent<Player>();

        if (pj!=null) {

            pj.heal(cantHeal);
            Destroy(this.gameObject);

        }
        
    }
}

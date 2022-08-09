using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zapatos : MonoBehaviour
{
    public int cantSpeedMultipl;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player pj = collision.GetComponent<Player>();

        if (pj != null)
        {
            pj.addSpeed(cantSpeedMultipl);
            Destroy(this.gameObject);

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardiasPaso : MonoBehaviour
{
    public Animator animText;

    private void Start()
    {
        animText = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SwordAttack pj = collision.GetComponentInChildren<SwordAttack>(true);

        if (pj != null)
        {
            
            if (pj.cantGolpesPB >= 3)
            {
                Destroy(this.gameObject);
            }
        }
        print(collision.name + " Entro en colision");
        animText.SetTrigger("IsTrigger");

    }

    


}

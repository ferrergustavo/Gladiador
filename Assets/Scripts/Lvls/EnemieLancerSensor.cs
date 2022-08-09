using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieLancerSensor : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("IsAttack", true);
        print(this.name + " golpeo a  " + collision.name);
        animator.SetBool("IsIdle", false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("IsAttack", false);
        animator.SetBool("IsIdle", true);
    }
}

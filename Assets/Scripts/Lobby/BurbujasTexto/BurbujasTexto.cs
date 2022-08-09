using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurbujasTexto : MonoBehaviour
{
    //Animaciones Burbujas texto
    public Animator animatorEntrenadores;

    private void Start()
    {
        animatorEntrenadores = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animatorEntrenadores.SetTrigger("isTrigger");
    }


}

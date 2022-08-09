using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioMusica : MonoBehaviour
{
    [Header("Afuera")]
    public bool Fuera;
    public AudioSource MusicaAfuera;
    [Header("Dentro")]
    public AudioSource MusicaADentro;
    public AudioSource heridos;
    public bool Adentro = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Adentro = !Adentro;
        Fuera = !Fuera;
        print("El valor de Afuera es: " + Fuera);
        print("El valor de Adentro es: " + Adentro);
        if (Fuera && !Adentro)
        {
            heridos.Stop();
            MusicaADentro.Stop();
            MusicaAfuera.Play();
        }
        if(Adentro && Fuera == false)
        {
            MusicaAfuera.Stop();
            MusicaADentro.Play();
            heridos.Play();
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAbrirPuerta : MonoBehaviour
{

    public AudioSource DoorSoud;
    //Animaciones Puerta
    public Animator AbirPuerta;

    private void Start()
    {
        AbirPuerta = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AbirPuerta.SetTrigger("AbrirPuerta");
    }

    public void SoundOpenDoor()
    {
        DoorSoud.Play();
    }

}

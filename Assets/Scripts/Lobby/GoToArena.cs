using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToArena : MonoBehaviour
{
    public AudioSource DoorSoud;
    //Cambio hacia Escena 1
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(this.name + " entro en colision con " + collision.name);
        SceneManager.LoadScene("ColiseoLvl1");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    //cambio Escenas
    public void loadScene(string scene)
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        print("Exit Game");
        Application.Quit();
    }


    //Opcion solo para el Pause screen
    public void ResumeScreen()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
    }

}

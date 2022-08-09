using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public KeyCode PauseKey = KeyCode.Escape;
    public GameObject PauseCanvas;
    public bool Paused;


    private void Update()
    {
        if (Input.GetKeyDown(PauseKey))
        {
            Pause();
        }
    }

    void Pause()
    {
        Paused = !Paused;
        PauseCanvas.SetActive(Paused);

        if (Paused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

    }
}

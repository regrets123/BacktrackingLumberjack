using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*By Björn Andersson*/
public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenu;

    MouseScript mouseScript;

    bool paused = false;

    void Start()
    {
        mouseScript = GetComponent<MouseScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseAndUnPause();
        }
    }

    public void PauseAndUnPause()    //Pausar och unpausar allt som behöver kunna pausas i spelet samt visar och döljer muspekaren beroende på om spelet är pausat
    {
        paused = !paused;
        Cursor.visible = paused;
        if (paused)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (!paused)
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
        DayNightScript.Paused = !DayNightScript.Paused;
        mouseScript.Paused = !mouseScript.Paused;
        pauseMenu.SetActive(!pauseMenu.active);
    }
}
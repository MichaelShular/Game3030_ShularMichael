using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class PauseButtonsController : MonoBehaviour
{
    public bool isPaused;
    public Canvas pauseCanvas;
    private PlayerInput playerInput;
    private void Start()
    {

    }
    private void Update()
    {
        //Debug.Log(isPaused);
        if (isPaused)
        {
            pauseCanvas.enabled = !pauseCanvas.enabled;
            Time.timeScale = 0;
            if (!pauseCanvas.enabled)
            {
                Time.timeScale = 1;
            }

            isPaused = false;
        }
        
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void OnPause(InputValue value)
    {
        isPaused = value.isPressed;
    }
}

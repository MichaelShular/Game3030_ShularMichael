using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonController : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("Main");
    }
    public void EndGame()
    {
        Application.Quit();
    }
}

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

    public void OpenPDF()
    {
        Application.OpenURL("https://drive.google.com/drive/folders/1xnt6pwI-j36DHtqbHtzIT0-1lcu2Eny6?usp=sharing");
    }
    public void EndGame()
    {
        Application.Quit();
    }
}

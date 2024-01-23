using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnControlButton()
    {
        SceneManager.LoadScene("ControlsMenu");
    }

    public void OnExitButton()
    {
        Application.Quit();
    }

    public void OnBackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void ButtonHubScene()
    {
        SceneManager.LoadScene("HubScene");
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }
}

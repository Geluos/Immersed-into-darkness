using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
	public bool isPause = false;
	public GameObject pauseUI;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (isPause)
			{
				Resume();
			}
			else { Pause(); }
		}
	}

	public void Resume()
	{
		pauseUI.SetActive(false);
		Time.timeScale = 1f;
		isPause = false;
	}

	public void Pause()
	{
		pauseUI.SetActive(true);
		Time.timeScale = 0f;
		isPause = true;
	}

    public void Quit()
    {
		Application.Quit();
    }
}

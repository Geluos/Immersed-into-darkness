using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseGame : MonoBehaviour
{
	public bool isPause = false;
	public GameObject pauseUI;
	public GameObject musicUI;
	public AudioMixerGroup MasterMixer;
	public AudioMixerGroup MusicMixer;
	public AudioMixerGroup EffectsMixer;
	public GameObject[] buttons;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (isPause)
			{
				Resume();
			}
			else 
			{ 
				Pause(); 
			}
		}
	}

	void Awake()
    {
		DontDestroyOnLoad(gameObject);
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

	public void MusicOpen()
    {
		musicUI.SetActive(true);
        for (int i = 0; i < 3; i++)
        {
			buttons[i].SetActive(false);
        }
	}

	public void MusicClose()
	{
		musicUI.SetActive(false);
		for (int i = 0; i < 3; i++)
		{
			buttons[i].SetActive(true);
		}
	}

	public void ChangeVolumeMaster(float volume)
    {
		MasterMixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, volume));
    }

	public void ChangeVolumeMusic(float volume)
	{
		MusicMixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
	}

	public void ChangeVolumeEffects(float volume)
	{
		EffectsMixer.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, volume));
	}

	public void Quit()
    {
		Application.Quit();
    }
}

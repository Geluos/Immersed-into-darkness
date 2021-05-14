using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCamp : MonoBehaviour
{
    int source = 0;
    public AudioSource Audio;
    public AudioSource GlobalMusic;
    public SpriteRenderer backGround;

    bool partyMode = false;
    float time = 0;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (source<6)
            {
                if (source == 5)
                {
                    Audio.Stop();
                    GlobalMusic.clip = Resources.Load<AudioClip>($"AudioEffects/StoneCamp/source{source}");
                    GlobalMusic.Play();
                    partyMode = true;
                }
                else
                {
                    Audio.clip = Resources.Load<AudioClip>($"AudioEffects/StoneCamp/source{source}");
                    Audio.Play();
                }
                source++;
            }
        }
    }

    private void Update()
    {
        if (partyMode)
        {
            if (time > 0) { time -= Time.deltaTime; }
            else
            {
                backGround.color = new Color(Random.Range(0.2f, 1f), Random.Range(0.2f, 1f), Random.Range(0.2f, 1f), 1);
                time = 0.2f;
            }
        }
    }
}

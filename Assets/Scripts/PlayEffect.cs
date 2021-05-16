using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEffect : MonoBehaviour
{
    public AudioSource sound;
    float life_time = 0;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        yield return new WaitForSeconds(0.05f);
        sound.Play();
        yield return new WaitForSeconds(life_time);
        Destroy(gameObject);
    }
}

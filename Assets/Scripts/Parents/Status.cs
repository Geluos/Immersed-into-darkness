using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Status : MonoBehaviour
{
    public float power;
    public float level;

    public float lifetime;
    public float period;
    public bool manyRoom;
    public int last_fight;
    public Characters character;
    [HideInInspector] public float time;

    public void Start()
    {
        if (character!=null)
        {
            character.StatusList.Add(this);
            character.RefreshStatusIcons();
        }
        else
        {
            Destroy(gameObject);
        }
        time = period;
    }

    public void OnDestroy()
    {
        character?.StatusList.Remove(this);
        character?.RefreshStatusIcons();
    }
    public void Update()
    {
        if (character != null)
        {
            time = Math.Max(0, time - Time.deltaTime);
            lifetime -= Time.deltaTime;
            if (lifetime < 0f)
            {
                character.StatusList.Remove(this);
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

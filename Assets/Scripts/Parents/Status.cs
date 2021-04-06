using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Status : MonoBehaviour
{

    public float lifetime;
    public float period;
    public bool manyRoom;
    public int last_fight;
    public Characters character;
    [HideInInspector] public float time;

    void Start()
    {
        time = period;
    }

    public void Update()
    {
        time = Math.Max(0, time - Time.deltaTime);
        lifetime -= Time.deltaTime;
        if(lifetime<0f)
        {
            Destroy(this);
        }
    }
}

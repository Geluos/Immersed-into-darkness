using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeakStatus : Status
{
    public int weekPercent = 40;
    new void Start()
    {
        base.Start();
        character.power *= (100f - weekPercent) / 100f;
    }
    new void Update()
    {
        time = Math.Max(0, time - Time.deltaTime);
        lifetime -= Time.deltaTime;
        if (lifetime < 0f)
        {
            character.power /= (100f - weekPercent) / 100f; 
            Destroy(this);
        }
    }

    public WeakStatus(int perc)
    {
        weekPercent = perc;
    }
}

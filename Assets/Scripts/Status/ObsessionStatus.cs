using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObsessionStatus : Status
{
    new void Start()
    {
        base.Start();
        character.power *= 1.8f;
    }
    new void Update()
    {
        time = Math.Max(0, time - Time.deltaTime);
        lifetime -= Time.deltaTime;
        if (lifetime < 0f)
        {
            character.TakeDamage(8);
            character.power /= 1.8f;
            Destroy(this);
        }
    }
}

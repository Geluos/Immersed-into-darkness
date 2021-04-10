using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cover_Up : Status
{
    public new void Start()
    {
        base.Start();
        character.defenceMultiply *= 0.4f;
    }
    public new void Update()
    {
        time = Math.Max(0, time - Time.deltaTime);
        lifetime -= Time.deltaTime;
        if (lifetime < 0f)
        {
            character.defenceMultiply /= 0.4f;
            Destroy(this);
        }
    }
}

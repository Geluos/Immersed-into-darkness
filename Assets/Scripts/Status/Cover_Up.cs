using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cover_Up : Status
{
    public float koef;
    public new void Start()
    {
        base.Start();
        character.defenceMultiply -= koef / 100;
    }

    new public void OnDestroy()
    {
        base.OnDestroy();
        if (character != null)
        {
            character.defenceMultiply += koef / 100;
        }
    }
}

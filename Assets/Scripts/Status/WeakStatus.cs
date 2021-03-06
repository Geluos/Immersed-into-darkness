﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeakStatus : Status
{
    public float percent;
    new void Start()
    {
        base.Start();
        character.power -= percent;
    }
    new public void OnDestroy()
    {
        base.OnDestroy();
        if (character != null)
        {
            character.power += percent;
        }
    }
}

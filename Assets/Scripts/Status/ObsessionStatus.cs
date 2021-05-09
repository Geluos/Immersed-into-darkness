using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObsessionStatus : Status
{
    public float damage;
    public float koef;
    new void Start()
    {
        base.Start();
        character.power += koef;
    }
    new public void OnDestroy()
    {
        base.OnDestroy();
        if (character != null)
        {
            character.TakeDamage(damage);
            character.power -= koef;
        }
    }
}

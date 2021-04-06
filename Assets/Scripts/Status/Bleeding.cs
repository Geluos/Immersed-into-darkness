using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleeding : Status
{
    public float damage;

    new void Update()
    {
        base.Update();
        if(time==0)
        {
            time = period;
            character.TakeDamage(damage);
        }
    }
}

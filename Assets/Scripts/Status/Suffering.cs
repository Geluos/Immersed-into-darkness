using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suffering : Status //Страдание
{
    public float cooldown;
    new void Start()
    {
        base.Start();
        character.CooldownReduction -= cooldown / 100;
    }

    new public void OnDestroy()
    {
        base.OnDestroy();
        if (character!=null)
        {
            character.CooldownReduction += cooldown / 100;
        }
    }
}

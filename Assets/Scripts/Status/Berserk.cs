using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserk : Status //Берсерк
{
    public float bonus;
    new void Start()
    {
        base.Start();
        character.power += bonus;
    }

    new public void OnDestroy()
    {
        base.OnDestroy();
        if (character != null)
        {
            character.power -= bonus;
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Stimulator : Spells
{
    public Euphoria status;
    override public void Use(Characters character)
    {
        var st = Instantiate(status, character.transform);
        st.level = level;
        st.power = power;
        st.lifetime = Information.GetEffectStates("Эйфория", level, power)[1];
        st.character = character;
        HeroCharacter.SetReload(reloadtime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Red_mark : Spells
{
    public VulnerabilityStatus VS;
    override public void Use(Characters character)
    {
        var st = Instantiate(VS, character.transform);
        st.character = character;
        st.mult = 1.6f;
        st.lifetime = 10f;
        HeroCharacter.SetReload(reloadtime);
    }
}

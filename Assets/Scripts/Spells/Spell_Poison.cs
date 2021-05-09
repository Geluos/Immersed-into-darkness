using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Poison : Spells
{
    public PoisonStatus PS;
    override public void Use(Characters character)
	{
        HeroCharacter.PlayEffect("Яд");
        print("Отравили");
        var st = Instantiate(PS, character.transform);
        st.damage = Information.GetEffectStates("Отравление",level, power)[0];
        st.lifetime = Information.GetEffectStates("Отравление", level, power)[1];
        st.period = 1f;
        st.character = character;
        st.level = level;
        st.power = power;
        HeroCharacter.SetReload(reloadtime);
    }
}
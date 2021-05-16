using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Medicine : Spells
{
    public Pain status;
    override public void Use(Characters character)
	{
        base.Use(character);
        HeroCharacter.PlayEffect("бинт");
        character.TakeHeal(Information.GetSpellStates("Нестандартная медицина",level,power)[0]);
        var st = Instantiate(status, character.transform);
        st.level = level;
        st.power = power;
        st.lifetime = 50;
        st.character = character;
        HeroCharacter.SetReload(reloadtime);
    }
}
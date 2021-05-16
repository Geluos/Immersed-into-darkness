using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Bleeding : Spells
{
    //Переименовать в скальпель
    public PoisonStatus PS;
    override public void Use(Characters character)
	{
        base.Use(character);
        HeroCharacter.PlayEffect("Кровь");
        print("Наложили кровотечение");
        var st = Instantiate(PS, character.transform);
        float[] states = Information.GetEffectStates("Кровотечение", level, power);
        st.damage = states[0];
        st.lifetime = states[1];
        st.period = 1f;
        st.character = character;
        st.level = level;
        st.power = power;
        character.TakeDamage(Information.GetSpellStates("Скальпель", level, power)[0]);
        HeroCharacter.SetReload(reloadtime * (1 - HeroCharacter.CooldownReduction));
	}
}
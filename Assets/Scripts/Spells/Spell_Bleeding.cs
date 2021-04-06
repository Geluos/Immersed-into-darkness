using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Bleeding : Spells
{
    //Переименовать в скальпель
    const float damage = 6.0f;
    public PoisonStatus PS;
    override public void Use(Characters character)
	{
        print("Наложили кровотечение");
        var st = Instantiate(PS, character.transform);
        st.damage = damage * power / 3;
        st.lifetime = 10f;
        st.period = 2f;
        st.character = character;
        //character.StatusList.Add()
        character.TakeDamage(power * damage);
        HeroCharacter.SetReload(reloadtime);
	}
}
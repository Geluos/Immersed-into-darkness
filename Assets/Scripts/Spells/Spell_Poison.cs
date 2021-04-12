using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Poison : Spells
{
    const float damage = 2.0f;
    public PoisonStatus PS;
    override public void Use(Characters character)
	{
        HeroCharacter.PlayEffect("Яд");
        print("Отравили");
        var st = Instantiate(PS, character.transform);
        st.damage = damage*power;
        st.lifetime = 7f;
        st.period = 1f;
        st.character = character;
        //character.StatusList.Add()
        character.TakeDamage(power * damage);
        HeroCharacter.SetReload(reloadtime);
    }
}